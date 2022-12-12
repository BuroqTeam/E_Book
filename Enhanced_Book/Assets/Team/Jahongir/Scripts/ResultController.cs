using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class ResultController : MonoBehaviour
{
    public GameObject LevelIcons;
    public GameObject Badge;
    public TMP_Text CorrectNumber;
    public TMP_Text WrongNumber;
    private void Start()
    {
        StartCoroutine(ResultAnimation());
    }

    public IEnumerator ResultAnimation()
    {
        Badge.transform.DOScale(1, 0.7f);
        Badge.transform.DORotate(new Vector3(0, 360, 0), 0.75f);
        for (int i = 1; i < LevelIcons.transform.childCount; i++)
        {
            LevelIcons.transform.GetChild(i).transform.DOScale(1, 0.2f);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
