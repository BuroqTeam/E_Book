using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChangePos : MonoBehaviour
{

    public bool Big;
    public void ChangePosition()
    {
        GetComponent<RectTransform>().DOScale(1.09f, 0);
        GetComponent<RectTransform>().DOAnchorPosY(24, 0);
    }

    public void ReturnPosition()
    {
        GetComponent<RectTransform>().DOScale(1, 0);
        GetComponent<RectTransform>().DOAnchorPosY(0, 0);
    }
}
