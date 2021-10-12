using SQLite4Unity3d;
public class DataBaseHero : IDataBase<hero>
{
    private string dbPath = "royale.db";

    public hero GetObject(int id)
    {
        var db = new DataService(dbPath);
        var query = db.GetConnection().Table<hero>().Where(V => V.id == id);
        return new hero
        {
            id = query.ElementAt(0).id,
            name = query.ElementAt(0).name,
            health = query.ElementAt(0).health,
            costCoins = query.ElementAt(0).costCoins,
            costCrystals = query.ElementAt(0).costCrystals,
            isBought = query.ElementAt(0).isBought
        };
    }
    public int GetParameter(int id, string column)
    {
        var db = new DataService(dbPath);
        var query = db.GetConnection().Table<hero>().Where(V => V.id == id);
        if (column == "id") return query.ElementAt(0).id;
        if (column == "health") return query.ElementAt(0).health;
        if (column == "costCoins") return query.ElementAt(0).costCoins;
        if (column == "costCrystals") return query.ElementAt(0).costCrystals;
        if (column == "isBought") return query.ElementAt(0).isBought;
        return 0;
    }

    public void SetParameter(hero obj)
    {
        var db = new DataService(dbPath);
        db.GetConnection().Update(obj);
    }
}

public class DataBaseSkin : IDataBase<skin>
{
    private string dbPath = "royale.db";

    public skin GetObject(int id)
    {
        var db = new DataService(dbPath);
        var query = db.GetConnection().Table<skin>().Where(V => V.id == id);
        return new skin
        {
            id = query.ElementAt(0).id,
            name = query.ElementAt(0).name,
            damage = query.ElementAt(0).damage,
            costCoins = query.ElementAt(0).costCoins,
            costCrystals = query.ElementAt(0).costCrystals,
            isBought = query.ElementAt(0).isBought
        };
    }
    public int GetParameter(int id, string column)
    {
        var db = new DataService(dbPath);
        var query = db.GetConnection().Table<skin>().Where(V => V.id == id);
        if (column == "id") return query.ElementAt(0).id;
        if (column == "damage") return query.ElementAt(0).damage;
        if (column == "costCoins") return query.ElementAt(0).costCoins;
        if (column == "costCrystals") return query.ElementAt(0).costCrystals;
        if (column == "isBought") return query.ElementAt(0).isBought;
        return 0;
    }

    public void SetParameter(skin obj)
    {
        var db = new DataService(dbPath);
        db.GetConnection().Update(obj);
    }
}

public class DataBaseLevel : IDataBase<level>
{
    private string dbPath = "royale.db";

    public level GetObject(int id)
    {
        var db = new DataService(dbPath);
        var query = db.GetConnection().Table<level>().Where(V => V.id == id);
        return new level
        {
            id = query.ElementAt(0).id,
            experience = query.ElementAt(0).experience,
            costCoins = query.ElementAt(0).costCoins,
            costCrystals = query.ElementAt(0).costCrystals,
            isBought = query.ElementAt(0).isBought
        };
    }
    public int GetParameter(int id, string column)
    {
        var db = new DataService(dbPath);
        var query = db.GetConnection().Table<level>().Where(V => V.id == id);
        if (column == "id") return query.ElementAt(0).id;
        if (column == "experience") return query.ElementAt(0).experience;
        if (column == "costCoins") return query.ElementAt(0).costCoins;
        if (column == "costCrystals") return query.ElementAt(0).costCrystals;
        if (column == "isBought") return query.ElementAt(0).isBought;
        return 0;
    }

    public void SetParameter(level obj)
    {
        var db = new DataService(dbPath);
        db.GetConnection().Update(obj);
    }
}

public class DataBasePlayer : IDataBase<player>
{
    private string dbPath = "royale.db";

    public player GetObject(int id)
    {
        var db = new DataService(dbPath);
        var query = db.GetConnection().Table<player>().Where(V => V.id == id);
        return new player
        {
            id = query.ElementAt(0).id,
            hero = query.ElementAt(0).hero,
            skin = query.ElementAt(0).skin,
            level = query.ElementAt(0).level,
            experience = query.ElementAt(0).experience,
            coins = query.ElementAt(0).coins,
            crystals = query.ElementAt(0).crystals,
        };
    }
    public int GetParameter(int id, string column)
    {
        var db = new DataService(dbPath);
        var query = db.GetConnection().Table<player>().Where(V => V.id == id);
        if (column == "id") return query.ElementAt(0).id;
        if (column == "hero") return query.ElementAt(0).hero;
        if (column == "skin") return query.ElementAt(0).skin;
        if (column == "level") return query.ElementAt(0).level;
        if (column == "experience") return query.ElementAt(0).experience;
        if (column == "coins") return query.ElementAt(0).coins;
        if (column == "crystals") return query.ElementAt(0).crystals;
        return 0;
    }

    public void SetParameter(player obj)
    {
        var db = new DataService(dbPath);
        db.GetConnection().Update(obj);
    }
}