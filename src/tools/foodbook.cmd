@echo off

IF "%1"=="help" (
  goto :printHelp
) ELSE IF "%1"=="database" (
  REM extract all args after %1 and pass it to databaseCommand.cmd to skip "database" arg
  for /f "tokens=1,* delims= " %%a in ("%*") do call "%~dp0\databaseCommand.cmd" %%b
  exit /b
) ELSE IF "%1 %2"=="migration add" (
  call "%~dp0\migrationAdd.cmd" %3
  exit /b
) ELSE IF "%1 %2"=="server run" (
  call "%~dp0\serverRun.cmd"
  exit /b
) ELSE IF "%1 %2"=="setup environment" (
  call "%~dp0\setunEnvirnment.cmd"
  exit /b
) ELSE IF "%1 %2"=="goto root" (
  call "%~dp0\gotoRoot.cmd"
  exit /b
) ELSE (
  echo Food-Book CLI: Unknown command: %*
  echo.
  goto :printHelp
)

goto :EOF

:printHelp
echo.
echo [92mFood-Book CLI: [0m
echo.
echo Description:
echo {VAR_NAME: type} - required
echo [VAR_NAME: type] - optional
echo.
echo Available commands:
echo.
echo ----- Common -------
echo - [96msetup environment [0m - performs initial setup (environment variables, database)
echo - [96mgoto root [0m - changes path to FOODBOOK_ROOT
echo.
echo ----- Database -----
echo - [96mdatabase update [--recreate][0m - applies new migrations
echo - [96mdatabase drop [0m - removes database
echo - [96mmigration add {MigrationName: string} [0m - adds new migration
echo   For example: foodbook migration add NewMigrationName
echo.
echo ----- Client -------
echo.
echo ----- Server -------
echo - [96mserver run [0m - runs Food-Book API using Kestrel web server
