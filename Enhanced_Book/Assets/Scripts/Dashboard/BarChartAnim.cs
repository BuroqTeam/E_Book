using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarChartAnim : MonoBehaviour
{
    public GameObject BarChart;
    public TMP_Text Days;

    
    private void OnEnable()
    {
        StartCoroutine(AnimBarChart());
        StartCoroutine(AnimPageNumber());
    }


    public IEnumerator AnimBarChart()
    {
        BarChart.GetComponent<Image>().fillAmount = 0;
        for (int i = 0; i < 60; i++)
        {
            BarChart.GetComponent<Image>().fillAmount += 0.01f;
            yield return new WaitForSeconds(0.015f);
        }
    }

    public IEnumerator AnimPageNumber()
    {
        Days.GetComponent<TMP_Text>().text = "0";
        for (int i = 0; i < 188; i++)
        {
            Days.GetComponent<TMP_Text>().text = i.ToString() + " kun";
            yield return new WaitForSeconds(0.003f);
        }
    }
}
