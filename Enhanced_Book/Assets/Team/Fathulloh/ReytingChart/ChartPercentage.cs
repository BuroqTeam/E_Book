using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ReytingPanel
{
    public class ChartPercentage : MonoBehaviour
    {
        public TMP_Text PercentageText;
        public float MaxVal;


        void Start()
        {

        }

        
        public void AnimateSlider()
        {
            PercentageText.DOText("", 0);

            StartCoroutine(DoText());
        }


        IEnumerator DoText()
        {
            for (int i = 0; i <= MaxVal * 100; i += 10)
            {
                PercentageText.DOText(i + "%", 0.1f);
                yield return new WaitForSeconds(0.1f);
            }
        }


    }
}
