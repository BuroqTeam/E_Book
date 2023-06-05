using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game2_TwoPlayer
{
    public class Calculate : MonoBehaviour
    {
        //public GameManage GManage;
        public GameObject CurrentFigure_First;
        public GameObject CurrentFigure_Second;

        public List<GameObject> SwitchedObjects;

        public UnityEvent NextTaskEvent;
        public UnityEvent WrongEvent;

        public UnityEvent NextTaskEvent_Second;
        public UnityEvent WrongEvent_Second;

        public UnityEvent FinishEvent;
        public UnityEvent CorrectSounEvent;
        public UnityEvent ClickSoundEvent;

        public bool _IsCheckWorking = true;

                
        public void CheckFirst()
        {
            if (_IsCheckWorking)
            {
                if (CurrentFigure_First.GetComponent<GeoFigure>()._IsCorrect)
                {
                    _IsCheckWorking = false;
                    CorrectSounEvent.Invoke();
                    CorrectAnim();
                }
                else
                    WrongEvent.Invoke();
            }
        }


        /// <summary>
        /// Vaqt tugaganda sshu metod chaqiriladi.
        /// </summary>
        public void TimeIsFinished()
        {
            FinishEvent.Invoke();            
        }


        public void CorrectAnim()
        {
            StartCoroutine(CorrectAnimating());
        }


        IEnumerator CorrectAnimating()
        {
            CurrentFigure_First.transform.DOScale(1.1f, 0.2f);
            yield return new WaitForSeconds(0.2f);
            CurrentFigure_First.transform.DOScale(0, 0.4f);
            yield return new WaitForSeconds(0.6f);
            NextTaskEvent.Invoke();
            
            _IsCheckWorking = true;            
        }


        public bool _IsChekingWorking_Second = true;

        public void CheckSecond()
        {
            if (_IsChekingWorking_Second)
            {
                if (CurrentFigure_Second.GetComponent<GeoFigure>()._IsCorrect)
                {
                    _IsChekingWorking_Second = false;
                    CorrectSounEvent.Invoke();
                    CorrectAnim_2();
                }
                else
                    WrongEvent_Second.Invoke();
            }
        }


        public void CorrectAnim_2()
        {
            StartCoroutine(CorrectAnimating_2());
        }


        IEnumerator CorrectAnimating_2()
        {
            CurrentFigure_Second.transform.DOScale(1.1f, 0.2f);
            yield return new WaitForSeconds(0.2f);
            CurrentFigure_Second.transform.DOScale(0, 0.4f);
            yield return new WaitForSeconds(0.6f);
            NextTaskEvent_Second.Invoke();

            _IsChekingWorking_Second = true;
        }


        /// <summary>
        /// O‘yin tugaganda obyektlarni o‘chirib qo‘yish. 
        /// </summary>
        public void SwitchOffObjects()
        {
            for (int i = 0; i < SwitchedObjects.Count; i++)
            {
                SwitchedObjects[i].SetActive(false);
            }
        }

    }
}
