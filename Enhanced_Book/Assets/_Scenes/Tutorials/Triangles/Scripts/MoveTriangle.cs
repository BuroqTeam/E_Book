using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveTriangle : MonoBehaviour
{
    public GameObject Angles;
    public GameObject Sides;

    void Start()
    {
        Sides.SetActive(false);
        StartCoroutine(MoveTriangles());
    }

    IEnumerator MoveTriangles()
    {
        while (GetComponent<RectTransform>().localScale.x < 1.3)
        {
            GetComponent<RectTransform>().DOAnchorPosY(GetComponent<RectTransform>().localPosition.y + 5, 1.5f);
            yield return new WaitForSeconds(1);
            GetComponent<RectTransform>().DOAnchorPosY(GetComponent<RectTransform>().localPosition.y - 5, 1.5f);
            yield return new WaitForSeconds(1.5f);
        }
    }
}
