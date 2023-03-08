using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FathullohMundarijaTable
{
    public class MundarijaManager : MonoBehaviour
    {
        public UnityEvent PageEvent;
        public GameObject BookObj;
        public List<GameObject> SwitchOffObjects;

        bool isFirstTime = true;

        public List<GameObject> MediaButtons;

        private void Awake()
        {
            //InvisiableObjects(false);
        }


        void Start()
        {

        }


        private void OnEnable()
        {
            //Debug.Log(gameObject.activeSelf);
            bool statusObj = gameObject.activeSelf;
            if (statusObj)
            {
                InvisiableObjects(false);
            }            
        }


        public void InvisiableObjects(bool newStatus)
        {
            for (int i = 0; i < SwitchOffObjects.Count; i++)
            {
                SwitchOffObjects[i].SetActive(newStatus);
            }

        }


        /// <summary>
        /// Click qilingandan so'ng birinchida turgan spriteni o'chirib yuboradi listdan.
        /// </summary>
        public void AfterClick()
        {
            if (isFirstTime)
            {
                BookObj.GetComponent<PageController>().Pages.RemoveAt(0);
                isFirstTime = false;
            }
            FixButtons();
        }


        /// <summary>
        /// Mediya, Video va Game buttonlarini qaytadan ishga tushiradi.
        /// </summary>
        public void FixButtons()
        {
            for (int i = 0; i < MediaButtons.Count; i++)
            {
                MediaButtons[i].GetComponent<MediaButton>().ChangeMediaSceneName();
            }
        }


    }
}
