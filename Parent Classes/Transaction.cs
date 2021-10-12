public class TransactionHero<T> : ITransaction<T> where T : hero
{
    private IPlayerSingletone player;
    public TransactionHero(IPlayerSingletone player) => this.player = player;
    public bool Execute(T obj, string PriceType)
    {
        IDataBase<hero> db = new DataBaseHero();

        if (CostCompare(obj, PriceType) && BoughtCheck(obj))
        {
            if (PriceType == "costCoins") player.ChangeCoins(-db.GetParameter(obj.id, PriceType));
            if (PriceType == "costCrystals") player.ChangeCrystals(-db.GetParameter(obj.id, PriceType));
            obj.isBought = 1;
            db.SetParameter(obj);
        }
        return false;
    }

    private bool CostCompare(T obj, string money)
    {
        IDataBase<hero> db = new DataBaseHero();
        if (db.GetParameter(obj.id, money) <= player.player.coins) return true;
        else return false;
    }
    private bool BoughtCheck(T obj)
    {
        IDataBase<hero> db = new DataBaseHero();
        if (db.GetParameter(obj.id, "isBought") == 0) return true;
        else return false;
    }
}

public class TransactionSkin<T> : ITransaction<T> where T : skin
{
    private IPlayerSingletone player;
    public TransactionSkin(IPlayerSingletone player) => this.player = player;
    public bool Execute(T obj, string PriceType)
    {
        IDataBase<skin> db = new DataBaseSkin();

        if (CostCompare(obj, PriceType) && BoughtCheck(obj))
        {
            if (PriceType == "costCoins") player.ChangeCoins(-db.GetParameter(obj.id, PriceType));
            if (PriceType == "costCrystals") player.ChangeCrystals(-db.GetParameter(obj.id, PriceType));
            obj.isBought = 1;
            db.SetParameter(obj);
        }
        return false;
    }

    private bool CostCompare(T obj, string money)
    {
        IDataBase<skin> db = new DataBaseSkin();
        if (db.GetParameter(obj.id, money) <= player.player.coins) return true;
        else return false;
    }
    private bool BoughtCheck(T obj)
    {
        IDataBase<skin> db = new DataBaseSkin();
        if (db.GetParameter(obj.id, "isBought") == 0) return true;
        else return false;
    }
}

public class Buy
{
    private PlayerSingletone ps;
    private TransactionHero<hero> th;
    private TransactionSkin<skin> ts;
    public Buy(PlayerSingletone ps)
    {
        this.ps = ps;
        this.th = new TransactionHero<hero>(ps);
        this.ts = new TransactionSkin<skin>(ps);
    }
    public void BuyCoins(hero hero)
    {
        th.Execute(hero, "costCoins");
    }
    public void BuyCoins(skin skin)
    {
        ts.Execute(skin, "costCoins");
    }
    public void BuyCrystals(hero hero)
    {
        th.Execute(hero, "costCrystals");
    }
    public void BuyCrystals(skin skin)
    {
        ts.Execute(skin, "costCrystals");
    }
}

// Пример использования класса покупки персонажа:
/*
// Общий Singletone
var ps = new PlayerSingletone();
// Объекты, которые мы хотим купить
// Необходимо передать только соответствующий id и сформировать объект
var heroObj = new DataBaseHero().GetObject(2);
var skinObj = new DataBaseSkin().GetObject(2);

// Объект-прокси имеющий функции покупки за монеты и за кристаллы
// Необходим для удобства использования
var buy = new Buy(ps);
buy.BuyCoins(heroObj);
buy.BuyCoins(skinObj);
*/