using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Код зачисления кэша
        // var playerSingletone = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerSingletone>();
        var playerSingletone = PlayerSingletone.Instance;
        var dbl = new DataBaseLevel();
        var lev = dbl.GetObject(playerSingletone.player.level + 1);
        playerSingletone.player.coins += lev.costCoins;
        playerSingletone.player.crystals += lev.costCrystals;
        playerSingletone.player.experience += lev.experience;
        playerSingletone.SetLevel(playerSingletone.player.level + 1);
    }
}
