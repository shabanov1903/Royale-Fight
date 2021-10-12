using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSkinWriter : MonoBehaviour
{
    public GameObject ObjectMass;
    public string Field;
    private skin skinObj;

    // Update is called once per frame
    public void Update()
    {
        // Так как предыдущий объект удаляется при переключении, то ссылка меняется
        // Формирование ссылки на объект не произвести через функцию Start
        skinObj = ObjectMass.GetComponent<SelectSkin>().skinObject;
        switch (Field)
        {
            // Необходимо поместить скрипт на нужное текстовое поле
            // После этого ввести параметр, который будет отображаться
            case "name": gameObject.GetComponent<Text>().text = skinObj.name; break;
            case "damage": gameObject.GetComponent<Text>().text = skinObj.damage.ToString(); break;
            case "costCoins": gameObject.GetComponent<Text>().text = skinObj.costCoins.ToString(); break;
            case "costCrystals": gameObject.GetComponent<Text>().text = skinObj.costCrystals.ToString(); break;
            case "isBought":
                { 
                    if (skinObj.isBought == 0) gameObject.GetComponent<Text>().text = "Not Bought";
                    else gameObject.GetComponent<Text>().text = "Bought";
                }; break;
        }
    }
}