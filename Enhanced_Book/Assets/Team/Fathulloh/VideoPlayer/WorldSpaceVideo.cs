using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace FathullohVideoPlayer
{
    /// <summary>
    /// Playing video in unity to'plamiga ko'ra yozilgan script
    /// </summary>
    public class WorldSpaceVideo : MonoBehaviour
    {
        public Sprite PauseSpr, PlaySpr;
        public GameObject PlayPauseButton;
        public VideoPlayer videoPlayer;

        public TMP_Text CurrentMinutes;
        public TMP_Text CurrentSeconds;
        public TMP_Text TotalMinutes;
        public TMP_Text TotalSeconds;

        
        private void Awake()
        {
            //videoPlayer = GetComponent<VideoPlayer>();
        }


        void Start()
        {
            SetTotalTimeUI();
        }
        

        void Update()
        {
            if (videoPlayer.isPlaying)
            {
                SetCurrentTimeUI();
            }
        }


        public void PlayPause()
        {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause();
                PlayPauseButton.transform.GetChild(0).GetComponent<Image>().sprite = PlaySpr;
            }
            else
            {
                videoPlayer.Play();
                PlayPauseButton.transform.GetChild(0).GetComponent<Image>().sprite = PauseSpr;
            }
        }


        void SetCurrentTimeUI()
        {
            string minutes = Mathf.Floor((int)videoPlayer.time / 60).ToString("00");
            string seconds = ((int)videoPlayer.time % 60).ToString("00");

            CurrentMinutes.text = minutes;
            CurrentSeconds.text = seconds;
        }


        void SetTotalTimeUI()
        {
            string minutes = Mathf.Floor((int)videoPlayer.clip.length / 60).ToString("00");
            string seconds = ((int)videoPlayer.clip.length % 60).ToString("00");

            TotalMinutes.text = minutes;
            TotalSeconds.text = seconds;
        }



    }
}
