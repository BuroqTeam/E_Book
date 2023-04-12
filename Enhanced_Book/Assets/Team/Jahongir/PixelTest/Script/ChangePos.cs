using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ChangePos : MonoBehaviour
{
    public GameObject Page;
    public GameObject TableOfContentMain;
    public GameObject Vedio1;
    public GameObject Vedio2;
    public bool Big;
    public void ChangePosition()
    {
        GetComponent<RectTransform>().DOScale(1.09f, 0);
        GetComponent<RectTransform>().DOAnchorPosY(24, 0);
    }

    public void ReturnPosition()
    {
        GetComponent<RectTransform>().DOScale(1, 0);
        GetComponent<RectTransform>().DOAnchorPosY(0, 0);
    }

    public void ActiveOrNonactiveGameObj()
    {
        if (Page.GetComponent<Image>().sprite.name == "9-10" && !TableOfContentMain.gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    public void ActiveVedio()
    {
        if (Page.GetComponent<Image>().sprite.name == "15-16")
        {
            Vedio1.gameObject.SetActive(true);
        }
        if (Page.GetComponent<Image>().sprite.name == "19-20")
        {
            Vedio2.gameObject.SetActive(true);
        }
    }



}
