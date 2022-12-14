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
        if (_pageIndex < Pages.Count - 1)
        {
            _pageIndex++;
            _image.sprite = Pages[_pageIndex];
            _rect.DOAnchorPosX(-710, 0.3f);
            yield return new WaitForSeconds(0.3f);
            _rect.DOAnchorPosX(0, 0);
        }
        
        
    }

    IEnumerator MoveLeft()
    {
        if (_pageIndex > 0)
        {
            _pageIndex--;
            _image.sprite = Pages[_pageIndex];
            _rect.DOAnchorPosX(710, 0.3f);
            yield return new WaitForSeconds(0.3f);
            _rect.DOAnchorPosX(0, 0);
        }
       
    }

   

}
