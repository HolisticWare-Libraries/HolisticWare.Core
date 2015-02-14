@echo off

call .\nuget-api-key.secured.bat

..\..\.nuget\NuGet.exe ^
	push ^
	.\HolisticWare.Core.1.0.0.nupkg ^
	%API_KEY%
	
@IF %ERRORLEVEL% NEQ 0 PAUSE


