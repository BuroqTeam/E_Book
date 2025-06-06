using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using ActionManager;
using MoreMountains.Feedbacks;
using TMPro;
using System.Linq;
using Extension;
using UnityEngine.Events;

public class Game3Conroller2User : MonoBehaviour
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
    public GameObject ParticleLocations;
    public List<GameObject> Collection;
    public GameObject Doors;

    [Header("Objects for Controller")]
    public GameObject Cursor;
    public List<GameObject> SelectObjects;
    public List<GameObject> EmptyLocation;
    public List<GameObject> AdditionEmptyLocation;
    public List<GameObject> Card1Collection;
    public List<GameObject> Card2Collection;
    public bool Task = false;
    int StrId = 0;
    int w = 0;


    [Header("Feedbacks")]
    public MMFeedbacks ClickFeedback;
    public MMFeedbacks TimeFeedback;

    [Header("Particles")]
    public GameObject AddCardParticle;
    public GameObject CorrectParticle;

    [Header("Result Objects")]
    public GameObject Result2User1;
    public GameObject Result2User2;
    public GameObject LoseResult;
    public GameObject CardsFirstUser;


    public UnityEvent FinishEvent;
    public UnityEvent LoseEvent;

    private void Start()
    {
        CreateCards();
        LocationCards();
        StartCoroutine(StartCard());
        DeterminationEmptyLocation();
    }

    public void CreateCards()
    {
        //int q = 0;
        for (int i = 0; i < 8; i++)
        {
            GameObject obj = Instantiate(Card1, Cards.transform);
            obj.transform.GetComponent<CardController2User>().Index = i;
            obj.transform.GetComponent<CardController2User>().CardIndex = 1;
            obj.transform.GetComponent<CardController2User>().Str = Str1.StrGroup[i];
            obj.transform.GetComponent<CardController2User>().Game3Controller = this;
            StrId++;
        }
        for (int i = 0; i < 8; i++)
        {
            GameObject obj = Instantiate(Card2, Cards.transform);
            obj.transform.GetComponent<CardController2User>().Index = i;
            obj.transform.GetComponent<CardController2User>().CardIndex = 2;
            obj.transform.GetComponent<CardController2User>().Str = Str2.StrGroup[i];
            obj.transform.GetComponent<CardController2User>().Game3Controller = this;
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
            Collection[i].transform.GetComponent<CardController2User>().LocationObj = CardLocations.transform.GetChild(i).gameObject;
            CardLocations.transform.GetChild(i).GetComponent<CardLocation>().IHave = true;
            CardLocations.transform.GetChild(i).GetComponent<CardLocation>().MyCard = Collection[i];
            CardLocations.transform.GetChild(i).transform.DOScale(0, 0);
        }

    }




    public IEnumerator StartCard()
    {
        for (int i = 0; i < Collection.Count; i++)
        {
            Collection[i].GetComponent<BoxCollider2D>().enabled = false;
        }
        yield return new WaitForSeconds(0.5f);
        Doors.transform.GetChild(0).GetComponent<MMFeedbacks>().PlayFeedbacks();
        Doors.transform.GetChild(1).GetComponent<MMFeedbacks>().PlayFeedbacks();
        yield return new WaitForSeconds(2.5f);
        for (int i = 0; i < Collection.Count; i++)
        {
            Collection[i].transform.DOMove(CardLocations.transform.GetChild(i).transform.position, 0f);
            
        }
        Cursor.GetComponent<CursorControl2User>().SelectObjects();
    }


    public void TaskTo()
    {
        for (int i = 0; i < Collection.Count; i++)
        {
            Collection[i].transform.GetChild(4).GetComponent<TaskTime2User>().PresentTime = Collection[i].transform.GetChild(4).GetComponent<TaskTime2User>().StartTime;
            Collection[i].GetComponent<CardController2User>().TaskTimeShader.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        }

        StartCoroutine(ToGiveTask());
    }

    public IEnumerator ToGiveTask()
    {
        if (!Task)
        {
            Task = true;
            int t = Random.Range(5, 10);
            yield return new WaitForSeconds(t);
            int c = Random.Range(1, Collection.Count);
            if (Collection[c].gameObject.activeSelf)
            {
                Collection[c].transform.GetChild(4).gameObject.SetActive(true);
                Collection[c].GetComponent<CardController2User>().TaskTimeShader.GetComponent<SpriteRenderer>().color = new Color(130, 210, 230, 255);
                Collection[c].transform.GetChild(4).GetComponent<MMFeedbacks>().PlayFeedbacks();
                StartCoroutine(Collection[c].transform.GetChild(4).GetComponent<TaskTime2User>().ChangeTime());
                yield return new WaitForSeconds(Collection[c].transform.GetChild(4).GetComponent<TaskTime2User>().StartTime - 0.5f);
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                Debug.Log("Man ishladim");
                StartCoroutine(ToGiveTask());
            }
        }

    }

    public void PermissionTask()
    {
        if (Collection.Count <= 22)
        {
            Debug.Log("Joy bor");
            Task = false;
        }
        else
        {
            Debug.Log("Joy yo'q");
        }
    }

    public void FinishCursor()
    {
        Cursor.SetActive(false);
        StartCoroutine(ToGiveTask());
        for (int i = 0; i < Collection.Count; i++)
        {
            Collection[i].GetComponent<BoxCollider2D>().enabled = true;
        }
    }


    public void AddNewCard()
    {
        if (EmptyLocation.Count >= 1 && AdditionEmptyLocation.Count % 2 == 0)
        {
            GameObject obj = Instantiate(Card1, Cards.transform);
            obj.transform.DOMoveZ(-1, 0);
            obj.transform.GetComponent<CardController2User>().Index = StrId;
            obj.transform.GetComponent<CardController2User>().CardIndex = 1;
            obj.transform.GetComponent<CardController2User>().Str = Str1.StrGroup[StrId / 2];
            obj.transform.GetComponent<CardController2User>().Game3Controller = this;
            //obj.transform.GetChild(4).GetComponent<TaskTime>().Game3Control = this;
            Collection.Add(Cards.transform.GetChild(Cards.transform.childCount - 1).gameObject);
            int r1 = Random.Range(0, EmptyLocation.Count);
            Collection[Collection.Count - 1].transform.DOMove(EmptyLocation[r1].transform.position, 0);
            Collection[Collection.Count - 1].GetComponent<CardController2User>().LocationObj = EmptyLocation[r1];
            EmptyLocation[r1].GetComponent<CardLocation>().IHave = true;
            EmptyLocation[r1].GetComponent<CardLocation>().MyCard = Collection[Collection.Count - 1];
            EmptyLocation.Remove(EmptyLocation[r1]);
            obj.transform.DOMoveZ(1, 0.1f);
            StartCoroutine(obj.transform.GetComponent<CardController2User>().AddCardFeedback());
            GameObject _particle = Instantiate(AddCardParticle, ParticleLocations.transform);
            _particle.transform.DOScale(0.38f, 0);
            _particle.transform.DOMove(Collection[Collection.Count - 1].GetComponent<CardController2User>().LocationObj.transform.position, 0);



            GameObject obj1 = Instantiate(Card2, Cards.transform);
            obj1.transform.DOMoveZ(-1, 0);
            obj1.transform.GetComponent<CardController2User>().Index = StrId;
            obj1.transform.GetComponent<CardController2User>().CardIndex = 2;
            obj1.transform.GetComponent<CardController2User>().Str = Str2.StrGroup[StrId / 2];
            obj1.transform.GetComponent<CardController2User>().Game3Controller = this;
            //obj1.transform.GetChild(4).GetComponent<TaskTime>().Game3Control = this;
            Collection.Add(Cards.transform.GetChild(Cards.transform.childCount - 1).gameObject);
            int r2 = Random.Range(0, EmptyLocation.Count);
            if (EmptyLocation.Count == 1)
            {
                r2 = 0;
            }
            Collection[Collection.Count - 1].transform.DOMove(EmptyLocation[r2].transform.position, 0);
            Collection[Collection.Count - 1].GetComponent<CardController2User>().LocationObj = EmptyLocation[r2];
            EmptyLocation[r2].GetComponent<CardLocation>().IHave = true;
            EmptyLocation[r2].GetComponent<CardLocation>().MyCard = Collection[Collection.Count - 1];
            EmptyLocation.Remove(EmptyLocation[r2]);
            obj1.transform.DOMoveZ(1, 0.1f);
            StartCoroutine(obj1.transform.GetComponent<CardController2User>().AddCardFeedback());
            GameObject _particle1 = Instantiate(AddCardParticle, ParticleLocations.transform);
            _particle1.transform.DOScale(0.38f, 0);
            _particle1.transform.DOMove(Collection[Collection.Count - 1].GetComponent<CardController2User>().LocationObj.transform.position, 0);
            StrId = StrId + 2;
        }
        else if (EmptyLocation.Count < 1 && AdditionEmptyLocation.Count % 2 == 0)
        {
            GameObject obj = Instantiate(Card1, Cards.transform);
            obj.transform.DOMoveZ(-1, 0);
            obj.transform.GetComponent<CardController2User>().Index = StrId;
            obj.transform.GetComponent<CardController2User>().CardIndex = 1;
            obj.transform.GetComponent<CardController2User>().Str = Str1.StrGroup[StrId / 2];
            obj.transform.GetComponent<CardController2User>().Game3Controller = this;
            Collection.Add(Cards.transform.GetChild(Cards.transform.childCount - 1).gameObject);
            int r1 = Random.Range(0, AdditionEmptyLocation.Count);
            Collection[Collection.Count - 1].transform.DOMove(AdditionEmptyLocation[r1].transform.position, 0);
            Collection[Collection.Count - 1].GetComponent<CardController2User>().LocationObj = AdditionEmptyLocation[r1];
            AdditionEmptyLocation[r1].GetComponent<CardLocation>().IHave = true;
            AdditionEmptyLocation[r1].GetComponent<CardLocation>().MyCard = Collection[Collection.Count - 1];
            AdditionEmptyLocation.Remove(AdditionEmptyLocation[r1]);
            obj.transform.DOMoveZ(1, 0);
            StartCoroutine(obj.transform.GetComponent<CardController2User>().AddCardFeedback());
            GameObject _particle = Instantiate(AddCardParticle, ParticleLocations.transform);
            _particle.transform.DOScale(0.38f, 0);
            _particle.transform.DOMove(Collection[Collection.Count - 1].GetComponent<CardController2User>().LocationObj.transform.position, 0);

            GameObject obj1 = Instantiate(Card2, Cards.transform);
            obj1.transform.DOMoveZ(-1, 0);
            obj1.transform.GetComponent<CardController2User>().Index = StrId;
            obj1.transform.GetComponent<CardController2User>().CardIndex = 2;
            obj1.transform.GetComponent<CardController2User>().Str = Str2.StrGroup[StrId / 2];
            obj1.transform.GetComponent<CardController2User>().Game3Controller = this;
            Collection.Add(Cards.transform.GetChild(Cards.transform.childCount - 1).gameObject);
            int r2 = Random.Range(0, AdditionEmptyLocation.Count);
            Collection[Collection.Count - 1].transform.DOMove(AdditionEmptyLocation[r2].transform.position, 0);
            Collection[Collection.Count - 1].GetComponent<CardController2User>().LocationObj = AdditionEmptyLocation[r2];
            AdditionEmptyLocation[r2].GetComponent<CardLocation>().IHave = true;
            AdditionEmptyLocation[r2].GetComponent<CardLocation>().MyCard = Collection[Collection.Count - 1];
            AdditionEmptyLocation.Remove(AdditionEmptyLocation[r2]);
            obj1.transform.DOMoveZ(1, 0);
            StartCoroutine(obj1.transform.GetComponent<CardController2User>().AddCardFeedback());
            GameObject _particle1 = Instantiate(AddCardParticle, ParticleLocations.transform);
            _particle1.transform.DOScale(0.38f, 0);
            _particle1.transform.DOMove(Collection[Collection.Count - 1].GetComponent<CardController2User>().LocationObj.transform.position, 0);
            StrId = StrId + 2;
        }

        if (EmptyLocation.Count % 2 == 1 && AdditionEmptyLocation.Count % 2 == 1)
        {
            GameObject obj = Instantiate(Card1, Cards.transform);
            obj.transform.DOMoveZ(-1, 0);
            obj.transform.GetComponent<CardController2User>().Index = StrId;
            obj.transform.GetComponent<CardController2User>().CardIndex = 1;
            obj.transform.GetComponent<CardController2User>().Str = Str1.StrGroup[StrId / 2];
            obj.transform.GetComponent<CardController2User>().Game3Controller = this;
            //obj.transform.GetChild(4).GetComponent<TaskTime>().Game3Control = this;
            Collection.Add(Cards.transform.GetChild(Cards.transform.childCount - 1).gameObject);
            int r1 = Random.Range(0, EmptyLocation.Count);
            if (EmptyLocation.Count == 1)
            {
                r1 = 0;
            }
            Collection[Collection.Count - 1].transform.DOMove(EmptyLocation[r1].transform.position, 0);
            Collection[Collection.Count - 1].GetComponent<CardController2User>().LocationObj = EmptyLocation[r1];
            EmptyLocation[r1].GetComponent<CardLocation>().IHave = true;
            EmptyLocation[r1].GetComponent<CardLocation>().MyCard = Collection[Collection.Count - 1];
            EmptyLocation.Remove(EmptyLocation[r1]);
            obj.transform.DOMoveZ(1, 0.1f);
            StartCoroutine(obj.transform.GetComponent<CardController2User>().AddCardFeedback());
            GameObject _particle = Instantiate(AddCardParticle, ParticleLocations.transform);
            _particle.transform.DOScale(0.38f, 0);
            _particle.transform.DOMove(Collection[Collection.Count - 1].GetComponent<CardController2User>().LocationObj.transform.position, 0);



            GameObject obj1 = Instantiate(Card2, Cards.transform);
            obj1.transform.DOMoveZ(-1, 0);
            obj1.transform.GetComponent<CardController2User>().Index = StrId;
            obj1.transform.GetComponent<CardController2User>().CardIndex = 2;
            obj1.transform.GetComponent<CardController2User>().Str = Str2.StrGroup[StrId / 2];
            obj1.transform.GetComponent<CardController2User>().Game3Controller = this;
            Collection.Add(Cards.transform.GetChild(Cards.transform.childCount - 1).gameObject);
            int r2 = Random.Range(0, AdditionEmptyLocation.Count);
            Collection[Collection.Count - 1].transform.DOMove(AdditionEmptyLocation[r2].transform.position, 0);
            Collection[Collection.Count - 1].GetComponent<CardController2User>().LocationObj = AdditionEmptyLocation[r2];
            AdditionEmptyLocation[r2].GetComponent<CardLocation>().IHave = true;
            AdditionEmptyLocation[r2].GetComponent<CardLocation>().MyCard = Collection[Collection.Count - 1];
            AdditionEmptyLocation.Remove(AdditionEmptyLocation[r2]);
            obj1.transform.DOMoveZ(1, 0);
            StartCoroutine(obj1.transform.GetComponent<CardController2User>().AddCardFeedback());
            GameObject _particle1 = Instantiate(AddCardParticle, ParticleLocations.transform);
            _particle1.transform.DOScale(0.38f, 0);
            _particle1.transform.DOMove(Collection[Collection.Count - 1].GetComponent<CardController2User>().LocationObj.transform.position, 0);
            StrId = StrId + 2;
        }


        StartCoroutine(ChangeStr());
    }





    public IEnumerator ChangeStr()
    {
        for (int i = 0; i < Collection.Count; i++)
        {
            Collection[i].GetComponent<BoxCollider2D>().enabled = false;
        }
        yield return new WaitForSeconds(1f);
        //CardDoor yopilishi
        for (int i = 0; i < Collection.Count; i++)
        {
            StartCoroutine(Collection[i].GetComponent<CardController2User>().CloseDoor());
        }
        Collection[0].GetComponent<CardController2User>().DoorFeedback.PlayFeedbacks();
        yield return new WaitForSeconds(0.4f);

        //Listga sort qilib olish
        for (int i = 0; i < Collection.Count; i++)
        {
            if (Collection[i].GetComponent<CardController2User>().CardIndex == 1)
            {
                Card1Collection.Add(Collection[i].gameObject);
            }
            else
            {
                Card2Collection.Add(Collection[i].gameObject);
            }
        }


        //Shufle qilish

        Card1Collection = Card1Collection.ShuffleList();
        Card2Collection = Card2Collection.ShuffleList();
        for (int i = 0; i <= Card1Collection.Count / 2; i++)
        {

            //Card1 uchun shufle
            string _newStr = Card1Collection[i].GetComponent<CardController2User>().Str;
            int _newIndex = Card1Collection[i].GetComponent<CardController2User>().Index;
            Card1Collection[i].GetComponent<CardController2User>().Str = Card1Collection[Card1Collection.Count - (i + 1)].GetComponent<CardController2User>().Str;
            Card1Collection[i].transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = Card1Collection[i].GetComponent<CardController2User>().Str;
            Card1Collection[i].GetComponent<CardController2User>().Index = Card1Collection[Card1Collection.Count - (i + 1)].GetComponent<CardController2User>().Index;
            Card1Collection[Card1Collection.Count - (i + 1)].GetComponent<CardController2User>().Str = _newStr;
            Card1Collection[Card1Collection.Count - (i + 1)].transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = Card1Collection[Card1Collection.Count - (i + 1)].GetComponent<CardController2User>().Str;
            Card1Collection[Card1Collection.Count - (i + 1)].GetComponent<CardController2User>().Index = _newIndex;

            //Card2 uchun shufle
            string _newStr1 = Card2Collection[i].GetComponent<CardController2User>().Str;
            int _newIndex1 = Card2Collection[i].GetComponent<CardController2User>().Index;
            Card2Collection[i].GetComponent<CardController2User>().Str = Card2Collection[Card2Collection.Count - (i + 1)].GetComponent<CardController2User>().Str;
            Card2Collection[i].transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = Card2Collection[i].GetComponent<CardController2User>().Str;
            Card2Collection[i].GetComponent<CardController2User>().Index = Card2Collection[Card2Collection.Count - (i + 1)].GetComponent<CardController2User>().Index;
            Card2Collection[Card2Collection.Count - (i + 1)].GetComponent<CardController2User>().Str = _newStr1;
            Card2Collection[Card2Collection.Count - (i + 1)].transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = Card2Collection[Card2Collection.Count - (i + 1)].GetComponent<CardController2User>().Str;
            Card2Collection[Card2Collection.Count - (i + 1)].GetComponent<CardController2User>().Index = _newIndex1;
        }

        yield return new WaitForSeconds(0.3f);
        //CardDoor ochilishi
        for (int i = 0; i < Collection.Count; i++)
        {
            StartCoroutine(Collection[i].GetComponent<CardController2User>().OpenDoor());
        }
        Collection[0].GetComponent<CardController2User>().DoorFeedback.PlayFeedbacks();
        yield return new WaitForSeconds(1f);

        //Listlarni tozalash
        for (int i = 0; i < Collection.Count / 2; i++)
        {
            Card1Collection.Remove(Card1Collection[0]);
            Card2Collection.Remove(Card2Collection[0]);
        }
        for (int i = 0; i < Collection.Count; i++)
        {
            Collection[i].GetComponent<BoxCollider2D>().enabled = true;
        }
    }




    public void Result()
    {
        if (SelectObjects.Count == 2)
        {
            if ((SelectObjects[0].GetComponent<CardController2User>().CardIndex != SelectObjects[1].GetComponent<CardController2User>().CardIndex)
                && (SelectObjects[0].GetComponent<CardController2User>().Index == SelectObjects[1].GetComponent<CardController2User>().Index))
            {
                //Correct Particle
                for (int i = 0; i < 2; i++)
                {
                    GameObject _particle = Instantiate(CorrectParticle, ParticleLocations.transform);
                    _particle.transform.DOScale(0.8f, 0);
                    _particle.transform.DOMove(SelectObjects[i].GetComponent<CardController2User>().LocationObj.transform.position, 0);
                    SelectObjects[i].GetComponent<CardController2User>().Correct();
                }

                for (int i = 0; i < SelectObjects.Count; i++)
                {
                    for (int j = 0; j < Collection.Count; j++)
                    {
                        if (SelectObjects[i].gameObject == Collection[j].gameObject)
                        {
                            Collection.Remove(Collection[j]);
                        }
                    }
                    if (SelectObjects[i].transform.GetChild(4).gameObject.activeSelf)
                    {
                        SelectObjects[i].transform.GetChild(4).GetComponent<TaskTime2User>().CircleTime = 0;
                        SelectObjects[i].GetComponent<CardController2User>().ActiveCard = false;
                        Task = false;
                    }
                    SelectObjects[i].GetComponent<CardController2User>().LocationObj.GetComponent<CardLocation>().IHave = false;
                    Destroy(SelectObjects[i], 0);
                }
                if (Collection.Count >= 22)
                {
                    Task = false;
                }
                if (Collection.Count == 0)
                {
                    FinishEvent.Invoke();
                    Result2User2.SetActive(true);
                    Cards.SetActive(false);
                    CardsFirstUser.SetActive(false);
                }


                //Bo'sh joylarni aniqlash
                DeterminationEmptyLocation();
                for (int i = 0; i < Collection.Count; i++)
                {
                    if (Collection[i].transform.GetChild(4).gameObject.activeSelf)
                    {
                        w++;
                    }
                }
                if (!Task)
                {
                    StartCoroutine(ToGiveTask());
                }
            }
            else
            {
                StartCoroutine(SelectObjects[0].GetComponent<CardController2User>().Wrong());
                StartCoroutine(SelectObjects[1].GetComponent<CardController2User>().Wrong());
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


    public void Lose()
    {
        LoseEvent.Invoke();
        for (int i = 0; i < Collection.Count; i++)
        {
            Collection[i].GetComponent<BoxCollider2D>().enabled = false;
        }
        StopCoroutine(ToGiveTask());
    }
}
