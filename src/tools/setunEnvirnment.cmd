@echo off

echo.
echo [92mAdding project specific environment variables... [0m
powershell -file "%~dp0\addEnvVariables.ps1"
if %errorlevel% neq 0 goto :error

echo.
echo [92mAppling database migrations... [0m
call "%~dp0\databaseCommand.cmd" update
if %errorlevel% neq 0 goto :error
