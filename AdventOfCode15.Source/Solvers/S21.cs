public class S21 : BaseSolver
{
    private readonly double _bossHp;
    private readonly double _bossDamage;
    private readonly double _bossArmor;

    // Calculated these manually
    private Dictionary<int, (int min, int max)> damageCosts = new Dictionary<int, (int min, int max)>()
    {
        [4] = (8, 8),
        [5] = (10, 33),
        [6] = (25, 58),
        [7] = (40, 108),
        [8] = (65, 130),
        [9] = (90, -1),
        [10] = (115, -1),
        [11] = (149, -1),
        [12] = (190, -1),
        [13] = (224, -1)
    };

    private Dictionary<int, (int min, int max)> armorCosts = new Dictionary<int, (int min, int max)>()
    {
        [0] = (0, 0),
        [1] = (13, -1),
        [2] = (31, 40),
        [3] = (53, 80),
        [4] = (71, 100),
        [5] = (91, 120),
        [6] = (113, -1),
        [7] = (135, -1),
        [8] = (162, -1),
        [9] = (195, -1),
        [10] = (222, -1)
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
        for (int i = 0; i < turnsToWin.Length; i++)
        {
            var winningTurnCount = turnsToWin[i];
            if (winningTurnCount == -1) continue;

            var minimumArmor = Array.FindIndex(turnsToLose, x => x >= winningTurnCount);

            winningValues.Add((i, minimumArmor));
        }

        var minimumGold = int.MaxValue;
        var maximumLosingGold = 0;
        foreach (var winningValue in winningValues)
        {
            // process losing value
            if (winningValue.armor > 0)
            {
                var maxDamageCost = damageCosts[winningValue.damage].max;
                var maxArmorCost = armorCosts[winningValue.armor - 1].max;
                var maxResult = maxDamageCost + maxArmorCost;
                if (maxResult > maximumLosingGold)
                {
                    maximumLosingGold = maxResult;
                }
            }

            var damageCost = damageCosts[winningValue.damage].min;
            var armorCost = armorCosts[winningValue.armor].min;
            var result = damageCost + armorCost;
            if (result < minimumGold)
            {
                minimumGold = result;
            }
        }

        _answer1 = minimumGold.ToString();
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