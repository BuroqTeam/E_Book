using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game2_TwoPlayer
{
    public class GameManage : MonoBehaviour
    {
        public enum PlayerOrder { FirstPlayer, SecondPlayer };
        public PlayerOrder CurrentPlayer;
        public bool _IsCheck = true;
        private int CountGeoboardFigures = 0;

        public GeoBoard BoardOfHooks;
        public TMP_Text QuestionText;
        public GameObject TaskTablo;

        [HideInInspector] public int CurrentTask = 5;
        public int TotalTask;

        public List<GameObject> GeoBoardFigures;
        public List<GameObject> LineManagers;

        public Calculate GCalculate;
        [HideInInspector] public GameObject CurrentFigure;
        [HideInInspector] public GameObject CurrentLineManager;
        bool _IsChanged = false;


        public List<string> Questions = new();
        int q0, q1, q2, q3, q4;
        List<string> Questions_1 = new()
        {
            $"To'g'ri burchakli uchburchak yasang.",
            $"Perimetri {n1} cm ga teng bo'lgan kvadrat yasang.",
            $"Teng yonli uchburchak yasang.",
            $"Perimetri {n3} cm ga teng bo'lgan to'rtburchakni yasang.",
            $"Turli tomonli uchburchakni yasang."
        };

        const int n0 = 0, n1 = 12, n2 = 0, n3 = 14, n4 = 0;


        List<string> Questions_2 = new()
        {
            $"Asosi {n5} bo‘lgan teng yonli uchburchak yasang.",
            $"Perimetri {n6} cm ga teng bo'lgan kvadrat yasang.",
            $"Turli tomonli uchburchakni yasang.",
            $"Perimetri {n8} cm ga teng bo'lgan to'rtburchakni yasang.",
            $"Asosi {n9} bo‘lgan turli tomonli uchburchak yasang."
        };

        const int n5 = 2, n6 = 8, n7 = 0, n8 = 10, n9 = 3;


        private void Start()
        {
            CheckPlayerOrder();
        }


        public void CheckPlayerOrder()
        {
            if (CurrentPlayer == PlayerOrder.FirstPlayer)
            {
                Questions = new(Questions_1);
                //Debug.Log("First");
                q0 = n0;
                q1 = n1;
                q2 = n2;
                q3 = n3;
                q4 = n4;
            }
            else if (CurrentPlayer == PlayerOrder.SecondPlayer)
            {
                Questions = new(Questions_2);
                //Debug.Log("Second");
                q0 = n5;
                q1 = n6;
                q2 = n7;
                q3 = n8;
                q4 = n9;
            }
        }


        void Update()
        {
            if (_IsCheck)
            {
                for (int i = 0; i < GeoBoardFigures.Count; i++)
                {
                    bool isTrue = GeoBoardFigures[i].GetComponent<LrTesting>()._IsFinished;
                    if (isTrue)
                        CountGeoboardFigures += 1;
                }

                if (CountGeoboardFigures == GeoBoardFigures.Count)
                {
                    _IsCheck = false;
                    SwitchOffFigures();
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
            //Debug.Log("CurrentTask = " + CurrentTask);
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
                    TaskTablo.transform.GetChild(0).GetComponent<TMP_Text>().text = CurrentTask.ToString() + " / " + TotalTask.ToString();

                    GeoBoardFigures[i].SetActive(true);
                    LineManagers[i].SetActive(true);

                    QuestionText.text = Questions[i];

                    CurrentLineManager = LineManagers[i];
                    CurrentFigure = GeoBoardFigures[i];

                    if (CurrentPlayer == PlayerOrder.FirstPlayer)                    
                        GCalculate.CurrentFigure_First = CurrentFigure;                    
                    else if (CurrentPlayer == PlayerOrder.SecondPlayer)                    
                        GCalculate.CurrentFigure_Second = CurrentFigure;                    
                    
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
            GeoBoardFigures[0].GetComponent<GeoFigure>().InitialDots.Add(Hooks[0]);
            GeoBoardFigures[0].GetComponent<GeoFigure>().InitialDots.Add(Hooks[7]);
            GeoBoardFigures[0].GetComponent<GeoFigure>().InitialDots.Add(Hooks[18]);

            GeoBoardFigures[0].GetComponent<GeoFigure>().PerimetrOrSurface = q0;

            //  GeoBoardFigures[1] Make Square with perimetr
            GeoBoardFigures[1].GetComponent<GeoFigure>().InitialDots.Add(Hooks[0]);
            GeoBoardFigures[1].GetComponent<GeoFigure>().InitialDots.Add(Hooks[1]);
            GeoBoardFigures[1].GetComponent<GeoFigure>().InitialDots.Add(Hooks[7]);
            GeoBoardFigures[1].GetComponent<GeoFigure>().InitialDots.Add(Hooks[6]);

            GeoBoardFigures[1].GetComponent<GeoFigure>().PerimetrOrSurface = q1;

            //  GeoBoardFigures[2] Make Isoscales Triangle
            GeoBoardFigures[2].GetComponent<GeoFigure>().InitialDots.Add(Hooks[0]);
            GeoBoardFigures[2].GetComponent<GeoFigure>().InitialDots.Add(Hooks[2]);
            GeoBoardFigures[2].GetComponent<GeoFigure>().InitialDots.Add(Hooks[6]);

            GeoBoardFigures[2].GetComponent<GeoFigure>().PerimetrOrSurface = q2;

            //  GeoBoardFigures[3] Make Right Triangle with perimetr
            GeoBoardFigures[3].GetComponent<GeoFigure>().InitialDots.Add(Hooks[0]);
            GeoBoardFigures[3].GetComponent<GeoFigure>().InitialDots.Add(Hooks[1]);
            GeoBoardFigures[3].GetComponent<GeoFigure>().InitialDots.Add(Hooks[7]);
            GeoBoardFigures[3].GetComponent<GeoFigure>().InitialDots.Add(Hooks[6]);

            GeoBoardFigures[3].GetComponent<GeoFigure>().PerimetrOrSurface = q3;

            //  GeoBoardFigures[4] Make Right Triangle with perimetr
            GeoBoardFigures[4].GetComponent<GeoFigure>().InitialDots.Add(Hooks[0]);
            GeoBoardFigures[4].GetComponent<GeoFigure>().InitialDots.Add(Hooks[1]);
            GeoBoardFigures[4].GetComponent<GeoFigure>().InitialDots.Add(Hooks[6]);

            GeoBoardFigures[4].GetComponent<GeoFigure>().PerimetrOrSurface = q4;
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
