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
    


    private void Awake()
    {
        _rect = transform.GetChild(0).GetComponent<RectTransform>();
        _image = transform.GetChild(0).GetComponent<Image>();
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
        int index = Pages.FindIndex(x => x == _image.sprite);

        if (index < Pages.Count - 1)
        {
            index++;
            _image.sprite = Pages[index];
            _rect.DOAnchorPosX(-710, 0.3f);
            yield return new WaitForSeconds(0.3f);
            _rect.DOAnchorPosX(0, 0);
        }         
    }

    IEnumerator MoveLeft()
    {
        int index = Pages.FindIndex(x => x == _image.sprite);
        if (index > 0)
        {
            index--;
            _image.sprite = Pages[index];
            _rect.DOAnchorPosX(710, 0.3f);
            yield return new WaitForSeconds(0.3f);
            _rect.DOAnchorPosX(0, 0);
        }       
    }

   

}
