using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ZoomOut : MonoBehaviour, IPointerClickHandler
{
    public GameObject Page;
    public GameObject ZoomPanel;

    




    public void OnPointerClick(PointerEventData eventData)
    {
        Page.transform.parent.GetComponent<Image>().enabled = true;
        ZoomPanel.SetActive(false);
        gameObject.SetActive(false);


    }
}
