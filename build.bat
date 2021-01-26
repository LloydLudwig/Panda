@echo BUILDING PANDA
dotnet build
echo running panda code
.\bin\Debug\netcoreapp3.1\Panda.exe .\bin\Debug\netcoreapp3.1\%1