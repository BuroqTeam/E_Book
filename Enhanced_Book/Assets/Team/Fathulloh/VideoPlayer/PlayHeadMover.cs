using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FathullohVideoPlayer
{
    public class PlayHeadMover : MonoBehaviour
    {
        public RectTransform startPoint;
        public RectTransform endPoint;

        //[SerializeField] private SliderJoint2D _slider;
        //[]


        public void MovePlayhead(double playedFraction)
        {
            transform.position = Vector3.Lerp(startPoint.position, endPoint.position, (float)playedFraction);
            //transform.position = Vector3.Lerp(startPoint.localPosition, endPoint.localPosition, (float)playedFraction);
        }

    }
}
