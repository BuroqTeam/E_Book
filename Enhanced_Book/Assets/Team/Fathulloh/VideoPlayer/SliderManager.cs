using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;

namespace FathullohVideoPlayer
{
    public class SliderManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public AudioSource audioCurrent;
        public Slider audioVolume;

        public VideoPlayer videoPlayer;
        Slider tracking;

        public bool slide = false;


        void Start()
        {
            tracking = GetComponent<Slider>();
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            slide = true;
            //videoPlayer.Pause();
            //Debug.Log("OnPointerDown true ");
        }


        public void OnPointerUp(PointerEventData eventData)
        {
            float frame = (float)tracking.value * (float)videoPlayer.frameCount;
            videoPlayer.frame = (long)frame;
            //tracking.value = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
            //videoPlayer.Play();
            //slide = false;
            //Debug.Log("videoPlayer.frame " + videoPlayer.frame);
        }


        void Update()
        {
            if (!slide && videoPlayer.isPlaying)
            {
                tracking.value = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
            }
        }


        public void volume()
        {
            audioCurrent.volume = audioVolume.value;
        }


    }
}
