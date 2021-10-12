using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Select : MonoBehaviour
{
    public int counter = 0;
    public int maxCount;
    public List<GameObject> objects = new List<GameObject>();

    // Смещение к следующему персонажу
    public void OnNext()
    {
        maxCount = objects.Count;
        if (counter + 1 == maxCount) counter = 0;
        else counter++;
        ChangePosition(counter + 1);
    }

    // Смещение к предыдущему персонажу
    public void OnPrew()
    {
        maxCount = objects.Count;
        if (counter - 1 < 0) counter = maxCount - 1;
        else counter--;
        ChangePosition(counter + 1);
    }

    // Данная функция должна уничтожать имеющийся на экране объект и генерировать новый
    // Переопределение в дочерних классах
    public abstract void ChangePosition(int id);

    // Данная функция должна проверять факт приобретения персонажа
    // Если персонаж приобретен, то выбор возможен
    public abstract void SelectObject();

    // Данная функция производит запуск транзакции по монетам
    // После успешной транзакции необходимо обновить данные о приобретении на UI
    public abstract void BuyObjectCoins();

    // Данная функция производит запуск транзакции по кристаллам
    // После успешной транзакции необходимо обновить данные о приобретении на UI
    public abstract void BuyObjectCrystals();
}
