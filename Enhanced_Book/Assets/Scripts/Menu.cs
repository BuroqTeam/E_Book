using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class Menu : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{

    public Sprite On;
    public Sprite Off;
    public Color ColorOn;
    public Color ColorOff;

    TMP_Text _title;

    private void Awake()
    {
        _title = transform.GetChild(0).GetComponent<TMP_Text>();
    }


    public void SetOn()
    {
        GetComponent<Image>().sprite = On;
        _title.color = ColorOn;
    }


    public void SetOff()
    {
        GetComponent<Image>().sprite = Off;
        _title.color = ColorOff;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<RectTransform>().DOScale(1.1f, 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<RectTransform>().DOScale(1, 0.2f);
    }


}
