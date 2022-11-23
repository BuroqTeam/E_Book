using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveBoard : MonoBehaviour
{
    public GameObject MovingBoard;
    public Ease MoveEase;
    float _movingDuration = 0.8f;

    

    void Start()
    {
        Debug.Log("MovingBoard position = " + MovingBoard.transform.position);
        Debug.Log("MovingBoard position = " + MovingBoard.transform.localPosition);
        Debug.Log("MovingBoard position = " + MovingBoard.GetComponent<RectTransform>().anchoredPosition);
    }

    
    public void BoardMoveToRight()
    {

    }


    IEnumerator MovingToRight()
    {
        yield return new WaitForSeconds(_movingDuration);
    }


    public void BoardMoveToLeft()
    {
        //Debug.Log()
        MovingBoard.GetComponent<RectTransform>().DOAnchorPosX(-MovingBoard.GetComponent<RectTransform>().anchoredPosition.x / 2, _movingDuration);
    }


    IEnumerator MovingToLeft()
    {
        yield return new WaitForSeconds(_movingDuration);
    }


}
