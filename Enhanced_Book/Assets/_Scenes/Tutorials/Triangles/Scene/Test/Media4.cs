using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Media4 : MonoBehaviour
{
    public GameObject OldQoshimcha;

    private void Start()
    {
        StartCoroutine(StartAnim());
    }

    IEnumerator StartAnim()
    {
        yield return new WaitForSeconds(1);
        OldQoshimcha.GetComponent<RectTransform>().DOAnchorPosX(0, 0.5f);
        yield return new WaitForSeconds(1);
        OldQoshimcha.GetComponent<RectTransform>().DORotate(new Vector3(0, 0, 90), 1);
        yield return new WaitForSeconds(1);
    }
}
