using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FinResultButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Sprite Active;
    public Sprite NonActive;
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<RectTransform>().DOScale(1.15f, 0.3f);
        GetComponent<Image>().sprite = Active;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<RectTransform>().DOScale(1f, 0.3f);
        GetComponent<Image>().sprite = NonActive;
    }
}
