using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class P3_Puzzle1 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public string QuestionId;
    public Pattern_3 Pattern3;
    public GameObject AttechedPuzzle;
    private int _selectedAnswerId = -1;
    private int siblingIndexObj;
    private int a = 0;
    private Vector3 _lastPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Pattern3.transform.GetChild(1).GetComponent<VerticalLayoutGroup>().enabled)
        {
            Pattern3.transform.GetChild(1).GetComponent<VerticalLayoutGroup>().enabled = false;
        }
        transform.GetChild(1).transform.DOScale(1.2f, 0);
        _lastPos = transform.GetChild(1).transform.position;
        siblingIndexObj = transform.GetSiblingIndex();
        transform.SetSiblingIndex(Pattern3.QuestionPuzles.Count - 1);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.GetChild(1).transform.position = new Vector3(pos.x, pos.y, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        for (int i = 0; i < Pattern3.AnswerPuzles.Count; i++)
        {
            if (Vector2.Distance(transform.GetChild(1).transform.position, Pattern3.AnswerPuzles[i].transform.GetChild(1).transform.position) < 0.7f)
            {
                _selectedAnswerId = i;
            }
        }
        if (_selectedAnswerId != -1)
        {
            transform.GetChild(1).transform.position = Pattern3.AnswerPuzles[_selectedAnswerId].transform.GetChild(1).transform.position;
            AttechedPuzzle = Pattern3.AnswerPuzles[_selectedAnswerId];
            transform.GetChild(1).transform.DOScale(1, 0);
            if (Pattern3.SelectedPuzles.Count == 0)
            {
                Pattern3.SelectedPuzles.Add(gameObject);
            }
            else
            {
                for (int i = 0; i < Pattern3.SelectedPuzles.Count; i++)
                {
                    if (GetComponent<P3_Puzzle1>().QuestionId == Pattern3.SelectedPuzles[i].transform.GetComponent<P3_Puzzle1>().QuestionId)
                    {
                        a++;
                    }
                }
                if (a == 0)
                {
                    Pattern3.SelectedPuzles.Add(gameObject);
                }
            }
        }
        else
        {
            transform.GetChild(1).transform.position = transform.GetChild(0).transform.position;
            transform.GetChild(1).transform.DOScale(1, 0);
            Pattern3.SelectedPuzles.Remove(gameObject);
        }
        _selectedAnswerId = -1;
        if (Pattern3.SelectedPuzles.Count>0)
        {
            Pattern3.NextButton.SetActive(true);
        }
        else
        {
            Pattern3.NextButton.SetActive(false);
        }

        transform.SetSiblingIndex(siblingIndexObj);
        //Pattern3.CheckButton();
        //Pattern3.Check();
    }
}
