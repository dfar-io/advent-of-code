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
    private int _spentMana;

    public S22(string[] input) : base(input)
    {
        _isPlayerWinner = null;
        _bossHp  = int.Parse(_input[0].Split(": ")[1]);
        var bossDamage = int.Parse(_input[1].Split(": ")[1]);
        // No boss armor

        _playerHp = 50;
        _playerMana = 500;

        while (true)
        {
            // Player turn
            DisplayStatus();
            Upkeep();
            if (_isPlayerWinner.HasValue)
            {
                break;
            }
            PerformPlayerTurn();

            // Boss turn
            DisplayStatus();
            Upkeep();
            if (_isPlayerWinner.HasValue)
            {
                break;
            }

            _playerHp -= bossDamage - _playerArmor;
        }

        Console.WriteLine(_isPlayerWinner.Value ? "Player wins" : "Boss wins");
        // 1538 too high
        _answer1 = _spentMana.ToString();
    }

    private void PerformPlayerTurn()
    {
        if (_bossHp <= 4) { MagicMissile(); return; }
        if (_poisonCount == 0) { Poison(); return; }
        if (_regenCount == 0 && _playerMana <= 327) { Recharge(); return; }
        if (_shieldCount == 0 && _playerHp < 32) { Shield(); return; }
        MagicMissile();
    }

    private void Upkeep()
    {
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

        if (_regenCount > 0)
        {
            _regenCount--;
            _playerMana += 101;
        }

        if (_shieldCount > 0)
        {
            _shieldCount--;
            _playerArmor = 7;
        }
        else
        {
            _playerArmor = 0;
        }

        if (_poisonCount > 0)
        {
            _poisonCount--;
            _bossHp -= 3;
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

    private void DisplayStatus()
    {
        Console.WriteLine($"- Player has {_playerHp} hit points, {_playerArmor} armor, {_playerMana} mana");
        Console.WriteLine($"- Boss has {_bossHp} hit points");
    }
}