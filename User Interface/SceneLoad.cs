using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour, IPointerClickHandler
{
    public string Scene;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(Scene);
    }
}