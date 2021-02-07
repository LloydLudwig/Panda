@echo [info] building panda
dotnet build
@echo [info] running panda code
.\bin\Debug\netcoreapp3.1\Panda.exe .\bin\Debug\netcoreapp3.1\%1 %2