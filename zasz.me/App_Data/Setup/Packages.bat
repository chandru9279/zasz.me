cd ..\..\..\
mkdir packages
cd packages
if not exist Unity.2.0 nuget install Unity -version 2.0
if not exist elmah.1.1 nuget install elmah -version 1.1
if not exist AntiXSS.4.0.1 nuget install AntiXSS -version 4.0.1
if not exist Moq.4.0.10827 nuget install Moq -version 4.0.10827
if not exist EntityFramework.4.1.10331.0 nuget install EntityFramework -version 4.1.10331.0
if not exist HtmlAgilityPack.1.4.0 nuget install HtmlAgilityPack -version 1.4.0
pause
