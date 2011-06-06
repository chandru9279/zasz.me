REG delete "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment" /V ProjectRootPath /f
SetX ProjectRootPath "E:\Dev\Confidence" /M
PAUSE