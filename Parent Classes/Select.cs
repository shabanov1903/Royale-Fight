using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Select : MonoBehaviour
{
    public int counter = 0;
    public int maxCount;
    public List<GameObject> objects = new List<GameObject>();

    // �������� � ���������� ���������
    public void OnNext()
    {
        maxCount = objects.Count;
        if (counter + 1 == maxCount) counter = 0;
        else counter++;
        ChangePosition(counter + 1);
    }

    // �������� � ����������� ���������
    public void OnPrew()
    {
        maxCount = objects.Count;
        if (counter - 1 < 0) counter = maxCount - 1;
        else counter--;
        ChangePosition(counter + 1);
    }

    // ������ ������� ������ ���������� ��������� �� ������ ������ � ������������ �����
    // ��������������� � �������� �������
    public abstract void ChangePosition(int id);

    // ������ ������� ������ ��������� ���� ������������ ���������
    // ���� �������� ����������, �� ����� ��������
    public abstract void SelectObject();

    // ������ ������� ���������� ������ ���������� �� �������
    // ����� �������� ���������� ���������� �������� ������ � ������������ �� UI
    public abstract void BuyObjectCoins();

    // ������ ������� ���������� ������ ���������� �� ����������
    // ����� �������� ���������� ���������� �������� ������ � ������������ �� UI
    public abstract void BuyObjectCrystals();
}
