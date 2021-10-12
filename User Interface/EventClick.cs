using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EventClick : MonoBehaviour, IPointerClickHandler
{

    public UnityEvent EventOnClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        EventOnClick.Invoke();
    }
}