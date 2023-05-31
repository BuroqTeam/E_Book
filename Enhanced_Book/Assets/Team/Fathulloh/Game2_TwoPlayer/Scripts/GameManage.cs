using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game2_TwoPlayer
{
    public class GameManage : MonoBehaviour
    {
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


        List<string> Questions_1 = new()
        {
            $"To'g'ri burchakli uchburchak yasang.",
            $"Perimetri {n1} cm ga teng bo'lgan kvadrat yasang.",
            $"Teng yonli to'g'ri burchakli uchburchak yasang.",
            $"Perimetri {n3} cm ga teng bo'lgan to'rtburchakni yasang.",
            $"Turli tomonli uchburchakni yasang."
        };
        const int n0 = 12, n1 = 16, n2 = 8, n3 = 14, n4 = 5;


        List<string> Questions_2 = new()
        {
            $"Asosi {n5} bo‘lgan teng yonli uchburchak yasang.",
            $"Perimetri {n6} cm ga teng bo'lgan kvadrat yasang.",
            $"Teng yonli to'g'ri burchakli uchburchak yasang.",
            $"Perimetri {n8} cm ga teng bo'lgan to'rtburchakni yasang.",
            $"Turli tomonli uchburchakni yasang."
        };
        const int n5 = 4, n6 = 12, n7 = 0, n8 = 10, n9 = 0;



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
                    QuestionText.text = Questions_1[i];

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
            GeoBoardFigures[0].GetComponent<GeoFigure>().InitialDots.Add(Hooks[0]);
            GeoBoardFigures[0].GetComponent<GeoFigure>().InitialDots.Add(Hooks[6]);
            GeoBoardFigures[0].GetComponent<GeoFigure>().InitialDots.Add(Hooks[7]);

            GeoBoardFigures[0].GetComponent<GeoFigure>().PerimetrOrSurface = n0;
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
