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
        // Загрузка синглтона
        // var playerSingletone = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerSingletone>();
        var playerSingletone = PlayerSingletone.Instance;

        // Загрузка сцены с соответствующим номером
        SceneManager.LoadScene($"Level {playerSingletone.player.level + 1}");
    }
}