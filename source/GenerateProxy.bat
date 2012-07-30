set OLDDIR=%CD%
set MyPath="C:\Program Files (x86)\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools"

%MyPath%\svcutil.exe %OLDDIR%\BoService\bin\BoService.dll /ct:System.Collections.Generic.List`1 /directory:files

%MyPath%\svcutil.exe /t:code files\*.wsdl files\*.xsd /language:c# /out:Ironframework.ProxyService.cs /namespace:*,Ironframework.Proxy.EmployeeService /directory:files

