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
        private int CountGeoboardFigures = 0;
        public Board BoardOfHooks;
        public TMP_Text QuestionText;
        public GameObject QuestionTablo;
        public List<GameObject> GeoBoardFigures;
        public List<GameObject> LineManagers;

        //private List<string> Questions = new() { "Can you make right triangle", "Can you make square", "Can you make isosceles right triangle", "Can you make rhombus", "Can you make an obtuse scalene triangle" };
        List<string> Questions = new()
        {
            $"To'g'ri burchakli uchburchak yasang.",  //Yuzasi {n0} kv. cm bo'lgan uchburchakni yasang.
            $"Perimetri {n1} cm ga teng bo'lgan kvadrat yasang.",
            $"Teng yonli to'g'ri burchakli uchburchak yasang.", // Yuzasi {n2} kv. cm bo'lgan teng yonli to'g'ri burchakli uchburchak yasang.
            $"Perimetri {n3} cm ga teng bo'lgan to'rtburchakni yasang.",
            $"Turli tomonli uchburchakni yasang." // Yuzasi {n4} kv. cm ga teng bo'lgan turli tomonli uchburchakni yasang.
        };

        const int n0 = 12, n1 = 16, n2 = 8, n3 = 14, n4 = 5;

        public int CurrentTask;
        public int TotalTask;

        public Calculate GCalculate;

        public GameObject CurrentFigure;
        public GameObject CurrentLineManager;
        bool _IsChanged = false;


        void Start()
        {

        }


        void Update()
        {
            if (_IsCheck)
            {
                for (int i = 0; i < GeoBoardFigures.Count; i++)
                {   // Shakllar to'liq chizilgan yoki yo'qligini tekshiradi.
                    bool isTrue = GeoBoardFigures[i].GetComponent<Lr_Testing>()._IsFinished;
                    if (isTrue)
                    {
                        CountGeoboardFigures += 1;
                    }
                }

                if (CountGeoboardFigures == GeoBoardFigures.Count)                {
                    _IsCheck = false;
                    SwitchOffFigures();
                }
                else if (CountGeoboardFigures != GeoBoardFigures.Count)                {
                    CountGeoboardFigures = 0;
                }
            }
        }

                

        /// <summary>
        /// Barcha shakllarni o'chirib keraklisini qaytadan yoquvchi shakl.
        /// </summary>
        public void SwitchOffFigures()
        {   
            for (int i = 0; i < GeoBoardFigures.Count; i++)
            {
                GeoBoardFigures[i].SetActive(false);
                LineManagers[i].SetActive(false);
            }

            for (int i = 0; i < GeoBoardFigures.Count; i++)
            {
                if (CurrentTask >= TotalTask)
                {
                    GCalculate.FinishEvent.Invoke();
                    break;
                }
                else if ((i == CurrentTask) /*|| (CurrentTask <= TotalTask)*/)
                {
                    CurrentTask++;
                    QuestionTablo.transform.GetChild(0).GetComponent<TMP_Text>().text = CurrentTask.ToString() + " / " + TotalTask.ToString();

                    GeoBoardFigures[i].SetActive(true);
                    LineManagers[i].SetActive(true);
                    QuestionText.text = Questions[i];

                    CurrentLineManager = LineManagers[i];
                    CurrentFigure = GeoBoardFigures[i];
                    GCalculate.CurrentFigure = CurrentFigure;                    
                    break;
                }
            }

            if (!_IsChanged)
            {
                ChangePosition(); ;
                _IsChanged = true;
            }            
        }


        public void ChangePosition()
        {
            List<GameObject> Hooks = BoardOfHooks.Hooks;

            //  GeoBoardFigures[0] Make Right Triangle
            GeoBoardFigures[0].GetComponent<GeoFigure>().InitialDots.Add(Hooks[23]);
            GeoBoardFigures[0].GetComponent<GeoFigure>().InitialDots.Add(Hooks[32]);
            GeoBoardFigures[0].GetComponent<GeoFigure>().InitialDots.Add(Hooks[37]);

            GeoBoardFigures[0].GetComponent<GeoFigure>().PerimetrOrSurface = n0;

            //  GeoBoardFigures[1] Make Square
            GeoBoardFigures[1].GetComponent<GeoFigure>().InitialDots.Add(Hooks[23]);
            GeoBoardFigures[1].GetComponent<GeoFigure>().InitialDots.Add(Hooks[25]);
            GeoBoardFigures[1].GetComponent<GeoFigure>().InitialDots.Add(Hooks[32]);
            GeoBoardFigures[1].GetComponent<GeoFigure>().InitialDots.Add(Hooks[30]);

            GeoBoardFigures[1].GetComponent<GeoFigure>().PerimetrOrSurface = n1;

            //  GeoBoardFigures[2] Make Isoscales Right Triangle
            GeoBoardFigures[2].GetComponent<GeoFigure>().InitialDots.Add(Hooks[23]);
            GeoBoardFigures[2].GetComponent<GeoFigure>().InitialDots.Add(Hooks[32]);
            GeoBoardFigures[2].GetComponent<GeoFigure>().InitialDots.Add(Hooks[37]);

            GeoBoardFigures[2].GetComponent<GeoFigure>().PerimetrOrSurface = n2;

            //  GeoBoardFigures[3] Make Rhombus Square
            GeoBoardFigures[3].GetComponent<GeoFigure>().InitialDots.Add(Hooks[23]);
            GeoBoardFigures[3].GetComponent<GeoFigure>().InitialDots.Add(Hooks[25]);
            GeoBoardFigures[3].GetComponent<GeoFigure>().InitialDots.Add(Hooks[32]);
            GeoBoardFigures[3].GetComponent<GeoFigure>().InitialDots.Add(Hooks[30]);

            GeoBoardFigures[3].GetComponent<GeoFigure>().PerimetrOrSurface = n3;

            //  GeoBoardFigures[4] Make Rhombus Square
            GeoBoardFigures[4].GetComponent<GeoFigure>().InitialDots.Add(Hooks[24]);
            GeoBoardFigures[4].GetComponent<GeoFigure>().InitialDots.Add(Hooks[32]);
            GeoBoardFigures[4].GetComponent<GeoFigure>().InitialDots.Add(Hooks[38]);

            GeoBoardFigures[4].GetComponent<GeoFigure>().PerimetrOrSurface = n4;

        }


        public Color InitialColor;
        public Color InitialColorCorner;
        bool _IsFirstTime = true;
        public void ErrorAnimation()
        {            
            if (_IsFirstTime)
            {
                InitialColor = CurrentLineManager.GetComponent<LineRenderer>().startColor;
                InitialColorCorner = CurrentFigure.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
                _IsFirstTime = false;
            }
            
            StartCoroutine(ErrorAnimating());
        }


        IEnumerator ErrorAnimating()
        {
            for (int i = 0; i < CurrentFigure.transform.childCount; i++)
            {
                CurrentFigure.transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(0.91f, 0.09f, 0.09f);
            }

            CurrentLineManager.GetComponent<LineRenderer>().endColor = new Color(0.5f, 0.12f, 0.22f, 1);
            CurrentLineManager.GetComponent<LineRenderer>().startColor = new Color(0.5f, 0.12f, 0.22f, 1);
            yield return new WaitForSeconds(0.5f);

            CurrentLineManager.GetComponent<LineRenderer>().endColor = InitialColor;
            CurrentLineManager.GetComponent<LineRenderer>().startColor = InitialColor;

            for (int i = 0; i < CurrentFigure.transform.childCount; i++)
            {
                CurrentFigure.transform.GetChild(i).GetComponent<SpriteRenderer>().color = InitialColorCorner;
            }
        }


    }
}
