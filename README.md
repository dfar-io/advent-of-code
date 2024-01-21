![CI](https://github.com/dfar-io/aoc15/actions/workflows/ci.yml/badge.svg)
[![Maintainability](https://api.codeclimate.com/v1/badges/df91ff4070edbe12d568/maintainability)](https://codeclimate.com/github/dfar-io/aoc15/maintainability)
[![Test Coverage](https://api.codeclimate.com/v1/badges/df91ff4070edbe12d568/test_coverage)](https://codeclimate.com/github/dfar-io/aoc15/test_coverage)

# advent-of-code
Solutions to Advent of Code using C#

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
