using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game2_Fathulloh
{
    public class Calculate : MonoBehaviour
    {
        public GameControl GControl;
        public GameObject CurrentFigure;
        //public GameObject CheckButton;
        
        public UnityEvent NextTaskEvent;
        public UnityEvent WrongEvent;
        public UnityEvent FinishEvent;
        public UnityEvent CorrectSounEvent;
        public UnityEvent ClickSoundEvent;

        public bool _IsCheckWorking = true;

        
        public void Check()
        {
            if (_IsCheckWorking)
            {
                if (CurrentFigure.GetComponent<GeoFigure>()._IsCorrect)
                {
                    _IsCheckWorking = false;
                    CorrectSounEvent.Invoke();
                    CorrectAnim();
                    
                }
                else
                    WrongEvent.Invoke();
            }            
            
        }


        public void TimeIsFinished()
        {
            FinishEvent.Invoke();
            GControl.SwitchOffLinesTimeFinish();
        }


        public void CorrectAnim()
        {
            StartCoroutine(CorrectAnimating());
        }


        IEnumerator CorrectAnimating()
        {
            CurrentFigure.transform.DOScale(1.1f, 0.2f) ;
            yield return new WaitForSeconds(0.2f);
            CurrentFigure.transform.DOScale(0, 0.4f);
            yield return new WaitForSeconds(0.6f);
            NextTaskEvent.Invoke();
            //Debug.Log(" 1 2 ");
            _IsCheckWorking = true;
        }



    }
}
