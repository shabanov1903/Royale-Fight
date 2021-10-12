using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHeroWriter : MonoBehaviour
{
    public GameObject ObjectMass;
    public string Field;
    private hero heroObj;

    // Update is called once per frame
    public void Update()
    {
        // Так как предыдущий объект удаляется при переключении, то ссылка меняется
        // Формирование ссылки на объект не произвести через функцию Start
        heroObj = ObjectMass.GetComponent<SelectHero>().heroObject;
        switch (Field)
        {
            // Необходимо поместить скрипт на нужное текстовое поле
            // После этого ввести параметр, который будет отображаться
            case "name": gameObject.GetComponent<Text>().text = heroObj.name; break;
            case "health": gameObject.GetComponent<Text>().text = heroObj.health.ToString(); break;
            case "costCoins": gameObject.GetComponent<Text>().text = heroObj.costCoins.ToString(); break;
            case "costCrystals": gameObject.GetComponent<Text>().text = heroObj.costCrystals.ToString(); break;
            case "isBought":
                { 
                    if (heroObj.isBought == 0) gameObject.GetComponent<Text>().text = "Not Bought";
                    else gameObject.GetComponent<Text>().text = "Bought";
                }; break;
        }
    }
}