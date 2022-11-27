using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pattern_2 : MonoBehaviour
{
    public GameObject ButtonPrefab;
    public TMP_Text LevelId;
    public TMP_Text Question;
    public List<string> Answers = new();
    public List<string> Answer1 = new();
    public List<bool> Result = new();
    public List<GameObject> Buttons = new();
    private int t;
    private void Start()
    {
        t = Convert.ToInt32(LevelId);
        CreatePttern();
    }


    public void CreatePttern()
    {
        for (int i = 0; i < 12; i++)
        {
            GameObject button = Instantiate(ButtonPrefab, transform.GetChild(0).transform);
            button.GetComponent<ButtonControl_P2>().Pattern2 = this;
            button.transform.GetChild(0).GetComponent<TMP_Text>().text = Answer1[(t - 1) * 12 + i];
            Buttons.Add(button);
        }
    }

    public void Check()
    {
        int a = 0; 
        int b = 0;
        for (int i = 0; i < Buttons.Count; i++)
        {
            if (Buttons[i].GetComponent<ButtonControl_P2>().Answer)
            {
                b++;
            }
            if (Buttons[i].GetComponent<ButtonControl_P2>().Select && Buttons[i].GetComponent<ButtonControl_P2>().Answer)
            {
                a++;
            }
        }
    }

    public void ResultControl()
    {
        int a = 0;
        int b = 0;
        for (int i = 0; i < Buttons.Count; i++)
        {
            if (Buttons[i].GetComponent<ButtonControl_P2>().Answer)
            {
                b++;
            }
            if (Buttons[i].GetComponent<ButtonControl_P2>().Select && Buttons[i].GetComponent<ButtonControl_P2>().Answer)
            {
                a++;
            }
        }
        if (a == b)
        {
            Result[t - 1] = true;
            Debug.Log("True");
        }
        else
        {
            Result[t - 1] = false;
            Debug.Log("False");
        }
    }

    public void Next()
    {
        ResultControl();
        t++;
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            Destroy(transform.GetChild(0).GetChild(i).gameObject);
            Buttons.Clear();
        }
        if (Convert.ToInt32(LevelId)<6)
        {
            LevelId.SetText((t).ToString());
            if (Question.GetComponent<TMP_Text>().text.Contains(Answers[t-2]))
            {
                Question.GetComponent<TMP_Text>().text = Question.GetComponent<TMP_Text>().text.Replace(Answers[t - 2], Answers[t-1]);
            }
            CreatePttern();
        }

        
    }
}
