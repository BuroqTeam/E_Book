using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ScaleableButton : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{

    public Sprite On;
    public Sprite Off;
    RectTransform _title;


    private void Awake()
    {
        _title = transform.GetChild(0).GetComponent<RectTransform>();
    }

    public void SetOn()
    {
        transform.GetChild(1).GetComponent<Image>().sprite = On;
        
    }


    public void SetOff()
    {
        transform.GetChild(1).GetComponent<Image>().sprite = Off;
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetOn();
        StartCoroutine(ScaleAnim());
        _title.DOAnchorPosX(-25, 0.4f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetOff();
        StartCoroutine(ScaleAnim());
        _title.DOAnchorPosX(4, 0.4f);
    }

   

   




    IEnumerator ScaleAnim()
    {
        transform.GetChild(1).transform.DOScale(0.5f, 0.2f);        
        yield return new WaitForSeconds(0.2f);
        transform.GetChild(1).transform.DOScale(1, 0.2f);
        yield return new WaitForSeconds(0.2f);

    }
}
