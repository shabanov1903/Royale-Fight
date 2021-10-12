using SQLite4Unity3d;

// Состояния анимации игрока
public enum States
{
    Idle,
    Walk,
    Throw
}

// Общедоступные классы для общения с базой данных
public class player
{
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }
    public int hero { get; set; }
    public int skin { get; set; }
    public int level { get; set; }
    public int experience { get; set; }
    public int coins { get; set; }
    public int crystals { get; set; }
}

public class hero
{
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }
    public string name { get; set; }
    public int health { get; set; }
    public int costCoins { get; set; }
    public int costCrystals { get; set; }
    public int isBought { get; set; }
}

public class skin
{
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }
    public string name { get; set; }
    public int damage { get; set; }
    public int costCoins { get; set; }
    public int costCrystals { get; set; }
    public int isBought { get; set; }
}

public class level
{
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }
    public int experience { get; set; }
    public int costCoins { get; set; }
    public int costCrystals { get; set; }
    public int isBought { get; set; }
}