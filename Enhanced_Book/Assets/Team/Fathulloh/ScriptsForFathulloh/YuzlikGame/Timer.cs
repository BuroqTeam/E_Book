using System;
using TMPro;
using UnityEngine;

namespace YuzlikFathulloh
{

    public class Timer : MonoBehaviour
    {
        bool timerActive = false;
        float currentTime;
        public int StartMinutes;
        public TMP_Text CurrentTimeText;


        void Start()
        {
            currentTime = StartMinutes * 60;

            StartTimer();
        }


        void Update()
        {
            if (timerActive)
            {
                currentTime -= Time.deltaTime;
            }

            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            CurrentTimeText.text = time.Minutes.ToString() + " : " + time.Seconds.ToString();
        }


        public void StartTimer()
        {
            timerActive = true;
        }


        public void StopTimer()
        {
            timerActive = false;
        }


    }
}
