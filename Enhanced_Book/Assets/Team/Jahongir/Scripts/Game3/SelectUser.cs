using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SelectUser : MonoBehaviour
{
    public bool OneUser;
    public bool TwoUser;

    [Header("Objects")]
    public GameObject Canvas;
    public GameObject User1;
    public GameObject User2;
    public GameObject User1Manager;
    public GameObject OneSelectImage;
    public GameObject TwoSelectImage;
    public GameObject StartButton;



    public void OneUserSelect()
    {
        if (TwoSelectImage.GetComponent<Image>().enabled)
        {
            TwoSelectImage.GetComponent<Image>().enabled = false;
            OneSelectImage.GetComponent<Image>().enabled = true;
        }
        else
        {
            OneSelectImage.GetComponent<Image>().enabled = true;
        }
        OneUser = true;
        TwoUser = false;
    }

    public void TwoUserSelect()
    {
        if (OneSelectImage.GetComponent<Image>().enabled)
        {
            OneSelectImage.GetComponent<Image>().enabled = false;
            TwoSelectImage.GetComponent<Image>().enabled = true;
        }
        else
        {
            TwoSelectImage.GetComponent<Image>().enabled = true;
        }
        OneUser = false;
        TwoUser = true;
    }

    public void GoGame()
    {
        StartCoroutine(AnimButton());
    }
    public IEnumerator AnimButton()
    {
        StartButton.GetComponent<RectTransform>().DOScale(0.7f, 0.1f);
        yield return new WaitForSeconds(0.1f);
        StartButton.GetComponent<RectTransform>().DOScale(1f, 0.1f);
        yield return new WaitForSeconds(0.25f);
        Canvas.GetComponent<Canvas>().sortingOrder = 11;
        Canvas.transform.GetChild(0).gameObject.SetActive(true);
        Canvas.transform.GetChild(1).gameObject.SetActive(true);
        if (OneUser)
        {
            User1Manager.SetActive(true);
        }
        else if (TwoUser)
        {
            User1.SetActive(false);
            User2.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}
