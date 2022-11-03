using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Scaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    


    public void OnPointerEnter(PointerEventData eventData)
    {
        
        transform.DOScale(1.05f, 0.08f);
    }



    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1, 0.08f);
    }
}
