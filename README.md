# 1.SimpelTestInMemoryDb

Denne branch demonstrer Unit Test af hovedsageligt **ServiceLayer**, eftersom databasen er *InMemory* og derfor
ikke fungerer helt som en "rigtig" SQL server.

Projektet er af typen **MSTest**

Tilføj NuGet pakken: ```Microsoft.EntityFrameworkCore.InMemory``` til projektet med Contexten.

Husk forhindre contexten i at benytte SQL server konfigurationen.

[Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting?view=mstest-net-1.2.0)

[Fin blog om MSTest](https://www.meziantou.net/2018/01/22/mstest-v2-setup-a-test-project-and-run-tests)