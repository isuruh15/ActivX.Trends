CLS
CLS
@echo OFF
@color 2
echo -----------------
echo Cleaning and deleting
echo -----------------
echo .
echo .
@ping -n 1 -w [2000] 127.0.0.1 >nul
@c:\Windows\Microsoft.NET\Framework\v4.0.30319\RegAsm.exe /u EleSy.ActiveX.dll
echo .
echo .
@ping -n 1 -w [2000] 127.0.0.1 >nul
@c:\Windows\Microsoft.NET\Framework\v4.0.30319\RegAsm.exe /u EleSy.CV.ActiveX.dll
echo .
echo .
@ping -n 1 -w [2000] 127.0.0.1 >nul
@del %Temp%\APC\INFINITYHMI\EleSy_CV_ActiveX.exd /s
CLS
echo ------------------------------
echo Registration EleSy.ActiveX.dll
echo ------------------------------
echo .
echo .
@ping -n 1 -w [2000] 127.0.0.1 >nul
@c:\Windows\Microsoft.NET\Framework\v4.0.30319\RegAsm.exe /tlb /codebase EleSy.ActiveX.dll
echo .
echo .
@ping -n 1 -w [2000] 127.0.0.1 >nul
@c:\Windows\Microsoft.NET\Framework\v4.0.30319\RegAsm.exe /tlb /codebase EleSy.ActiveX.dll
echo .
echo .
@ping -n 1 -w [2000] 127.0.0.1 >nul
@c:\Windows\Microsoft.NET\Framework\v4.0.30319\RegAsm.exe /tlb /codebase EleSy.CV.ActiveX.dll
CLS
EXIT