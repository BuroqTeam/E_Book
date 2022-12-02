using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marked : MonoBehaviour
{
    public Sprite MarkedSp;
    public Sprite UnMurkedSp;

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
        if (_count % 2 == 0)
        {
            GetComponent<Image>().sprite = MarkedSp;
        }
        else
        {
            GetComponent<Image>().sprite = UnMurkedSp;
        }
        _count++;

    }
}
