using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // �������� ���������
        // var playerSingletone = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerSingletone>();
        var playerSingletone = PlayerSingletone.Instance;

        // �������� ����� � ��������������� �������
        SceneManager.LoadScene($"Level {playerSingletone.player.level + 1}");
    }
}