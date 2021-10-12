using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingletone : MonoBehaviour, IPlayerSingletone
{
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    
    // Для обеспечения работы необходимо обращаться через следующую сигнатуру:
    // mainObject.Instance.Function()
    #region SINGLETON PATTERN
    private static PlayerSingletone instance;
    public static PlayerSingletone Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PlayerSingletone>();

                if (instance == null)
                {
                    GameObject container = new GameObject("MainObject");
                    instance = container.AddComponent<PlayerSingletone>();
                }
            }
            return instance;
        }
    }
    #endregion

    // Объект, хранящий все настройки текущего персонажа
    // В процессе игры необходимо обращаться к его полям
    // Для записи настроек вызываем метод SetParameters
    public player player { get; set; }
    public PlayerSingletone()
    {
        player = new DataBasePlayer().GetObject(1);
    }

    public void SetHero(int var)
    {
        var db = new DataBasePlayer();
        player.hero = var;
        db.SetParameter(player);
    }
    public void SetSkin(int var)
    {
        var db = new DataBasePlayer();
        player.skin = var;
        db.SetParameter(player);
    }
    public void SetLevel(int var)
    {
        var db = new DataBasePlayer();
        player.level = var;
        db.SetParameter(player);
    }
    public void ChangeExperience(int var)
    {
        var db = new DataBasePlayer();
        player.experience = player.experience + var;
        db.SetParameter(player);
    }
    public void ChangeCoins(int var)
    {
        var db = new DataBasePlayer();
        player.coins = player.coins + var;
        db.SetParameter(player);
    }
    public void ChangeCrystals(int var)
    {
        var db = new DataBasePlayer();
        player.crystals = player.crystals + var;
        db.SetParameter(player);
    }
}