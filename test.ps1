$dockerOSType = docker info --format "{{.OSType}}"
if ($dockerOSType -ieq 'linux') {
  & dotnet test  --verbosity normal --settings coverletArgs.runsettings --no-build   --no-restore
} else {
  & dotnet test --filter Category!=LinuxIntegration --verbosity normal --settings coverletArgs.runsettings  --no-build --no-restore
}
if ($LastExitCode -ne 0) {
  exit 1
}
