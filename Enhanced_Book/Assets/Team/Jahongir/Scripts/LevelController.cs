using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public List<float> ChangeNumbers = new();
    public TMP_Text LevelId;
    public GameObject First;
    public GameObject Second;
    public GameObject Third;
    private int _first;
    private int _second;
    private void Start()
    {
        _first = Convert.ToInt32(LevelId) - 1;
        _second = 5 - (Convert.ToInt32(LevelId));
        ChangeCircle();
    }

    public void ChangeCircle()
    {
        if (_first == 5)
        {
            First.GetComponent<Image>().DOFillAmount(1, 0);
            Third.GetComponent<Image>().DOFillAmount(0, 0);
        }
        else
        {
            First.GetComponent<Image>().DOFillAmount(ChangeNumbers[_first], 0);
            Third.GetComponent<Image>().DOFillAmount(ChangeNumbers[_second], 0);
            _first++;
            _second--;
        }
    }
}
