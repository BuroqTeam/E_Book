using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class CircleTest : MonoBehaviour
{
    public MMFeedbacks FirsFeedback;
    private void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            FirsFeedback?.PlayFeedbacks();
        }
    }
}
