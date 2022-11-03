using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CursorTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public AudioClip OnHover;
    public AudioClip OnClick;

    


    private void Awake()
    {
        
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit");
    }
}
