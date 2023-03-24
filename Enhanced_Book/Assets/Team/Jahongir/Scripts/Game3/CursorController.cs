using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Game3Controller Game3Control;
    public GameObject Object1;
    public GameObject Object2;


    public void SelectObjects()
    {
        Object1 = Game3Control.Cards.transform.GetChild(0).gameObject;
        for (int i = 0; i < Game3Control.Collection.Count; i++)
        {
            if (Object1.GetComponent<CardController>().Index == Game3Control.Collection[i].GetComponent<CardController>().Index)
            {
                Game3Control.Collection[i] = Object2;
            }
        }
    }


    public IEnumerator HandAnimation()
    {
        yield return new WaitForSeconds(0);
    }
}
