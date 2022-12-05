using System.Text;

public class S11 : BaseSolver
{
    public S11(string input)
        : base(input)
    {
        var newPassword = _input[0];

        while (!IsPasswordValid(newPassword))
        {
            newPassword = IncrementPassword(newPassword);
        }

        Answer1 = newPassword;
        newPassword = IncrementPassword(newPassword);

        while (!IsPasswordValid(newPassword))
        {
            newPassword = IncrementPassword(newPassword);
        }
        
        Answer2 = newPassword;
    }

    private string IncrementPassword(string password)
    {
        var sb = new StringBuilder(password);
        for (var i = sb.Length - 1; i >= 0; i--)
        {
            if (sb[i] == 'z')
            {
                sb[i] = 'a';
            }
            else
            {
                sb[i]++;
                break;
            }
        }

        return sb.ToString();
    }

    private bool IsPasswordValid(string password)
    {
        if (password.Contains("i") || password.Contains("o") || password.Contains("l"))
            return false;

        var hasStraight = false;
        var pairCount = 0;
        var previousPair = false;

        for (int i = 0; i < password.Length - 1; i++)
        {
            if (!hasStraight && i < password.Length - 2 && password[i] + 1 == password[i + 1] && password[i] + 2 == password[i + 2])
            {
                hasStraight = true;
            }

            if (password[i] == password[i + 1] && !previousPair)
            {
                pairCount++;
                previousPair = true;
            }
            else
            {
                previousPair = false;
            }
        }

        return hasStraight && pairCount > 1;
    }
}