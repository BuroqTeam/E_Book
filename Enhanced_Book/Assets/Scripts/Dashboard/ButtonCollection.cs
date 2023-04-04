using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonCollection : MonoBehaviour
{
    public GameObject LastButton;
    public GameObject NextButton;
    public void BandsLocation()
    {
        Vector3 a = new Vector3(140, -9, 0);
        for (int i = 0; i < 5; i++)
        {
            if (transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition.x == -140)
            {
                transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition = a;
                Debug.Log(transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition.x);
            }
        }
    }
    public void LasButton()
    {
        StartCoroutine(Last());
        //transform.GetChild(6).GetComponent<Button>().enabled = false;
        //Vector3 a = new Vector3(100, -9, 0);
        //for (int i = 0; i < 5; i++)
        //{
        //    if ((transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition.x * -1f) == 100f)
        //    {
        //        transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPosX(100f, 0f);
        //    }
        //}
        //for (int i = 0; i < 5; i++)
        //{
        //    transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPosX(transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition.x - 40, 0.3f);
        //}
    }
    public IEnumerator Last()
    {
        LastButton.GetComponent<Button>().enabled = false;
        for (int i = 0; i < 6; i++)
        {
            transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPosX(transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition.x - 40f, 0.2f);
        }
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < 5; i++)
        {
            if ((transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition.x * -1f) > 130f)
            {
                transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPosX(100f, 0f);
            }
        }
        yield return new WaitForSeconds(0.1f);
        LastButton.GetComponent<Button>().enabled = true;
    }

}
