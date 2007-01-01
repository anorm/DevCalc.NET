rm -r release
mkdir release

rem Build application
"C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\devenv" DevCalc.NET.sln /Rebuild release

rem Copy source
svn export . release\source
cd release\source
"c:\Program Files\7-Zip\7z.exe" a -r ..\devcalc.net.src.zip *
cd ..
rm -r source
cd ..

rem Copy executable
copy DevCalc.NET\bin\Release\dc.exe release
cd release
"c:\Program Files\7-Zip\7z.exe" a devcalc.net.zip dc.exe
del dc.exe
cd..

rem Copy installer
copy Setup\Release\DevCalc.NET.msi release
