using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class RingSlider : MonoBehaviour
{

    public TMP_Text PercentageText;
    public float MaxVal;
   

    Image _img;
    

    private void Awake()
    {
        _img = GetComponent<Image>();

        
    }

    public void AnimateSlider()
    {
        _img.DOFillAmount(0, 0);
        PercentageText.DOText("", 0);
        _img.DOFillAmount(MaxVal, 1);
        StartCoroutine( DoText());
        //PercentageText.DOText(Val + "%", 1);
    }

    IEnumerator DoText()
    {        
        for (int i = 0; i <= MaxVal * 100; i+=10)
        {
            PercentageText.DOText(i + "%", 0.1f);           
            yield return new WaitForSeconds(0.1f);
        }
        
    }





}
