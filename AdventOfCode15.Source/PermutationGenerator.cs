public static class PermutationGenerator
{
    // https://stackoverflow.com/a/10630026
    public static IEnumerable<IEnumerable<string>> Generate(
        this IEnumerable<string> list, int length)
    {
        if (length == 1) return list.Select(t => new string[] { t });

        return Generate(list, length - 1)
            .SelectMany(t => list.Where(e => !t.Contains(e)),
                (s1, s2) => s1.Concat(new string[] { s2 }));
    }
}