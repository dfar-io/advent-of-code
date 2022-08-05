public class Solver04 : BaseSolver
{
    public Solver04()
    {
        var secretKey = System.IO.File.ReadAllText(@"input/04.txt");
        var x = 0;

        while (true)
        {
            var hash = GetHash($"{secretKey}{x}");
            // use this to get Answer1
            //if (hash.StartsWith("00000"))
            if (hash.StartsWith("000000"))
            {
                Answer2 = x;
                break;
            }

            x++;
        }
    }

    // https://stackoverflow.com/a/24031467
    private string GetHash(string input)
    {
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }
}