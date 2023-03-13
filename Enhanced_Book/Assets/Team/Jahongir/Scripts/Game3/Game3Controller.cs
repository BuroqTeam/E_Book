using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using ActionManager;
using MoreMountains.Feedbacks;

public class Game3Controller : MonoBehaviour
{

    [Header("Str Collections")]
    public StrCollection Str1;
    public StrCollection Str2;

    

    [Header("GameObjects of Cards")]
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Cards;
    public GameObject CardLocations;
    public Transform AddCardLocLeft;
    public Transform AddCardLocRight;
    public List<GameObject> Collection;
    public GameObject Doors;

    [Header("Objects for Controller")]
    public List<GameObject> SelectObjects;
    public List<GameObject> EmptyLocation;
    public List<GameObject> AdditionEmptyLocation;
    int StrId=0;


    [Header("Feedbacks")]
    public MMFeedbacks ClickFeedback;
    public MMFeedbacks TimeFeedback;


    private void Start()
    {
        CreateCards();
        LocationCards();
        StartCoroutine(StartCard());
        StartCoroutine(ToGiveTask());
        DeterminationEmptyLocation();
    }

    public void CreateCards()
    {
        //int q = 0;
        for (int i = 0; i < 8; i++)
        {
            GameObject obj = Instantiate(Card1, Cards.transform);
            obj.transform.GetComponent<CardController>().Index = i;
            obj.transform.GetComponent<CardController>().CardIndex = 1;
            obj.transform.GetComponent<CardController>().Str = Str1.StrGroup[i];
            obj.transform.GetComponent<CardController>().Game3Controller = this;
            StrId++;
        }
        for (int i = 0; i < 8; i++)
        {
            GameObject obj = Instantiate(Card2, Cards.transform);
            obj.transform.GetComponent<CardController>().Index = i;
            obj.transform.GetComponent<CardController>().CardIndex = 2;
            obj.transform.GetComponent<CardController>().Str = Str2.StrGroup[i];
            obj.transform.GetComponent<CardController>().Game3Controller = this;
            StrId++;
        }
        for (int i = 0; i < Cards.transform.childCount; i++)
        {
            Collection.Add(Cards.transform.GetChild(i).gameObject);
        }
    }



    public void LocationCards()
    {
        Collection = Actions.ShuffleList(Collection);


        for (int i = 0; i < Collection.Count; i++)
        {
            Collection[i].transform.DOMove(CardLocations.transform.GetChild(i).transform.position, 0);
            Collection[i].transform.GetComponent<CardController>().LocationObj = CardLocations.transform.GetChild(i).gameObject;
            CardLocations.transform.GetChild(i).GetComponent<CardLocation>().IHave = true;
            CardLocations.transform.GetChild(i).GetComponent<CardLocation>().MyCard = Collection[i];
            CardLocations.transform.GetChild(i).transform.DOScale(0, 0);
        }
        
    }




    public IEnumerator StartCard()
    {
        yield return new WaitForSeconds(0.5f);
        Doors.transform.GetChild(0).GetComponent<MMFeedbacks>().PlayFeedbacks();
        Doors.transform.GetChild(1).GetComponent<MMFeedbacks>().PlayFeedbacks();
        yield return new WaitForSeconds(2.5f);
        for (int i = 0; i < Collection.Count; i++)
        {
            Collection[i].transform.DOMove(CardLocations.transform.GetChild(i).transform.position, 0f);
            Collection[i].transform.DOScale(0.35f, 3f);
        }
    }

    public IEnumerator ToGiveTask()
    {
        int t = Random.Range(5, 10);
        int c = Random.Range(1, Collection.Count);
        yield return new WaitForSeconds(t);
        Collection[c].transform.GetChild(4).gameObject.SetActive(true);
        Collection[c].transform.GetChild(4).GetComponent<MMFeedbacks>().PlayFeedbacks();
        Collection[c].transform.GetChild(4).GetComponent<AudioSource>().enabled = true;
        yield return new WaitForSeconds(Collection[c].transform.GetChild(4).GetComponent<TaskTime>().StartTime);
        Collection[c].transform.GetChild(4).GetComponent<AudioSource>().enabled = false;
        StartCoroutine(ToGiveTask());
    }

    public void AddNewCard()
    {
        if (EmptyLocation.Count>=2)
        {
            GameObject obj = Instantiate(Card1, Cards.transform);
            obj.transform.GetComponent<CardController>().Index = StrId;
            obj.transform.GetComponent<CardController>().CardIndex = 1;
            obj.transform.GetComponent<CardController>().Str = Str1.StrGroup[StrId / 2];
            obj.transform.GetComponent<CardController>().Game3Controller = this;
            Collection.Add(Cards.transform.GetChild(Cards.transform.childCount-1).gameObject);
            int r1 = Random.Range(0, EmptyLocation.Count);
            Collection[StrId].transform.DOMove(EmptyLocation[r1].transform.position, 0);
            Collection[StrId].GetComponent<CardController>().LocationObj = EmptyLocation[r1];
            EmptyLocation[r1].GetComponent<CardLocation>().IHave = true;
            EmptyLocation[r1].GetComponent<CardLocation>().MyCard = Collection[StrId];
            EmptyLocation.Remove(EmptyLocation[r1]);

            GameObject obj1 = Instantiate(Card2, Cards.transform);
            obj1.transform.GetComponent<CardController>().Index = StrId;
            obj1.transform.GetComponent<CardController>().CardIndex = 2;
            obj1.transform.GetComponent<CardController>().Str = Str2.StrGroup[StrId / 2];
            obj1.transform.GetComponent<CardController>().Game3Controller = this;
            Collection.Add(Cards.transform.GetChild(Cards.transform.childCount-1).gameObject);
            int r2 = Random.Range(0, EmptyLocation.Count);
            Collection[Collection.Count-1].transform.DOMove(EmptyLocation[r2].transform.position, 0);
            Collection[Collection.Count - 1].GetComponent<CardController>().LocationObj = EmptyLocation[r2];
            EmptyLocation[r2].GetComponent<CardLocation>().IHave = true;
            EmptyLocation[r2].GetComponent<CardLocation>().MyCard = Collection[Collection.Count - 1];
            EmptyLocation.Remove(EmptyLocation[r2]);
            StrId = StrId + 2;
        }
        else
        {
            GameObject obj = Instantiate(Card1, Cards.transform);
            obj.transform.GetComponent<CardController>().Index = StrId;
            obj.transform.GetComponent<CardController>().CardIndex = 1;
            obj.transform.GetComponent<CardController>().Str = Str1.StrGroup[StrId / 2];
            obj.transform.GetComponent<CardController>().Game3Controller = this;
            Collection.Add(Cards.transform.GetChild(Cards.transform.childCount - 1).gameObject);
            int r1 = Random.Range(0, AdditionEmptyLocation.Count);
            Collection[StrId].transform.DOMove(AdditionEmptyLocation[r1].transform.position, 0);
            Collection[StrId].GetComponent<CardController>().LocationObj = AdditionEmptyLocation[r1];
            AdditionEmptyLocation[r1].GetComponent<CardLocation>().IHave = true;
            AdditionEmptyLocation[r1].GetComponent<CardLocation>().MyCard = Collection[StrId];
            AdditionEmptyLocation.Remove(AdditionEmptyLocation[r1]);

            GameObject obj1 = Instantiate(Card2, Cards.transform);
            obj1.transform.GetComponent<CardController>().Index = StrId;
            obj1.transform.GetComponent<CardController>().CardIndex = 2;
            obj1.transform.GetComponent<CardController>().Str = Str2.StrGroup[StrId / 2];
            obj1.transform.GetComponent<CardController>().Game3Controller = this;
            Collection.Add(Cards.transform.GetChild(Cards.transform.childCount - 1).gameObject);
            int r2 = Random.Range(0, AdditionEmptyLocation.Count);
            Collection[Collection.Count - 1].transform.DOMove(AdditionEmptyLocation[r2].transform.position, 0);
            Collection[Collection.Count - 1].GetComponent<CardController>().LocationObj = AdditionEmptyLocation[r2];
            AdditionEmptyLocation[r2].GetComponent<CardLocation>().IHave = true;
            AdditionEmptyLocation[r2].GetComponent<CardLocation>().MyCard = Collection[Collection.Count - 1];
            AdditionEmptyLocation.Remove(AdditionEmptyLocation[r2]);
            StrId = StrId + 2;
        }
    }

    public void Result()
    {
        if (SelectObjects.Count == 2)
        {
            if ((SelectObjects[0].GetComponent<CardController>().CardIndex != SelectObjects[1].GetComponent<CardController>().CardIndex)
                && (SelectObjects[0].GetComponent<CardController>().Index == SelectObjects[1].GetComponent<CardController>().Index))
            {
                StartCoroutine(SelectObjects[0].GetComponent<CardController>().Correct());

                for (int i = 0; i < SelectObjects.Count; i++)
                {
                    SelectObjects[i].GetComponent<CardController>().LocationObj.GetComponent<CardLocation>().IHave = false;
                    Destroy(SelectObjects[i], 0);
                }
                //Bo'sh joylarni aniqlash
                DeterminationEmptyLocation();
            }
            else
            {
                StartCoroutine(SelectObjects[0].GetComponent<CardController>().Wrong());

                AddNewCard();
            }
        }
        for (int i = 0; i < 2; i++)
        {
            SelectObjects[0].transform.GetChild(3).GetComponent<SpriteRenderer>().color = new Color(100, 221, 255, 0);
            SelectObjects.Remove(SelectObjects[0]);
        }
    }

    public void DeterminationEmptyLocation()
    {
        for (int i = 0; i < CardLocations.transform.childCount; i++)
        {
            if (!CardLocations.transform.GetChild(i).GetComponent<CardLocation>().IHave)
            {
                int w = 0;
                for (int j = 0; j < EmptyLocation.Count; j++)
                {
                    if (CardLocations.transform.GetChild(i).transform == EmptyLocation[j].transform)
                    {
                        w++;
                    }
                }
                if (w == 0)
                {
                    EmptyLocation.Add(CardLocations.transform.GetChild(i).gameObject);
                }
            }
        }
        for (int i = 0; i < AddCardLocLeft.transform.childCount; i++)
        {
            if (!AddCardLocLeft.transform.GetChild(i).GetComponent<CardLocation>().IHave)
            {
                int w = 0;
                for (int j = 0; j < AdditionEmptyLocation.Count; j++)
                {
                    if (AddCardLocLeft.transform.GetChild(i).transform == AdditionEmptyLocation[j].transform)
                    {
                        w++;
                    }
                }
                if (w == 0)
                {
                    AdditionEmptyLocation.Add(AddCardLocLeft.transform.GetChild(i).gameObject);
                }
            }
            if (!AddCardLocRight.transform.GetChild(i).GetComponent<CardLocation>().IHave)
            {
                int w = 0;
                for (int j = 0; j < AdditionEmptyLocation.Count; j++)
                {
                    if (AddCardLocRight.transform.GetChild(i).transform == AdditionEmptyLocation[j].transform)
                    {
                        w++;
                    }
                }
                if (w == 0)
                {
                    AdditionEmptyLocation.Add(AddCardLocRight.transform.GetChild(i).gameObject);
                }
            }
        }
    }
}

