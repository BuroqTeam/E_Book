using System;
using TMPro;
using UnityEngine;

namespace YuzlikFathulloh
{
    public class Stopwatch : MonoBehaviour
    {
        bool stopWatchActive = false;
        float currentTime;
        public int StartMinutes;
        public TMP_Text CurrentTimeText;


        void Start()
        {
            currentTime = 0;
            StartStopWatch();
        }

        
        void Update()
        {
            if (stopWatchActive)
            {
                currentTime += Time.deltaTime;

                if (CurrentTimeText.text.Length == 7)                {
                    stopWatchActive = false;
                }
            }

            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            CurrentTimeText.text = time.Minutes.ToString() + " : " + time.Seconds.ToString();
        }


        public void StartStopWatch()
        {
            stopWatchActive = true;
        }


        public void StopStopWatch()
        {
            stopWatchActive = false;
        }


        public void RestartButton()
        {
            currentTime = 0;
        }


        public void WriteTimeToObject(GameObject gObj)
        {
            gObj.GetComponent<TMP_Text>().text = CurrentTimeText.ToString();
        }



    }
}
