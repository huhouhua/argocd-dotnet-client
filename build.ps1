param (
  [string]$DotnetVersion
)

$args = @()
if (-not [string]::IsNullOrWhiteSpace($DotnetVersion)) {
  $framework = "net$DotnetVersion"
  $args += @("--framework", $framework)
  Write-Host "🔍 Build specific framework: $framework"
} else {
  Write-Host "🔍 Build all target frameworks (no --framework specified)"
}

function Build() {
  Write-Host "🔧 Restoring..."
  & dotnet restore
  if ($LastExitCode -ne 0) { exit 1 }

  Write-Host "🔨 Building (Debug)..."
  & dotnet build @args --no-restore
  if ($LastExitCode -ne 0) { exit 1 }

  Write-Host "🏗️ Building (Release)..."
  & dotnet build @args -c Release --no-restore
  if ($LastExitCode -ne 0) { exit 1 }
}

function Pack() {
  Write-Host "📦 Packing..."
  & dotnet pack -c Release --no-restore --no-build
  if ($LastExitCode -ne 0) { exit 1 }
}

function Main() {
  Build
  Pack
}

Main
