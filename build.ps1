param (
  [string]$DotnetVersion
)
$args = @("")
if (-not [string]::IsNullOrWhiteSpace($DotnetVersion)) {
  $framework = "net$DotnetVersion"
  $args += @("--framework", $framework)
  Write-Host "🔍 Build specific framework: $framework"
} else {
  Write-Host "🔍 Build all target frameworks (no --framework specified)"
}

function Build()
{
	& dotnet restore | Write-Host
	if ($LastExitCode -ne 0)
	{
		exit 1
	}

	& dotnet build $args --no-restore  -warnaserror:false | Write-Host
	if ($LastExitCode -ne 0)
	{
		exit 1
	}

	& dotnet build $args -c Release  -warnaserror:false --no-restore | Write-Host
	if ($LastExitCode -ne 0)
	{
		exit 1
	}
}

function Pack()
{
	& dotnet pack -c Release --no-restore --no-build | Write-Host
	if ($LastExitCode -ne 0)
	{
		exit 1
	}
}

function Main()
{
	Build
	Pack
}

Main
