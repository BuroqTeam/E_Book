using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace YuzlikFathulloh
{
    /// <summary>
    /// Vaqt kamayib boradigan script.
    /// </summary>
    public class Timer : MonoBehaviour
    {
        bool timerActive = false;
        public float currentTime;
        public int StartMinutes;
        public TMP_Text CurrentTimeText;


        public UnityEvent TimeEndEvent;

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
                if (currentTime <= 0)
                {
                    timerActive = false;
                    TimeEndEvent.Invoke();
                }
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
