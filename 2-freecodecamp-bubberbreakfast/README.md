# Criando o projeto:

    1 - dotnet new sln -o BubberBreakFast
    2 - dotnet new webapi -o BubberBreakFast
    3 - dotnet new classlib -o BubberBreakFast.Contracts
    4 - dotnet sln add .\BubberBreakFast.Contracts\ .\BubberBreakFast\
        ou dotnet sln add (ls -r **/*.csproj)