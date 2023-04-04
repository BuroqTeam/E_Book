using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class DashbordButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite ActiveButtonSp;
    public Sprite NonActiveButtonSp;
    public int Ball;
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).GetComponent<RectTransform>().DOScale(1.3f, 0.3f);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.GetChild(0).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
    }
}
