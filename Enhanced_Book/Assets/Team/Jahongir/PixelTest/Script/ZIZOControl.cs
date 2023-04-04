using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ZIZOControl : MonoBehaviour, IPointerClickHandler
{
    public GameObject Book;
    public bool Select = false;
    private float _bookLastPosx;
    private float _bookLastPosy;
    private float _lastPosx;
    private float _lastPosy;

    [Header("Objects")]
    public GameObject MediaPanel;
    public GameObject Account;
    public GameObject TopMenu;
    public GameObject LeftMenu;
    public GameObject Mark;
    public GameObject RightCorner;
    public GameObject Help;
    private void Start()
    {
        _bookLastPosx = Book.GetComponent<RectTransform>().localPosition.x;
        _bookLastPosy = Book.GetComponent<RectTransform>().localPosition.y;
        _lastPosx = GetComponent<RectTransform>().localPosition.x;
        _lastPosy = GetComponent<RectTransform>().localPosition.y;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (transform.parent.GetComponent<ChangePos>().Big)
        {
            if (!Select)
            {
                StartCoroutine(ZoomInMark());
            }
            else
            {
                StartCoroutine(ZoomOutMark());
            }
        }
        else
        {
            if (!Select)
            {
                StartCoroutine(ZoomIn());
            }
            else
            {
                StartCoroutine(ZoomOut());
            }
        }
    }

    public IEnumerator ZoomIn()
    {
        MediaPanel.SetActive(false);
        Account.SetActive(false);
        TopMenu.SetActive(false);
        LeftMenu.SetActive(false);
        Mark.SetActive(false);
        RightCorner.SetActive(false);
        Help.SetActive(false);
        Book.GetComponent<RectTransform>().DOScale(2.5f, 0.5f);
        GetComponent<RectTransform>().DOScale(2.5f, 0.5f);
        Book.GetComponent<RectTransform>().DOAnchorPosX(-1 * _lastPosx * 2.5f, 0.5f);
        Book.GetComponent<RectTransform>().DOAnchorPosY((-1 * _lastPosy * 2.5f) + _bookLastPosy, 0.5f);
        GetComponent<RectTransform>().DOAnchorPosX(0, 0.5f);
        GetComponent<RectTransform>().DOAnchorPosY(15, 0.5f);
        Select = true;
        yield return new WaitForSeconds(0);
        for (int i = 0; i < transform.parent.transform.childCount; i++)
        {
            if (!transform.parent.transform.GetChild(i).GetComponent<ZIZOControl>().Select)
            {
                transform.parent.transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = false;
            }
        }

    }

    public IEnumerator ZoomOut()
    {
        Debug.Log("Man ishladim");
        GetComponent<RectTransform>().DOAnchorPosX(_lastPosx, 0.5f);
        GetComponent<RectTransform>().DOAnchorPosY(_lastPosy, 0.5f);
        Book.GetComponent<RectTransform>().DOScale(1f, 0.5f);
        GetComponent<RectTransform>().DOScale(1f, 0.5f);
        Book.GetComponent<RectTransform>().DOAnchorPosX(0, 0.5f);
        Book.GetComponent<RectTransform>().DOAnchorPosY(_bookLastPosy, 0.5f);
        Select = false;
        yield return new WaitForSeconds(0.4f);
        MediaPanel.SetActive(true);
        Account.SetActive(true);
        TopMenu.SetActive(true);
        LeftMenu.SetActive(true);
        Mark.SetActive(true);
        RightCorner.SetActive(true);
        Help.SetActive(true);
        for (int i = 0; i < transform.parent.transform.childCount; i++)
        {
            transform.parent.transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = true;
        }
        
    }

    public IEnumerator ZoomInMark()
    {
        transform.parent.GetComponent<RectTransform>().DOScale(1, 0);
        transform.parent.GetComponent<RectTransform>().DOAnchorPosY(0, 0);
        Book.GetComponent<RectTransform>().DOAnchorPosY(-10, 0);
        Book.GetComponent<RectTransform>().DOSizeDelta(new Vector2(578, 378), 0.2f);
        MediaPanel.SetActive(false);
        LeftMenu.SetActive(false);
        Mark.SetActive(false);
        RightCorner.SetActive(false);
        Book.GetComponent<RectTransform>().DOScale(2.5f, 0.5f);
        GetComponent<RectTransform>().DOScale(2.5f, 0.5f);
        Book.GetComponent<RectTransform>().DOAnchorPosX(-1 * _lastPosx * 2.5f, 0.5f);
        Book.GetComponent<RectTransform>().DOAnchorPosY((-1 * _lastPosy * 2.5f) + _bookLastPosy, 0.5f);
        GetComponent<RectTransform>().DOAnchorPosX(0, 0.5f);
        GetComponent<RectTransform>().DOAnchorPosY(15, 0.5f);
        Select = true;
        yield return new WaitForSeconds(0);
        for (int i = 0; i < transform.parent.transform.childCount; i++)
        {
            if (!transform.parent.transform.GetChild(i).GetComponent<ZIZOControl>().Select)
            {
                transform.parent.transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = false;
            }
        }

    }

    public IEnumerator ZoomOutMark()
    {
        GetComponent<RectTransform>().DOAnchorPosX(_lastPosx, 0.5f);
        GetComponent<RectTransform>().DOAnchorPosY(_lastPosy, 0.5f);
        Book.GetComponent<RectTransform>().DOScale(1f, 0.5f);
        GetComponent<RectTransform>().DOScale(1f, 0.5f);
        Book.GetComponent<RectTransform>().DOAnchorPosX(0, 0.5f);
        Book.GetComponent<RectTransform>().DOAnchorPosY(13, 0.5f);
        Book.GetComponent<RectTransform>().DOSizeDelta(new Vector2(634, 416), 0.2f);
        transform.parent.GetComponent<RectTransform>().DOScale(1.09f, 0);
        transform.parent.GetComponent<RectTransform>().DOAnchorPosY(24, 0);
        Select = false;
        yield return new WaitForSeconds(0.4f);
        MediaPanel.SetActive(true);
        LeftMenu.SetActive(true);
        Mark.SetActive(true);
        RightCorner.SetActive(true);
        for (int i = 0; i < transform.parent.transform.childCount; i++)
        {
            transform.parent.transform.GetChild(i).GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
