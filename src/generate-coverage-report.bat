dotnet new tool-manifest
dotnet tool install dotnet-reportgenerator-globaltool
dotnet test --collect:"xplat code coverage"
reportgenerator -reports:"../**/coverage.cobertura.xml" -targetdir:'coverage-report'