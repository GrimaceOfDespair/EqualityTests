@echo off
..\.nuget\nuget.exe pack EqualityTests.csproj /build /properties Configuration=Release
if %0 == "%~0"  pause