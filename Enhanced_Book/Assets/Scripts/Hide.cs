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
            transform.GetChild(0).GetComponent<Image>().sprite = MarkedSp;
            ShowEvent.Invoke();
            Book.DOAnchorPosY(-40, 0);
            Book.DOSizeDelta(new Vector2(594.6f, 424.7f), 0.2f);
        }
        else
        {
            transform.GetChild(0).GetComponent<Image>().sprite = UnMurkedSp;
            HideEvent.Invoke();
            Book.DOAnchorPosY(0, 0);
            Book.DOSizeDelta(new Vector2(755, 515), 0.2f);
        }
        

    }
}
