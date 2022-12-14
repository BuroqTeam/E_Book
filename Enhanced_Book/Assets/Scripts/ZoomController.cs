using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class ZoomController : MonoBehaviour, IPointerClickHandler
{
    public GameObject Page;
    public GameObject ZoomPanel;



   



    public void OnPointerClick(PointerEventData eventData)
    {

        transform.parent.gameObject.GetComponent<Image>().enabled = false;
        ZoomPanel.SetActive(true);
        Page.SetActive(true);
        


    }
}
