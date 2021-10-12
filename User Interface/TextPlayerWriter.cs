using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPlayerWriter : MonoBehaviour
{
    public string Field;
    private player playerObj;

    private void Start()
    {
        // playerObj = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerSingletone>().player;
        playerObj = PlayerSingletone.Instance.player;
    }

    // Update is called once per frame
    public void Update()
    {
        switch (Field)
        {
            // Необходимо поместить скрипт на нужное текстовое поле
            // После этого ввести параметр, который будет отображаться
            case "level": gameObject.GetComponent<Text>().text = playerObj.level.ToString(); break;
            case "experience": gameObject.GetComponent<Text>().text = playerObj.experience.ToString(); break;
            case "coins": gameObject.GetComponent<Text>().text = playerObj.coins.ToString(); break;
            case "crystals": gameObject.GetComponent<Text>().text = playerObj.crystals.ToString(); break;
        }
    }
}