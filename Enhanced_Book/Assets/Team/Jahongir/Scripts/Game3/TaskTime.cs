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

    public MMFeedbacks StartFeedback;

    private void Start()
    {
        PresentTime = StartTime;
        time = Convert.ToInt32(StartTime);
        Time.text = StartTime.ToString();
        StartCoroutine(ChangeTime());
        Debug.Log("Start");
    }
    //private void Update()
    //{
    //    StartCoroutine(ChangeTime());
    //    Debug.Log("Update");
    //}
    public IEnumerator ChangeTime()
    {
        Slider.GetComponent<SpriteRenderer>().material.SetFloat("Arc Point 1", 180);
        transform.GetComponent<AudioSource>().enabled = true;
        Time.text = StartTime.ToString();
        for (int i = time * 10; i > 0.1; i--)
        {
            //Slider.GetComponent<SpriteRenderer>().material.SetFloat("_ArcPoint1", 180);

            //Debug.Log("Shader Name: " +  Shader.Find("ArcPoint1").name);


            //Slider.GetComponent<SpriteRenderer>().material.SetFloat("_ArcPoint1", 180);
            //Debug.Log(Slider.GetComponent<SpriteRenderer>().material.shader = Shader.Find("_Arc Point 1"));
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
        
        transform.GetComponent<AudioSource>().enabled = false;
        PresentTime = StartTime;
        
    }
}
