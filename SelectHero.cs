using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SelectHero : Select
{
    public hero heroObject;
    void Start()
    {
        // Для добавления новых персонажей необходимо добавить префабы с соответствующими именами в папку ресурсов
        // Расположение папки Assets/Resources/Heroes
        // Наименование персонажей, префабов и имён в БД должны совпадать
        objects.Add(Resources.Load<GameObject>(@"Heroes\Santa"));
        objects.Add(Resources.Load<GameObject>(@"Heroes\Punk"));
        objects.Add(Resources.Load<GameObject>(@"Heroes\Clerk"));

        // Необходимо для подгрузки аниматора демонстрации
        foreach (GameObject obj in objects)
        {
            obj.GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(@"Animators\Select");
        }

        // Создание первого персонажа
        ChangePosition(counter + 1);
    }
    public override void ChangePosition(int id)
    {
        GameObject createdObject = GameObject.FindGameObjectWithTag("Player");
        Destroy(createdObject);
        Instantiate(objects[id - 1], Vector3.zero, Quaternion.LookRotation(Vector3.back, Vector3.up));
        DataBaseHero dbh = new DataBaseHero();
        heroObject = dbh.GetObject(id);
    }

    public override void SelectObject()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        PlayerSingletone ps = gameController.GetComponent<PlayerSingletone>();
        DataBaseHero dbh = new DataBaseHero();
        if (dbh.GetParameter((counter + 1), "isBought") == 1) ps.SetHero(counter + 1);
        else return;
    }

    public override void BuyObjectCoins()
    {
        var heroObj = new DataBaseHero().GetObject(counter + 1);
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        PlayerSingletone ps = gameController.GetComponent<PlayerSingletone>();
        var buy = new Buy(ps);
        buy.BuyCoins(heroObj);
        ChangePosition(counter + 1);
    }

    public override void BuyObjectCrystals()
    {
        var heroObj = new DataBaseHero().GetObject(counter + 1);
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        PlayerSingletone ps = gameController.GetComponent<PlayerSingletone>();
        var buy = new Buy(ps);
        buy.BuyCrystals(heroObj);
        ChangePosition(counter + 1);
    }
}