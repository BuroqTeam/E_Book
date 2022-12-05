using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pattern_1 : MonoBehaviour
{
    public GameObject ButtonsPrefabs;
    public GameObject ResultPanel;
    public GameObject CorrectIcon;
    public GameObject WrongIcon;
    public TMP_Text Question;
    public List<string> Questions = new();
    public List<string> Answers = new();
    public List<bool> Result = new();
    public TMP_Text LevelId;
    private int t;
    private void Start()
    {
        t = Convert.ToInt32(LevelId);
        CreatePattern();
    }

    public void CreatePattern()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = Questions[t];
        GameObject button = Instantiate(ButtonsPrefabs, transform);
        for (int i = 0; i < 2; i++)
        {
            button.transform.GetChild(i).GetComponent<ButtonControl_1>().Pattern1 = this;
        }
        if (Answers[t-1] == "[*]To‘g‘ri")
        {
            button.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = Answers[t - 1];
        }
        else
        {
            button.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = Answers[t - 1];
        }
    }

    public void ResultControl()
    {
        int a = 0;
        int b = 0;
        //for (int i = 0; i < 2; i++)
        //{
        //    //ButtonsPrefabs.transform.GetChild(i).


        //}
        if (a == b)
        {
            Result[t - 1] = true;
        }
        else
        {
            Result[t - 1] = false;
        }

    }

    public void Next()
    {
        ResultControl();
        t++;
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            Destroy(transform.GetChild(0).GetChild(i).gameObject);
        }
        if (t - 1 < Answers.Count)
        {
            LevelId.SetText((t).ToString());
            if (Question.GetComponent<TMP_Text>().text.Contains(Answers[t - 2]))
            {
                Question.GetComponent<TMP_Text>().text = Question.GetComponent<TMP_Text>().text.Replace(Answers[t - 2], Answers[t - 1]);
            }
            CreatePattern();
        }
        else
        {
            ResultPanelControl();
        }
    }

    public void ResultPanelControl()
    {
        int correct = 0;
        int wrong = 0;
        ResultPanel.SetActive(true);
        for (int i = 0; i < Result.Count; i++)
        {
            if (Result[i])
            {
                correct++;
                Instantiate(CorrectIcon, ResultPanel.GetComponent<ResultController>().LevelIcons.transform);
            }
            else
            {
                wrong++;
                Instantiate(WrongIcon, ResultPanel.GetComponent<ResultController>().LevelIcons.transform);
            }
        }
        ResultPanel.GetComponent<ResultController>().CorrectNumber.SetText((correct).ToString());
        ResultPanel.GetComponent<ResultController>().WrongNumber.SetText((wrong).ToString());
        ResultPanel.GetComponent<ResultController>().Percentage.SetText((correct * 100 / Answers.Count).ToString());
    }

    public void LoadLocalScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Quiz");
    }
}
