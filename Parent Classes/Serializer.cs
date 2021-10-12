using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Runtime.Serialization;
using System.Data;

public class Serializer : ISerialize
{
    public player player;
    private SerializeObject sObject;
    public Serializer()
    {
        this.sObject = new SerializeObject();
        this.player = sObject.DeSerialise();
    }

    public void ExecuteSerialize()
    {
        sObject.Serialise(player);
    }

    public void SetHero(int hero)
    {
        player.hero = hero;
    }
    public void SetSkin(int skin)
    {
        player.skin = skin;
    }
    public void SetLevel(int level)
    {
        player.level = level;
    }
    public void SetExperience(int experience)
    {
        player.experience = experience;
    }
    public void SetCoins(int coins)
    {
        player.coins = coins;
    }
    public void SetCrystals(int crystals)
    {
        player.crystals = crystals;
    }
}

public class SerializeObject
{
    string sPath;

    public void Serialise(player player)
    {
        GetSteamingAssetsPath();
        using (FileStream fileStream = new FileStream(sPath, FileMode.OpenOrCreate))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            #pragma warning disable SYSLIB0011
            formatter.Serialize(fileStream, player);
            #pragma warning restore SYSLIB0011
        }
    }
    public player DeSerialise()
    {
        GetSteamingAssetsPath();
        using (FileStream fileStream = new FileStream(sPath, FileMode.OpenOrCreate))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            player player = new player();

            #pragma warning disable SYSLIB0011
            player = (player)formatter.Deserialize(fileStream);
            #pragma warning restore SYSLIB0011
            return player;
        }
    }

    void GetSteamingAssetsPath()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            sPath = Application.dataPath + "/Raw";
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            sPath = "jar:file://" + Application.dataPath + "!/assets";
        }
        else
        {
            sPath = Application.dataPath + "/StreamingAssets";
        }
    }
}