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

        
        public UnityEvent NextTaskEvent;
        public UnityEvent WrongEvent;
        public UnityEvent FinishEvent;
        public UnityEvent ClickSoundEvent;


        void Start()
        {

        }


        public void Check()
        {
            if (CurrentFigure.GetComponent<GeoFigure>()._IsCorrect)
            {
                ClickSoundEvent.Invoke();
                NextTaskEvent.Invoke();
            }
            else
            {
                WrongEvent.Invoke();
            }
        }


        public void Finished()
        {
            Debug.Log("Everything is finished.");
        }

    }
}
