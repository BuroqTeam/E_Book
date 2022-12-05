using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{

    public Button OppositeButton;
    public Color brown;

    Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(TaskOnClick);
    }


    void TaskOnClick()
    {
        OppositeButton.GetComponent<Image>().DOFade(0, 0);
        OppositeButton.transform.GetChild(0).GetComponent<TMP_Text>().color = brown;
        _button.GetComponent<Image>().DOFade(1, 0);
        _button.transform.GetChild(0).GetComponent<TMP_Text>().color = Color.white;

    }

   
}
