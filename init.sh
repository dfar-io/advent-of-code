if [ "$1" == "" ]
then
      echo "Usage: init.sh <number with 2 digits>"
      exit 1
fi

# create directory
mkdir Day$1

# create projects
dotnet new sln -o Day$1
dotnet new console --name Day$1 -o Day$1/Day$1
dotnet new nunit --name Day$1.Tests -o Day$1/Day$1.Tests

# add projects to solution
dotnet sln Day$1/Day$1.sln add Day$1/Day$1/Day$1.csproj
dotnet sln Day$1/Day$1.sln add Day$1/Day$1.Tests/Day$1.Tests.csproj

# add test references and packages
dotnet add Day$1/Day$1.Tests/Day$1.Tests.csproj package FluentAssertions
dotnet add Day$1/Day$1.Tests/Day$1.Tests.csproj package coverlet.msbuild
dotnet add Day$1/Day$1.Tests/Day$1.Tests.csproj reference Day$1/Day$1/Day$1.csproj