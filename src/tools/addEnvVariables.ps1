$envVal = [Environment]::GetEnvironmentVariable("FOODBOOK_ROOT", "User");

if ("$envVal" -eq "") { 
  Write-Host "FOODBOOK_ROOT environment variable unset.";

  $foodBook = Join-Path $PSScriptRoot "../" -Resolve;

  Write-Host "Adding FOODBOOK_ROOT $foodBook to environment variables.";  
  [Environment]::SetEnvironmentVariable("FOODBOOK_ROOT", "$foodBook", "User");
  
  Write-Host "Adding $foodBook to path variable.";  
  [Environment]::SetEnvironmentVariable("Path", [Environment]::GetEnvironmentVariable("Path", "User") + ";$foodBook", "User");
} else {
  Write-Host "FOODBOOK_ROOT already added to Environment variables.";
}