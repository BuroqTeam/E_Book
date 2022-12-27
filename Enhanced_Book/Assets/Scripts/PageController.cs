using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PageController : MonoBehaviour
{
    public GameObject Video_1;
    public GameObject Video_2;


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
            if (Pages[index].name.Equals("15-16"))
            {
                Video_1.SetActive(true);
                Video_2.SetActive(false);
            }
            else if (Pages[index].name.Equals("19-20"))
            {
                Video_1.SetActive(false);
                Video_2.SetActive(true);
            }
            else
            {
                Video_1.SetActive(false);
                Video_2.SetActive(false);
            }
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
            if (Pages[index].name.Equals("15-16"))
            {
                Video_1.SetActive(true);
                Video_2.SetActive(false);
            }
            else if (Pages[index].name.Equals("19-20"))
            {
                Video_1.SetActive(false);
                Video_2.SetActive(true);
            }
            else
            {
                Video_1.SetActive(false);
                Video_2.SetActive(false);
            }
            _rect.DOAnchorPosX(710, 0.3f);
            yield return new WaitForSeconds(0.3f);
            _rect.DOAnchorPosX(0, 0);
        }       
    }

   

}
