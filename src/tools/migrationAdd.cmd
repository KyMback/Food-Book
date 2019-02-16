@echo off
pushd "%~dp0/../web/server/FoodBook/Database/Database.Migrations"
set migrationName=%1
echo Adding migration %migrationName% to project Database...
dotnet ef migrations add %migrationName%
popd