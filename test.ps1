$dockerOSType = docker info --format "{{.OSType}}"
if ($dockerOSType -ieq 'linux') {
  & dotnet test  --verbosity normal --settings coverletArgs.runsettings --no-build   --no-restore
} else {
  & dotnet test --filter Category!=LinuxIntegration --verbosity normal --settings coverletArgs.runsettings  --no-build --no-restore
}

$exitWithError = $LastExitCode -ne 0

Write-Host "CODECOV_TOKEN is: $env:CODECOV_TOKEN"

Get-ChildItem Env:

$openCoverFile = Get-ChildItem -Path "test/*/coverage.opencover.xml" -Recurse | Sort-Object LastWriteTime | Select-Object -last 1
if (Test-Path "$openCoverFile") {
  Write-Host "Uploading coverage file"
  & codecov -f "$openCoverFile" -t $env:CODECOV_TOKEN
  $exitWithError = $exitWithError -or $LastExitCode -ne 0
}

if ($exitWithError) {
  exit 1
}
