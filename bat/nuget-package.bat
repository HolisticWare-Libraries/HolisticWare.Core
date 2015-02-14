@echo off

..\..\.nuget\NuGet.exe ^
	pack ^
	..\nuspecs\HolisticWare.Core.nuspec
	
@IF %ERRORLEVEL% NEQ 0 PAUSE
