using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl1User : MonoBehaviour
{
    public Game3Controller1User Game3Control;
    public GameObject Object1;
    public GameObject Object2;


    public void SelectObjects()
    {
        Object1 = Game3Control.Collection[5];
        for (int i = 0; i < Game3Control.Collection.Count; i++)
        {
            if (Object1.GetComponent<CardController1User>().Index == Game3Control.Collection[i].GetComponent<CardController1User>().Index && i != 5)
            {
                Object2 = Game3Control.Collection[i];
            }
        }
        StartCoroutine(HandAnimation());
    }

    public IEnumerator RestartAnim()
    {
        for (int i = 0; i < Game3Control.Collection.Count; i++)
        {
            Game3Control.Collection[i].GetComponent<BoxCollider2D>().enabled = true;
        }
        yield return new WaitForSeconds(10);
        StartCoroutine(HandAnimation());
    }


    public IEnumerator HandAnimation()
    {
        for (int i = 0; i < Game3Control.Collection.Count; i++)
        {
            Game3Control.Collection[i].GetComponent<BoxCollider2D>().enabled = false;
        }

        transform.GetChild(0).DOMove(new Vector3(Object1.transform.position.x, Object1.transform.position.y, 0.5f), 2f);
        yield return new WaitForSeconds(2);
        transform.GetChild(0).DOScale(0.06f, 0.5f);
        yield return new WaitForSeconds(0.2f);
        Game3Control.ClickFeedback?.PlayFeedbacks();
        Object1.transform.GetChild(3).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        transform.GetChild(0).DOScale(0.1f, 0.5f);
        yield return new WaitForSeconds(0.5f);

        transform.GetChild(0).DOMove(new Vector3(Object2.transform.position.x, Object2.transform.position.y, 0.5f), 1f);
        yield return new WaitForSeconds(1);
        transform.GetChild(0).DOScale(0.06f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Game3Control.ClickFeedback?.PlayFeedbacks();
        Object2.transform.GetChild(3).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        transform.GetChild(0).DOScale(0.1f, 0.5f);
        yield return new WaitForSeconds(0.8f);

        transform.GetChild(0).DOMove(new Vector3(10, -10, 0.5f), 2f);
        yield return new WaitForSeconds(0.5f);
        Object1.transform.GetChild(3).GetComponent<SpriteRenderer>().color = new Color(100, 221, 255, 0);
        Object2.transform.GetChild(3).GetComponent<SpriteRenderer>().color = new Color(100, 221, 255, 0);
        StartCoroutine(RestartAnim());
    }
}
