using MoreMountains.Feedbacks;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskTime : MonoBehaviour
{
    public TMP_Text Time;
    public GameObject Slider;
    public float StartTime;
    int time;

    public MMFeedbacks StartFeedback;

    private void Start()
    {
        time = Convert.ToInt32(StartTime);
        Time.text = StartTime.ToString();
        StartCoroutine(ChangeTime());
    }

    public IEnumerator ChangeTime()
    {
        for (int i = time * 10; i > 0.1; i--)
        {
            Slider.GetComponent<SpriteRenderer>().material.SetFloat("_ArcPoint1", 180);
            StartTime = StartTime - 0.1f;

            Time.text = Math.Round(StartTime, 1).ToString();
            if (StartTime < 0)
            {
                transform.gameObject.SetActive(false);
                transform.parent.GetComponent<CardController>().Game3Controller.AddNewCard();
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
