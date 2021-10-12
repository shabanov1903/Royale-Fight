using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SelectSkin : Select
{
    public skin skinObject;
    void Start()
    {
        // Для добавления новых персонажей необходимо добавить префабы с соответствующими именами в папку ресурсов
        // Расположение папки Assets/Resources/Skins
        // Наименование персонажей, префабов и имён в БД должны совпадать
        objects.Add(Resources.Load<GameObject>(@"Skins\Snow"));
        objects.Add(Resources.Load<GameObject>(@"Skins\Fire"));
        objects.Add(Resources.Load<GameObject>(@"Skins\Water"));

        foreach (GameObject obj in objects)
        {
            obj.GetComponent<Rigidbody>().useGravity = false;
        }

        // Создание первого скина
        ChangePosition(counter + 1);
    }
    public override void ChangePosition(int id)
    {
        GameObject createdObject = GameObject.FindGameObjectWithTag("PlayerBullet");
        Destroy(createdObject);
        Instantiate(objects[id - 1], new Vector3(0.0f, 2.5f, 0.0f), Quaternion.identity);
        DataBaseSkin dbs = new DataBaseSkin();
        skinObject = dbs.GetObject(id);
    }

    public override void SelectObject()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        PlayerSingletone ps = gameController.GetComponent<PlayerSingletone>();
        DataBaseSkin dbs = new DataBaseSkin();
        if (dbs.GetParameter((counter + 1), "isBought") == 1) ps.SetSkin(counter + 1);
        else return;
    }

    public override void BuyObjectCoins()
    {
        var skinObj = new DataBaseSkin().GetObject(counter + 1);
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        PlayerSingletone ps = gameController.GetComponent<PlayerSingletone>();
        var buy = new Buy(ps);
        buy.BuyCoins(skinObj);
        ChangePosition(counter + 1);
    }

    public override void BuyObjectCrystals()
    {
        var skinObj = new DataBaseSkin().GetObject(counter + 1);
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        PlayerSingletone ps = gameController.GetComponent<PlayerSingletone>();
        var buy = new Buy(ps);
        buy.BuyCrystals(skinObj);
        ChangePosition(counter + 1);
    }
}