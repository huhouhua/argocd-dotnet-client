$dockerOSType = docker info --format "{{.OSType}}"
if ($dockerOSType -ieq 'linux') {
  & dotnet test  --verbosity normal --settings coverletArgs.runsettings 
} else {
  & dotnet test --filter Category!=LinuxIntegration --verbosity normal --settings coverletArgs.runsettings 
}
if ($LastExitCode -ne 0) {
  exit 1
}
#--no-build   --no-restore
