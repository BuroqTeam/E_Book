using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ScaleableButton : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{

    public Sprite On;
    public Sprite Off;

    public void SetOn()
    {
        transform.GetChild(0).GetComponent<Image>().sprite = On;
        
    }


    public void SetOff()
    {
        transform.GetChild(0).GetComponent<Image>().sprite = Off;
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetOn();
        StartCoroutine(ScaleAnim());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetOff();
        StartCoroutine(ScaleAnim());
    }

   

   




    IEnumerator ScaleAnim()
    {
        transform.GetChild(0).transform.DOScale(0.7f, 0.2f);
        yield return new WaitForSeconds(0.2f);
        transform.GetChild(0).transform.DOScale(1, 0.2f);
        yield return new WaitForSeconds(0.2f);

    }
}
