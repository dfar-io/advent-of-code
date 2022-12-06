public class S22 : BaseSolver
{
    private int _bossHp;
    private int _playerHp;
    private int _playerArmor;
    private int _playerMana;

    private int _regenCount;
    private int _shieldCount;
    private int _poisonCount;

    private bool? _isPlayerWinner;
    private bool _isPlayerTurn;
    private int _spentMana;

    public S22(string[] input)
        : base(input)
    {
        _isPlayerWinner = null;
        _bossHp = int.Parse(Input[0].Split(": ")[1]);
        var bossDamage = int.Parse(Input[1].Split(": ")[1]);

        _playerHp = 50;
        _playerMana = 500;

        while (true)
        {
            // Player turn
            Console.WriteLine();
            DisplayStatus("Player");
            Upkeep();
            if (_isPlayerWinner.HasValue)
            {
                break;
            }

            PerformPlayerTurn();

            // Boss turn
            Console.WriteLine();
            DisplayStatus("Boss");
            Upkeep();
            if (_isPlayerWinner.HasValue)
            {
                break;
            }

            var bossDamageDealt = Math.Max(1, bossDamage - _playerArmor);
            Console.WriteLine($"Boss deals {bossDamageDealt} damage; you go down to {_playerHp - bossDamageDealt} hit points.");
            _playerHp -= bossDamage - _playerArmor;
        }

        Console.WriteLine(_isPlayerWinner.Value ? "Player wins" : "Boss wins");
        Answer1 = _spentMana.ToString();
    }

    private void PerformPlayerTurn()
    {
        if (_bossHp <= 4) { MagicMissile(); }
        else if (_playerHp == 8) { Drain(); }
        else if (_poisonCount == 0) { Poison(); }
        else if (_regenCount == 0 && _bossHp > 19) { Recharge(); }
        else if (_shieldCount == 0 && _bossHp > 25) { Shield(); }
        else { MagicMissile(); }
    }

    private void Upkeep()
    {
        _isPlayerTurn = !_isPlayerTurn;
        if (_isPlayerTurn) { _playerHp--; }

        if (_playerHp <= 0 || _playerMana <= 0)
        {
            _isPlayerWinner = false;
            return;
        }

        if (_bossHp <= 0)
        {
            _isPlayerWinner = true;
            return;
        }

        ProcessRegen();
        ProcessShield();
        ProcessPoison();
    }

    private void ProcessPoison()
    {
        if (_poisonCount > 0)
        {
            _poisonCount--;
            _bossHp -= 3;
        }
    }

    private void ProcessShield()
    {
        if (_shieldCount > 0)
        {
            _shieldCount--;
            _playerArmor = 7;
        }
        else
        {
            _playerArmor = 0;
        }
    }

    private void ProcessRegen()
    {
        if (_regenCount > 0)
        {
            _regenCount--;
            _playerMana += 101;
        }
    }

    private void MagicMissile()
    {
        Console.WriteLine("Magic Missile");
        _playerMana -= 53;
        _spentMana += 53;
        _bossHp -= 4;
    }

    private void Drain()
    {
        Console.WriteLine("Drain");
        _playerMana -= 73;
        _spentMana += 73;
        _bossHp -= 2;
        _playerHp += 2;
    }

    private void Shield()
    {
        Console.WriteLine("Shield");
        _playerMana -= 113;
        _spentMana += 113;
        _shieldCount = 6;
    }

    private void Poison()
    {
        Console.WriteLine("Poison");
        _playerMana -= 173;
        _spentMana += 173;
        _poisonCount = 6;
    }

    private void Recharge()
    {
        Console.WriteLine("Recharge");
        _playerMana -= 229;
        _spentMana += 229;
        _regenCount = 5;
    }

    private void DisplayStatus(string name)
    {
        Console.WriteLine($"{name}");
        Console.WriteLine($"- Player has {_playerHp} hit points, {_playerArmor} armor, {_playerMana} mana");
        Console.WriteLine($"- Boss has {_bossHp} hit points");
        Console.WriteLine($"- Poison: {_poisonCount}, Shield: {_shieldCount}, Recharge: {_regenCount}");
    }
}