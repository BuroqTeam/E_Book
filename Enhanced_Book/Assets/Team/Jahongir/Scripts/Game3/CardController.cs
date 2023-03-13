using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IPointerClickHandler
{
    public Game3Controller Game3Controller;
    public GameObject LocationObj;
    public string Str;
    public int CardIndex;
    public int Index;


    [Header("Feedbacks")]
    public MMFeedbacks WrongFeedback;
    public MMFeedbacks CorrectFeedback;

    private void Start()
    {
        InputData();
    }
    public void InputData()
    {
        transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = Str;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(SelectCard());
    }

    public IEnumerator SelectCard()
    {
        Game3Controller.ClickFeedback?.PlayFeedbacks();
        transform.GetChild(3).GetComponent<SpriteRenderer>().color = new Color(100, 221, 255, 255);
        Game3Controller.SelectObjects.Add(gameObject);
        yield return new WaitForSeconds(0.5f);
        if (Game3Controller.SelectObjects.Count == 2)
        {
            Game3Controller.Result();
        }
    }

    public IEnumerator Wrong()
    {
        WrongFeedback?.PlayFeedbacks();
        yield return new WaitForSeconds(0.3f);
        yield return new WaitForSeconds(0.5f);
        transform.GetChild(3).GetComponent<SpriteRenderer>().color = new Color(100, 221, 255, 0);

    }
    public IEnumerator Correct()
    {
        //Particle
        CorrectFeedback?.PlayFeedbacks();
        yield return new WaitForSeconds(0.3f);
    }
}
