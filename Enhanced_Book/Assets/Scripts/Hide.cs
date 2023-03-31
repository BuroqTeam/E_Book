using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using DG.Tweening;

public class Hide : MonoBehaviour
{
    public RectTransform Book;
    public Sprite MarkedSp;
    public Sprite UnMurkedSp;
    public UnityEvent HideEvent;
    public UnityEvent ShowEvent;
    public GameObject ZoomInZoomOut;


    RectTransform _rect;
    int _count = 0;
    Button _button;


    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Mark);


    }




    public void Mark()
    {
        _count++;
        if (_count % 2 == 0)
        {
            ZoomInZoomOut.GetComponent<ChangePos>().Big = false;
            transform.GetChild(0).GetComponent<Image>().sprite = MarkedSp;
            ShowEvent.Invoke();
            Book.DOAnchorPosY(-10, 0);
            Book.DOSizeDelta(new Vector2(578, 378), 0.2f);
        }
        else
        {
            ZoomInZoomOut.GetComponent<ChangePos>().Big = true;
            transform.GetChild(0).GetComponent<Image>().sprite = UnMurkedSp;
            HideEvent.Invoke();
            Book.DOAnchorPosY(13, 0);
            Book.DOSizeDelta(new Vector2(634, 416), 0.2f);
        }
        

    }
}
