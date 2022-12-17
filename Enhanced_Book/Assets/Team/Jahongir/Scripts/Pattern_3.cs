using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_3 : MonoBehaviour
{
    public GameObject PuzzleQuestion;
    public GameObject PuzzleAnswer;
    public GameObject LevelConroller;
    public GameObject NextButton;
    public GameObject ResultPanel;
    public GameObject CorrectIcon;
    public GameObject WrongIcon;
    public Sprite Badge1;
    public Sprite Badge2;
    public Sprite Badge3;
    public Sprite Lose;
    public Sprite FinishButton;
    public TMP_Text LevelId;
    public List<GameObject> QuestionPuzles = new();
    public List<GameObject> AnswerPuzles = new();
    public List<GameObject> SelectedPuzles = new();
    public List<string> Question = new();
    public List<string> Answer = new();
    public List<bool> Result = new();
    private int _resultNumber = 0;
    private int t;
    // Start is called before the first frame update
    void Start()
    {
        t = Convert.ToInt32(LevelId);
        CreatePrefabs();
    }

    public void CreatePrefabs()
    {
        NextButton.SetActive(false);
        for (int i = 0; i < 3; i++)
        {
            if (!transform.GetChild(0).GetComponent<VerticalLayoutGroup>().enabled)
            {
                transform.GetChild(0).GetComponent<VerticalLayoutGroup>().enabled = true;
            }
            GameObject puzzle = Instantiate(PuzzleQuestion, transform.GetChild(0));
            puzzle.GetComponent<P3_Puzzle1>().QuestionId = Question[(t - 1) * 3 + i].Remove(3, Question[(t - 1) * 3 + i].Length - 3);
            puzzle.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = Question[(t - 1) * 3 + i].Remove(0, 3);
            puzzle.GetComponent<P3_Puzzle1>().Pattern3 = this;
            QuestionPuzles.Add(puzzle);
            GameObject puzzle1 = Instantiate(PuzzleAnswer, transform.GetChild(1));
            puzzle1.GetComponent<P3_Puzzle2>().AnswerId = Answer[(t - 1) * 3 + i].Remove(3, Answer[(t - 1) * 3 + i].Length - 3);
            puzzle1.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = Answer[(t - 1) * 3 + i].Remove(0, 3);
            AnswerPuzles.Add(puzzle1);
        }
    }

    public void ResultControl()
    {
        if (SelectedPuzles.Count == AnswerPuzles.Count)
        {
            for (int i = 0; i < QuestionPuzles.Count; i++)
            {
                if (QuestionPuzles[i].GetComponent<P3_Puzzle1>().QuestionId == QuestionPuzles[i].GetComponent<P3_Puzzle1>().AttechedPuzzle.GetComponent<P3_Puzzle2>().AnswerId)
                {
                    _resultNumber++;
                }
            }
            if (_resultNumber == QuestionPuzles.Count)
            {
                Result[t - 1] = true;
            }
            else
            {
                Result[t - 1] = false;
            }
        }
        else
        {
            Result[t - 1] = false;
        }
        _resultNumber = 0;
    }
    
    public void Next()
    {
        ResultControl();
        t++;
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            Destroy(transform.GetChild(0).GetChild(i).gameObject);
            Destroy(transform.GetChild(1).GetChild(i).gameObject);
        }
        QuestionPuzles.Clear();
        AnswerPuzles.Clear();
        SelectedPuzles.Clear();
        if (t-1<6)
        {
            LevelId.SetText((t).ToString());
            LevelConroller.GetComponent<LevelController>().ChangeCircle();
            if (t == 6)
            {
                NextButton.GetComponent<Image>().sprite = FinishButton;
                NextButton.transform.GetChild(0).GetComponent<TMP_Text>().text = "Yakunlash";
            }
            CreatePrefabs();
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
        UnityEngine.SceneManagement.SceneManager.LoadScene("Quiz 3");
    }

}

