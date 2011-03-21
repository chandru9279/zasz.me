cd ..\..\..\
mkdir packages
cd packages
<<<<<<< HEAD
if not exist Unity.2.0 nuget install Unity -version 2.0
if not exist elmah.1.1 nuget install elmah -version 1.1
if not exist RavenDB.1.0.0.289 nuget install RavenDB -version 1.0.0.289
if not exist AntiXSS.4.0.1 nuget install AntiXSS -version 4.0.1
=======
nuget install Unity -version 2.0
nuget install elmah -version 1.1
nuget install RavenDB -version 1.0.0.289
nuget install Moq -version 4.0.10827
>>>>>>> 6585b1cb15f31979fe51dc3fb529fdd2b930836d
