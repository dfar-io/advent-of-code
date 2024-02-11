![CI](https://github.com/dfar-io/aoc15/actions/workflows/ci.yml/badge.svg)

# advent-of-code
Solutions to Advent of Code using C#

## Updating dependencies

To update dependencies on the project, run in a Codespace:

```
dotnet outdated -u
```

## Adding StyleCop

Add the following to `.csproj`:

```
<ItemGroup>
    <PackageReference Include="StyleCop.Analyzers" Version="1.1.118">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
</ItemGroup>
```

### Modify StyleCop

Create a ruleset file.

Add the following to `.csproj` and reference the above file:
```
<PropertyGroup>
  <CodeAnalysisRuleSet>AdventOfCode.StyleCop.ruleset</CodeAnalysisRuleSet>
</PropertyGroup>
```
