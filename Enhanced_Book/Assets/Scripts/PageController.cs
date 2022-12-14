using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PageController : MonoBehaviour
{

    public List<Sprite> Pages;

    RectTransform _rect;
    Image _image;
    int _pageIndex;


    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
    }

    public void RightClick()
    {
        StartCoroutine(MoveRight());        
    }

    public void LeftClick()
    {
        StartCoroutine(MoveLeft());
    }

    IEnumerator MoveRight()
    {
        _rect.DOAnchorPosX(-710, 0.5f);
        yield return new WaitForSeconds(0.5f);
        _rect.DOAnchorPosX(0, 0);
        IncrementPageIndex();
    }

    IEnumerator MoveLeft()
    {
        _rect.DOAnchorPosX(710, 0.5f);
        yield return new WaitForSeconds(0.5f);
        _rect.DOAnchorPosX(0, 0);
        DecrementPageIndex();
    }

    void IncrementPageIndex()
    {
        if (_pageIndex < Pages.Count - 1)
        {
            _pageIndex++;
            _image.sprite = Pages[_pageIndex];
        }        
    }


    void DecrementPageIndex()
    {
        if (_pageIndex > 0)
        {
            _pageIndex--;
            _image.sprite = Pages[_pageIndex];
        }

    }


}
