using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game2_TwoPlayer
{
    public class GeoFigure : MonoBehaviour
    {
        /// <summary>
        /// Uchburchakning boshlang'ich paytdagi nuqtalari.
        /// </summary>
        public List<GameObject> InitialDots;
        public List<GameObject> Childs;

        /// <summary>
        /// perimetri yoki yuzasi. GameManager scipti orqali beriladi.
        /// </summary>
        public int PerimetrOrSurface;
        public bool _IsCorrect;

        bool _IsWorking = true;


        

        
        void Update()
        {
            if (_IsWorking)
            {
                if (gameObject.GetComponent<LrTesting>()._IsFinished && (InitialDots.Any()))
                {
                    //Debug.Log(" Is Empty = " + !InitialDots.Any());
                    _IsWorking = false;
                    ChangeDotPos();
                }
            }
        }


        void ChangeDotPos()
        {
            int childrenCount = gameObject.transform.childCount;
            for (int i = 0; i < childrenCount; i++)
            {
                gameObject.transform.GetChild(i).transform.position = InitialDots[i].transform.position;
            }

            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                Childs.Add(gameObject.transform.GetChild(i).gameObject);
            }
        }


        public void CheckFigure()
        {
            //Debug.Log("CheckFigure() = "); 
        }

    }
}
