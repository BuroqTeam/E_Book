using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CardController : MonoBehaviour, IPointerClickHandler
{
    public Game3Controller Game3Controller;
    public GameObject LocationObj;
    public GameObject Doors;
    public string Str;
    public int CardIndex;
    public int Index;
    public bool ActiveCard = true;


    [Header("Feedbacks")]
    public MMFeedbacks WrongFeedback;
    public MMFeedbacks CorrectFeedback;
    public MMFeedbacks DoorFeedback;
    public MMFeedbacks AddNewCardFeedback;

    [Header("Shader Objects")]
    public GameObject TaskTimeShader;

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
        //if (Game3Controller.SelectObjects.Count ==1 && Game3Controller.SelectObjects[0].gameObject != this)
        //{

        //}
        if (Game3Controller.SelectObjects.Count<2)
        {
            transform.GetChild(3).GetComponent<SpriteRenderer>().material.SetColor("_GlowColor", new Color(0, 241, 231, 255));
            StartCoroutine(SelectCard());
        }
    }




    public IEnumerator SelectCard()
    {
        Game3Controller.ClickFeedback?.PlayFeedbacks();
        TaskTimeShader.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        transform.GetChild(3).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        Game3Controller.SelectObjects.Add(gameObject);
        yield return new WaitForSeconds(0.7f);
        if (Game3Controller.SelectObjects.Count == 2)
        {
            Game3Controller.Result();
        }
    }

    public void Correct()
    {
        CorrectFeedback?.PlayFeedbacks();
    }


    public IEnumerator Wrong()
    {
        transform.GetChild(3).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        TaskTimeShader.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        transform.GetChild(5).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        transform.GetChild(5).GetComponent<SpriteRenderer>().material.SetColor("_GlowColor", new Color(240, 0, 20, 255));
        WrongFeedback?.PlayFeedbacks();
        yield return new WaitForSeconds(0.8f);
        transform.GetChild(5).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        if (transform.GetChild(4).gameObject.activeSelf)
        {
            Debug.Log("Taskdagi shader");
            TaskTimeShader.GetComponent<SpriteRenderer>().color = new Color(130, 210, 230, 255);
        }

    }

    public IEnumerator AddCardFeedback()
    {
        AddNewCardFeedback?.PlayFeedbacks();
        yield return new WaitForSeconds(0.7f);
        //transform.GetChild(3).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        //transform.GetChild(5).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        //transform.GetChild(6).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        //transform.GetChild(6).GetComponent<SpriteRenderer>().material.SetColor("_GlowColor", new Color(255, 0, 214, 255));
        //yield return new WaitForSeconds(0.5f);
        //transform.GetChild(6).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);

    }



    public IEnumerator CloseDoor()
    {
        for (int i = 10; i >= 0; i--)
        {
            Doors.transform.GetChild(0).GetComponent<SpriteRenderer>().material.SetFloat("_ClipUvRight", i*0.1f);
            Doors.transform.GetChild(1).GetComponent<SpriteRenderer>().material.SetFloat("_ClipUvRight", i * 0.1f);
            yield return new WaitForSeconds(0.03f);
        }
    }

    public IEnumerator OpenDoor()
    {
        for (int i = 0; i < 11; i++)
        {
            Doors.transform.GetChild(0).GetComponent<SpriteRenderer>().material.SetFloat("_ClipUvRight", i * 0.1f);
            Doors.transform.GetChild(1).GetComponent<SpriteRenderer>().material.SetFloat("_ClipUvRight", i * 0.1f);
            yield return new WaitForSeconds(0.03f);
        }
    }
}
