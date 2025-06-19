param (
  [string]$DotnetVersion
)

$dockerOSType = docker info --format "{{.OSType}}"

$testArgs = @(
  "--verbosity" "normal"
  "--settings" "coverletArgs.runsettings"
  "--no-build"
  "--no-restore"
)
if (-not [string]::IsNullOrWhiteSpace($DotnetVersion)) {
  $framework = "net$DotnetVersion"
  $testArgs += @("--framework", $framework)
  Write-Host "🔍 Testing specific framework: $framework"
} else {
  Write-Host "🔍 Testing all target frameworks (no --framework specified)"
}

if ($dockerOSType -ieq 'linux') {
  & dotnet test $testArgs
} else {
  & dotnet test @testArgs --filter Category!=LinuxIntegration
}

if ($LastExitCode -ne 0) {
  exit 1
}
