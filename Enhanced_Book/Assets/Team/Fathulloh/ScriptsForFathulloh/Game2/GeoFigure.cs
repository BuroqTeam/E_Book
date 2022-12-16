using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game2_Fathulloh
{
    public class GeoFigure : MonoBehaviour
    {
        bool _IsWorking = true;
        public List<GameObject> InitialDots;


        void Start()
        {

        }


        void Update()
        {
            if (_IsWorking)
            {
                if (gameObject.GetComponent<Lr_Testing>()._IsFinished && (InitialDots != null))
                {
                    Debug.Log((InitialDots != null));
                    _IsWorking = false;
                    ChangeDotPos();
                }
            }
        }



        void ChangeDotPos()
        {
            int childrenCount = gameObject.transform.childCount;
            Debug.Log(gameObject.name + " InitialDots.Count = " + InitialDots.Count);
            //for (int i = 0; i < childrenCount; i++)
            //{
            //    gameObject.transform.GetChild(i).transform.position = InitialDots[i].transform.position;
            //}
        }


    }
}
