using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerCount : MonoBehaviour
{
    public float allAmountOfTime;
    public TMP_Text timeText;

    private void Update()
    {
        allAmountOfTime += Time.deltaTime;
    }


    public void Finish()
    {
        float allAmount = allAmountOfTime;
        int min = (int)allAmount / 60;
        int second = (int)allAmount % 60;
        timeText.text = GetFinalTime(min) + ":" + GetFinalTime(second);
    }

    public string GetFinalTime(int val)
    {
        if (val / 10 > 0)
        {
            return val.ToString();
        }
        else
        {
            return "0" + val.ToString();
        }
    }
}
