using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace Matching
{
    public class GameManager : MonoBehaviour
    {
        //public GameObject finishPanel;
        public GameObject FathullogFinishPanel;
        public UnityEvent FinishEvent;
       


        private void Awake()
        {
            Input.multiTouchEnabled = false;
            Application.targetFrameRate = 100;

        }

        public void Finish()
        {
            FinishEvent.Invoke();
            //FathullogFinishPanel.SetActive(true);

            //finishPanel.SetActive(true);
        }


        
    }

}

