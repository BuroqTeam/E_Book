using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using UnityEngine.UI;

public class CircleTest : MonoBehaviour
{
    public MMFeedbacks FirsFeedback;
    private void Start()
    {
        Goooo();
    }

    public void Goooo()
    {
        StartCoroutine(AnimationCircle());
    }
    public IEnumerator AnimationCircle()
    {
        FirsFeedback?.PlayFeedbacks();
        for (int i = 0; i < 10; i++)
        {
            transform.GetComponent<Image>().material.SetFloat("_HitEffectBlend", i * 0.1f);
            transform.GetComponent<Image>().material.SetFloat("_ShineLocation", i * 0.1f);
            yield return new WaitForSeconds(0.04f);
        }
        for (int i = 10; i < 1; i--)
        {
            transform.GetComponent<Image>().material.SetFloat("_ShineLocation", i * 0.1f);
            yield return new WaitForSeconds(0.04f);
        }
    }
}
