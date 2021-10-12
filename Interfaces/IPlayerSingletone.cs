public interface IPlayerSingletone
{
    // Общий объект Singletone
    // Необходим для хранения всех текущих параметров игрока
    public player player { get; set; }

    // Функции типа Set необходимы для записи конкретных значений
    // Значения должны записываться непосредственно в базу данных проекта
    public void SetHero(int var);
    public void SetSkin(int var);
    public void SetLevel(int var);
    public void ChangeExperience(int var);
    public void ChangeCoins(int var);
    public void ChangeCrystals(int var);
}