using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBook : MonoBehaviour
{

    public Image Page;

    Button _button;



    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Page.sprite = GetComponent<Image>().sprite;
    }
}
