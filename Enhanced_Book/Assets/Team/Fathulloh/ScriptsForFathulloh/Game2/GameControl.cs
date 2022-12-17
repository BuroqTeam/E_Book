using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game2_Fathulloh
{
    /// <summary>
    /// Game2 ning o'yinni boshqaruvchi kodlari yoziladigan script.
    /// </summary>
    public class GameControl : MonoBehaviour
    {
        public bool _IsCheck = true;
        public int CountGeoboardFigures = 0;
        public Board BoardOfHooks;
        public TMP_Text QuestionText;
        public List<GameObject> GeoBoardFigures;
        public List<GameObject> LineManagers;
        private List<string> Questions = new() { "Can you make right triangle", "Can you make square", "Can you make isosceles right triangle" };
        

        public int CurrentTask;
        public int TotalTask;



        void Start()
        {

        }
               


        void Update()
        {
            if (_IsCheck)
            {                
                for (int i = 0; i < GeoBoardFigures.Count; i++)
                {
                    bool isTrue = GeoBoardFigures[i].GetComponent<Lr_Testing>()._IsFinished;
                    if (isTrue)         {
                        CountGeoboardFigures += 1;
                    }
                }

                if (CountGeoboardFigures == GeoBoardFigures.Count)           {
                    _IsCheck = false;
                    SwitchOffFigures();
                }
                else if (CountGeoboardFigures != GeoBoardFigures.Count)      {
                    CountGeoboardFigures = 0;                    
                }
            }
        }


        public void SwitchOffFigures()
        {
            for (int i = 0; i < GeoBoardFigures.Count; i++)
            {
                GeoBoardFigures[i].SetActive(false);
                LineManagers[i].SetActive(false);
            }

            for (int i = 0; i < GeoBoardFigures.Count; i++)
            {
                if (i == 1/*CurrentTask*/)
                {                    
                    GeoBoardFigures[i].SetActive(true);
                    LineManagers[i].SetActive(true);
                    QuestionText.text = Questions[i];
                    break;
                }                
            }

            ChangePosition();
        }


        public void ChangePosition()
        {
            List<GameObject> Hooks = BoardOfHooks.Hooks;
            //  GeoBoardFigures[0] Make Right Triangle
            GeoBoardFigures[0].GetComponent<GeoFigure>().InitialDots.Add(Hooks[25]);
            GeoBoardFigures[0].GetComponent<GeoFigure>().InitialDots.Add(Hooks[30]);
            GeoBoardFigures[0].GetComponent<GeoFigure>().InitialDots.Add(Hooks[31]);

            //  GeoBoardFigures[1] Make Square
            GeoBoardFigures[1].GetComponent<GeoFigure>().InitialDots.Add(Hooks[23]);
            GeoBoardFigures[1].GetComponent<GeoFigure>().InitialDots.Add(Hooks[25]);
            GeoBoardFigures[1].GetComponent<GeoFigure>().InitialDots.Add(Hooks[32]);
            GeoBoardFigures[1].GetComponent<GeoFigure>().InitialDots.Add(Hooks[30]);



        }



    }
}
