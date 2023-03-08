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
    public GameObject TaskTime;
    public Transform CardLocations;
    public List<GameObject> Collection;

    [Header("Feedbacks")]
    public MMFeedbacks StartFeedback;

    private void Start()
    {
        CreateCards();
        LocationCards();
        StartCoroutine(StartCard());
    }

    public void CreateCards()
    {
        //int q = 0;
        for (int i = 0; i < 8; i++)
        {
            GameObject obj = Instantiate(Card1, Cards.transform);
            obj.transform.GetComponent<Card1Controller>().Index = i;
            obj.transform.GetComponent<Card1Controller>().Str = Str1.StrGroup[i];
        }
        for (int i = 0; i < 8; i++)
        {
            GameObject obj = Instantiate(Card2, Cards.transform);
            obj.transform.GetComponent<Card2Controller>().Index = i;
            obj.transform.GetComponent<Card2Controller>().Str = Str2.StrGroup[i];
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
            Collection[i].transform.DOMove(CardLocations.GetChild(i).transform.position, 0);
        }
        CardLocations.gameObject.SetActive(false);
    }
    public IEnumerator StartCard()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < Collection.Count; i++)
        {
            Collection[i].transform.DOMove(CardLocations.GetChild(i).transform.position, 0f);
            Collection[i].transform.DOScale(0.35f, 2f);
            Collection[i].transform.GetChild(1).GetComponent<MMFeedbacks>().PlayFeedbacks();
        }
    }
}
