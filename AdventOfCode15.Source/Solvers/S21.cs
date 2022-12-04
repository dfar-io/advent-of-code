public class S21 : BaseSolver
{
    private readonly double _bossHp;
    private readonly double _bossDamage;
    private readonly double _bossArmor;

    // Calculated these manually
    private Dictionary<int, int> minDamageCosts = new Dictionary<int, int>()
    {
        [4] = 8,
        [5] = 10,
        [6] = 25,
        [7] = 40,
        [8] = 65,
        [9] = 90,
        [10] = 115,
        [11] = 149,
        [12] = 190,
        [13] = 224,
    };

    private Dictionary<int, int> minArmorCosts = new Dictionary<int, int>()
    {
        [0] = 0,
        [1] = 13,
        [2] = 31,
        [3] = 53,
        [4] = 71,
        [5] = 91,
        [6] = 113,
        [7] = 135,
        [8] = 162,
        [9] = 195,
        [10] = 222,
    };

    private Dictionary<int, int> maxDamageCosts = new Dictionary<int, int>()
    {
        [4] = 8,
        [5] = 33,
        [6] = 58,
        [7] = 108,
        [8] = 133
    };

    private Dictionary<int, int> maxArmorCosts = new Dictionary<int, int>()
    {
        [0] = 0,
        [2] = 40,
        [3] = 80,
        [4] = 100,
        [5] = 120
    };

    public S21(string[] input) : this(input, 100) {}

    public S21(string[] input, double playerHitPoints) : base(input)
    {
        _bossHp = double.Parse(_input[0].Split(": ")[1]);
        _bossDamage = double.Parse(_input[1].Split(": ")[1]);
        _bossArmor = double.Parse(_input[2].Split(": ")[1]);

        var turnsToWin = FindTurnsToWin();
        var turnsToLose = FindTurnsToLose(playerHitPoints);

        var winningValues = new List<(int damage, int armor)>();
        var losingValues = new List<(int damage, int armor)>();
        for (int i = 0; i < turnsToWin.Length; i++)
        {
            var winningTurnCount = turnsToWin[i];
            if (winningTurnCount == -1) continue;

            var minimumArmor = Array.FindIndex(turnsToLose, x => x >= winningTurnCount);
            if (minimumArmor > 0)
            {
                losingValues.Add((i, minimumArmor - 1));
            }

            winningValues.Add((i, minimumArmor));
        }

        var minimumGold = int.MaxValue;
        foreach (var winningValue in winningValues)
        {
            var damageCost = minDamageCosts[winningValue.damage];
            var armorCost = minArmorCosts[winningValue.armor];
            var result = damageCost + armorCost;
            if (result < minimumGold)
            {
                minimumGold = result;
            }
        }

        var maximumLosingGold = 0;
        foreach (var losingValue in losingValues)
        {
            var damageCost = maxDamageCosts[losingValue.damage];
            var armorCost = maxArmorCosts[losingValue.armor];
            var result = damageCost + armorCost;
            if (result > maximumLosingGold)
            {
                maximumLosingGold = result;
            }
        }

        _answer1 = minimumGold.ToString();
        // not 99 or 128, too low
        _answer2 = maximumLosingGold.ToString();
    }

    private int[] FindTurnsToWin()
    {
        return new int[]
        {
            // using the index as the "attack" value
            -1, 
            -1,
            -1,
            -1,
            (int)Math.Ceiling(_bossHp / Math.Max(1, 4 - _bossArmor)),
            (int)Math.Ceiling(_bossHp / Math.Max(1, 5 - _bossArmor)),
            (int)Math.Ceiling(_bossHp / Math.Max(1, 6 - _bossArmor)),
            (int)Math.Ceiling(_bossHp / Math.Max(1, 7 - _bossArmor)),
            (int)Math.Ceiling(_bossHp / Math.Max(1, 8 - _bossArmor)),
            (int)Math.Ceiling(_bossHp / Math.Max(1, 9 - _bossArmor)),
            (int)Math.Ceiling(_bossHp / Math.Max(1, 10 - _bossArmor)),
            (int)Math.Ceiling(_bossHp / Math.Max(1, 11 - _bossArmor)),
            (int)Math.Ceiling(_bossHp / Math.Max(1, 12 - _bossArmor)),
            (int)Math.Ceiling(_bossHp / Math.Max(1, 13 - _bossArmor)),
        };
    }

    private int[] FindTurnsToLose(double playerHitPoints)
    {
        return new int[]
        {
            (int)Math.Ceiling(playerHitPoints / Math.Max(1, _bossDamage - 0)),
            (int)Math.Ceiling(playerHitPoints / Math.Max(1, _bossDamage - 1)),
            (int)Math.Ceiling(playerHitPoints / Math.Max(1, _bossDamage - 2)),
            (int)Math.Ceiling(playerHitPoints / Math.Max(1, _bossDamage - 3)),
            (int)Math.Ceiling(playerHitPoints / Math.Max(1, _bossDamage - 4)),
            (int)Math.Ceiling(playerHitPoints / Math.Max(1, _bossDamage - 5)),
            (int)Math.Ceiling(playerHitPoints / Math.Max(1, _bossDamage - 6)),
            (int)Math.Ceiling(playerHitPoints / Math.Max(1, _bossDamage - 7)),
            (int)Math.Ceiling(playerHitPoints / Math.Max(1, _bossDamage - 8)),
            (int)Math.Ceiling(playerHitPoints / Math.Max(1, _bossDamage - 9)),
            (int)Math.Ceiling(playerHitPoints / Math.Max(1, _bossDamage - 10))
        };
    }
}