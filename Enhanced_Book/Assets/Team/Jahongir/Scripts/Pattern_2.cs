using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_2 : MonoBehaviour
{
    public GameObject ButtonPrefab;
    public GameObject LevelConroller;
    public GameObject NextButton;
    public TMP_Text LevelId;
    public TMP_Text Question;
    public GameObject ResultPanel;
    public GameObject CorrectIcon;
    public GameObject WrongIcon;
    public Sprite Badge1;
    public Sprite Badge2;
    public Sprite Badge3;
    public Sprite Lose;
    public Sprite FinishButton;
    public List<string> Answers = new();
    public List<string> Answer1 = new();
    public List<bool> Result = new();
    public List<GameObject> Buttons = new();
    private int t;
    private void Start()
    {
        t = Convert.ToInt32(LevelId);
        CreatePattern();
    }


    public void CreatePattern()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject button = Instantiate(ButtonPrefab, transform.GetChild(0).transform);
            button.GetComponent<ButtonControl_P2>().Pattern2 = this;
            button.transform.GetChild(0).GetComponent<TMP_Text>().text = Answer1[(t - 1) * 8 + i];
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
            Buttons.Clear();
        }
        if (t-1<Answers.Count)
        {
            LevelId.SetText((t).ToString());
            if (Question.GetComponent<TMP_Text>().text.Contains(Answers[t-2]))
            {
                Question.GetComponent<TMP_Text>().text = Question.GetComponent<TMP_Text>().text.Replace(Answers[t - 2], Answers[t-1]);
            }
            if (t == 6)
            {
                NextButton.GetComponent<Image>().sprite = FinishButton;
                NextButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Yakunlash";
            }
            LevelConroller.GetComponent<LevelController>().ChangeCircle();
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
        if (correct * 100/6 >= 90 && correct * 100 / 6 <= 100)
        {
            ResultPanel.GetComponent<ResultController>().Badge.GetComponent<Image>().sprite = Badge1;
            Debug.Log("3");
        }
        else if (correct * 100 / 6 >= 70 && correct * 100 / 6 < 90)
        {
            ResultPanel.GetComponent<ResultController>().Badge.GetComponent<Image>().sprite = Badge2;
            Debug.Log("2");
        }
        else if(correct * 100 / 6 >= 50 && correct * 100 / 6 < 70)
        {
            ResultPanel.GetComponent<ResultController>().Badge.GetComponent<Image>().sprite = Badge3;
            Debug.Log("1");
        }
        else
        {
            ResultPanel.GetComponent<ResultController>().Badge.GetComponent<Image>().sprite = Lose;
        }
    }

    public void LoadLocalScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Quiz 2");
    }
}
