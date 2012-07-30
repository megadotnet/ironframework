@echo off
setlocal
if /i "%~1"=="" (
	@echo Run this batch file from the directory where IronFramework.sln resides.
	@echo Usage: %0 [debug ^| release ] [output_path]
	@echo Example: %0 debug c:\Ironframework-debug-build
	goto:EOF
)
set build=%~1
set out=%~f2
C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe IronFramework.sln "/p:Configuration=%build%;OutputPath=%out%;DeployOnBuild=True;DeployTarget=Package;IncludeSetAclProviderOnDestination=False;RunCodeAnalysis=false"
