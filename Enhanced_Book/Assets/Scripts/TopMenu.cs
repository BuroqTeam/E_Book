using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TopMenu : MonoBehaviour
{

    RectTransform _rect;
    int _count = 0;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();


    }

    public void DecreaseSize()
    {
        _rect.DOSizeDelta(new Vector2(182, -33), 1, true);
    }

    public void ExtendSize()
    {
        //_rect.DOSizeDelta(new Vector2(130, -33), 1, false);
        _count++;
        if (_count % 2 == 0)
        {
            _rect.SetLeft(182);
        }
        else
        {
            _rect.SetLeft(40);
        }
        

    }

   
}

