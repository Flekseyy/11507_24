namespace _11507_24.Homework._07._02._2026;
using System.Globalization; 

public class Hero
{
    private string _name;
    private string _primaryAttr;
    private int _complexity;
    private int _damage;
    private double _armor;
    private int _magRes;
    private int _evasion;
    private int _accuracy;
    private int _crit;
    private int _atkSpd;
    private int _range;
    private bool _cleave;
    private int _hp;
    private double _hpReg;
    private int _mana;
    private double _manaReg;
    private int _moveSpd;
    
    public string Name => _name;
    public string PrimaryAttr => _primaryAttr;
    public int Complexity => _complexity;
    public int Damage => _damage;
    public double Armor => _armor;
    public int MagRes => _magRes;
    public int Evasion => _evasion;
    public int Accuracy => _accuracy;
    public int Crit => _crit;
    public int AtkSpd => _atkSpd;
    public int Range => _range;
    public bool Cleave => _cleave;
    public int HP => _hp;
    public double HPReg => _hpReg;
    public int Mana => _mana;
    public double ManaReg => _manaReg;
    public int MoveSpd => _moveSpd;
    
    public Hero(string name,
        string primaryAttr, 
        int complexity,
        int damage,
        double armor,
        int magRes,
        int evasion,
        int accuracy,
        int crit,
        int atkSpd,
        int range,
        bool cleave,
        int hp,
        double hpReg,
        int mana,
        double manaReg,
        int moveSpd
        )
        {
            _name = name;
            _primaryAttr = primaryAttr;
            _complexity = complexity;
            _damage = damage;
            _armor = armor;
            _magRes = magRes;
            _evasion = evasion;
            _accuracy =  accuracy;
            _crit = crit;
            _atkSpd = atkSpd;
            _range = range;
            _cleave = cleave;
            _hp = hp;
            _hpReg = hpReg;
            _mana = mana;
            _manaReg = manaReg;
            _moveSpd = moveSpd;
        }

    public static Hero Parse(string line)
    {    string[] split = line.Split(';');
    
 
        if (split == null || split.Length < 17)
            return null;
        string name = split[0].Trim();
        string primaryAttr = split[1].Trim();
  
        string GetValue(string part)
        {
            var parts = part.Split(':');
            return parts.Length > 1 ? parts[1].Trim() : "";
        }
    
        int.TryParse(GetValue(split[2]), out int complexity);
        string dmgRaw = GetValue(split[3]); 
        int.TryParse(dmgRaw.Split('-')[0], out int damage);
        double.TryParse(GetValue(split[4]), System.Globalization.NumberStyles.Any, 
                    CultureInfo.InvariantCulture, out double armor);
        int.TryParse(GetValue(split[5]).Replace("%", ""), out int magRes);
        int.TryParse(GetValue(split[6]), out int evasion);
        int.TryParse(GetValue(split[7]).Replace("%", ""), out int accuracy);
        int.TryParse(GetValue(split[8]), out int crit);
        int.TryParse(GetValue(split[9]), out int atkSpd);
        int.TryParse(GetValue(split[10]), out int range);
        int.TryParse(GetValue(split[11]), out int cleaveInt);
        int.TryParse(GetValue(split[12]), out int hp);
        double.TryParse(GetValue(split[13]), System.Globalization.NumberStyles.Any, 
                    CultureInfo.InvariantCulture, out double hpReg);
        int.TryParse(GetValue(split[14]), out int mana);
        double.TryParse(GetValue(split[15]), System.Globalization.NumberStyles.Any, 
                    CultureInfo.InvariantCulture, out double manaReg);
        int.TryParse(GetValue(split[16]), out int moveSpd);
        bool cleave = cleaveInt == 1;
    
        return new Hero(
            name, primaryAttr, complexity,  
            damage, armor, magRes, evasion, accuracy, 
            crit, atkSpd, range, cleave, hp, hpReg, mana, manaReg, moveSpd
        );
    }
}



// Dmg - Базовый урон 
// Armor -  Базовая броня
// MagRes - Сопротивление магии (%)
// Evasion - Шанс уклонения (%)
// Accuracy - Точность атаки (%)
// Crit - Шанс крита (%)
// AtkSpd - Базовая скорость атаки
// Range - Дальность атаки 
// Cleave - Есть ли разброс урона (0/1)
// HP - Здоровье на 1 уровне
// HPReg - Реген здоровья в секунду
// Mana - Мана на 1 уровне
// ManaReg - Реген маны в секунду
// MoveSpd - Скорость передвижения

