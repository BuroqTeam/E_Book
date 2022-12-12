using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Pattern_1 : MonoBehaviour
{
    public GameObject ButtonsPrefabs;
    public GameObject LevelConroller;
    public GameObject NextButton;
    public GameObject ResultPanel;
    public GameObject CorrectIcon;
    public GameObject WrongIcon;
    public TMP_Text Question;
    public Sprite Badge1;
    public Sprite Badge2;
    public Sprite Badge3;
    public Sprite Lose;
    public Sprite FinishButton;
    public List<string> Questions = new();
    public List<string> Answers = new();
    public List<bool> Result = new();
    public TMP_Text LevelId;
    private int t;
    int a = 0;
    private void Start()
    {
        t = Convert.ToInt32(LevelId);
        CreatePattern();
    }

    public void CreatePattern()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = Questions[t-1];
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
        a = 0;
        for (int i = 0; i < 2; i++)
        {
            if (transform.GetChild(1).GetChild(i).GetComponent<ButtonControl_1>().Select && transform.GetChild(1).GetChild(i).GetComponent<ButtonControl_1>().Answer)
            {
                a++;
            }
        }
        if (a == 1)
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
        Destroy(transform.GetChild(1).gameObject);
        if (t-1 < Answers.Count)
        {
            LevelId.SetText((t).ToString());
            Question.GetComponent<TMP_Text>().text = Questions[t - 1];
            if (t == 6)
            {
                NextButton.GetComponent<Image>().sprite = FinishButton;
                NextButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Yakunlash";
            }
            CreatePattern();
            LevelConroller.GetComponent<LevelController>().ChangeCircle();
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
        if (correct * 100 / 6 >= 90 && correct * 100 / 6 <= 100)
        {
            ResultPanel.GetComponent<ResultController>().Badge.GetComponent<Image>().sprite = Badge1;
            Debug.Log("3");
        }
        else if (correct * 100 / 6 >= 70 && correct * 100 / 6 < 90)
        {
            ResultPanel.GetComponent<ResultController>().Badge.GetComponent<Image>().sprite = Badge2;
            Debug.Log("2");
        }
        else if (correct * 100 / 6 >= 50 && correct * 100 / 6 < 70)
        {
            ResultPanel.GetComponent<ResultController>().Badge.GetComponent<Image>().sprite = Badge1;
            Debug.Log("1");
        }
        else
        {
            ResultPanel.GetComponent<ResultController>().Badge.GetComponent<Image>().sprite = Lose;
        }
    }

    public void LoadLocalScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Quiz 1");
    }
}
