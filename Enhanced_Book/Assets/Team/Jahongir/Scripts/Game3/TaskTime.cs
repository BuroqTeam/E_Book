using MoreMountains.Feedbacks;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskTime : MonoBehaviour
{
    public Game3Controller Game3Control;
    public TMP_Text Time;
    public GameObject Slider;
    public float StartTime;
    public float PresentTime;
    public GameEventSO ToGiveTaskEvent;
    int time;
    public int CircleTime = 360;

    public MMFeedbacks StartFeedback;

    private void Start()
    {
        PresentTime = StartTime;
        time = Convert.ToInt32(StartTime);
        Time.text = StartTime.ToString();
        StartCoroutine(ChangeTime());
    }
    public IEnumerator ChangeTime()
    {
        CircleTime = 360;
        transform.GetComponent<AudioSource>().enabled = true;
        Time.text = StartTime.ToString();
        for (int i = 0; i < time * 10; i++)
        {
            PresentTime = PresentTime - 0.1f;
            Time.text = Math.Round(PresentTime, 1).ToString();
            if (PresentTime < 0)
            {
                transform.gameObject.SetActive(false);
                transform.parent.GetComponent<CardController>().Game3Controller.AddNewCard();
                ToGiveTaskEvent.Raise();
            }
            yield return new WaitForSeconds(0.1f);
        }
        for (int i = 0; i < CircleTime; i++)
        {
            Slider.GetComponent<SpriteRenderer>().material.SetFloat("_Arc1", i);
            if (i == 359)
            {
                Slider.GetComponent<SpriteRenderer>().material.SetFloat("_Arc1", 0);
            }
            yield return new WaitForSeconds(StartTime/360);
        }
        PresentTime = StartTime;
    }
}
