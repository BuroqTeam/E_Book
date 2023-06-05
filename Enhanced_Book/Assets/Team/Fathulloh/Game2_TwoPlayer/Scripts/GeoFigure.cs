using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game2_TwoPlayer
{
    public enum FigureType
    {
        NoFigure,              // Hechqaysi shakl tanlanmagan
        RightTriangle,         // To‘g‘ri burchakli uchburchak
        SquareWithPerimetr,    // Kvadrat Parametr bilan
        IsoscelesTriangle,     // Teng yonli uchburchak
        RightRectangle,        // To‘g‘ri to‘rtburchak perimetr bilan.
        ScalenTriangle,        // Turli tomonli uchburchak
        IsoscelesTriangleBasis,   // Teng yonli uchburchak asos bilan birga
        ScalenTriangleBasis    // Turli tomonli uchburchak asos bilan birga
    }

    public class GeoFigure : MonoBehaviour
    {
        public FigureType CurrentFigure;

        /// <summary>
        /// Uchburchakning boshlang'ich paytdagi nuqtalari.
        /// </summary>
        public List<GameObject> InitialDots;
        public List<GameObject> Childs;

        /// <summary>
        /// perimetri yoki yuzasi. GameManager scipti orqali beriladi.
        /// </summary>
        public int PerimetrOrSurface;
        public bool _IsCorrect;  // Shakl to‘g‘ri yasalgan holatlarda true bo‘ladi.

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


        /// <summary>
        /// Geometrik figura to'g'ri yasalgan yoki yo'qligini tekshiradi.
        /// </summary>
        public void CheckFigure()
        {
            switch (CurrentFigure)
            {
                case FigureType.NoFigure:
                    Debug.Log("No figure");
                    break;
                case FigureType.RightTriangle:
                    CheckRightTriangle();
                    break;
                case FigureType.SquareWithPerimetr:
                    CheckSquare();
                    break;
                case FigureType.IsoscelesTriangle:
                    CheckIsoscelesTriangle();
                    break;
                case FigureType.RightRectangle:
                    CheckRectangle();
                    break;
                case FigureType.ScalenTriangle:
                    CheckScalenTriangles();
                    break;
                case FigureType.IsoscelesTriangleBasis:
                    CheckIsoscelesTriangleBasis();
                    break;
                case FigureType.ScalenTriangleBasis:
                    CheckScalenTriangleBasis();
                    break;
                default:
                    break;                    
            }
        }


        void CheckRightTriangle()
        {
            float distance1, distance2, distance3;
            distance1 = Vector3.Distance(Childs[0].transform.position, Childs[1].transform.position);
            distance2 = Vector3.Distance(Childs[1].transform.position, Childs[2].transform.position);
            distance3 = Vector3.Distance(Childs[2].transform.position, Childs[0].transform.position);
            //Debug.Log("distance1 = " + distance1 + " distance2 = " + distance2 + " distance3 = " + distance3);

            float sqr1 = Mathf.Sqrt(distance2 * distance2 + distance3 * distance3);  // pifagor
            float sqr2 = Mathf.Sqrt(distance1 * distance1 + distance3 * distance3);  // pifagor
            float sqr3 = Mathf.Sqrt(distance2 * distance2 + distance1 * distance1);  // pifagor

            if (distance1 == sqr1 /*|| (Mathf.Abs(distance1 - sqr1) < 0.01)*/)
            {
                _IsCorrect = true;
            }
            else if (distance2 == sqr2 /*|| (Mathf.Abs(distance2 - sqr2) < 0.01)*/)
            {
                _IsCorrect = true;
            }
            else if (distance3 == sqr3 /*|| (Mathf.Abs(distance3 - sqr3) < 0.01)*/)
            {
                _IsCorrect = true;
            }
            else
                _IsCorrect = false;
        }


        void CheckSquare()
        {
            float distance1, distance2, distance3, distance4;
            distance1 = Vector3.Distance(Childs[0].transform.position, Childs[1].transform.position);
            distance2 = Vector3.Distance(Childs[1].transform.position, Childs[2].transform.position);
            distance3 = Vector3.Distance(Childs[2].transform.position, Childs[3].transform.position);
            distance4 = Vector3.Distance(Childs[3].transform.position, Childs[0].transform.position);

            float currentPerimetr = distance1 + distance2 + distance3 + distance4; 

            if ((distance1 == distance3) && (distance2 == distance4) && (distance1 == distance2) && (currentPerimetr == PerimetrOrSurface))
            {
                _IsCorrect = true;
            }
            else
                _IsCorrect = false;
        }


        void CheckIsoscelesTriangle()
        {
            float distance1, distance2, distance3;
            distance1 = Vector3.Distance(Childs[0].transform.position, Childs[1].transform.position);
            distance2 = Vector3.Distance(Childs[1].transform.position, Childs[2].transform.position);
            distance3 = Vector3.Distance(Childs[2].transform.position, Childs[0].transform.position);
            
            //               condition ? true_expression : false_expression;
            _IsCorrect = ((distance1 == distance2) || (distance2 == distance3)) ? true : false;
        }


        void CheckRectangle()
        {
            float distance1, distance2, distance3, distance4;
            distance1 = Vector3.Distance(Childs[0].transform.position, Childs[1].transform.position);
            distance2 = Vector3.Distance(Childs[1].transform.position, Childs[2].transform.position);
            distance3 = Vector3.Distance(Childs[2].transform.position, Childs[3].transform.position);
            distance4 = Vector3.Distance(Childs[3].transform.position, Childs[0].transform.position);

            float currentPerimetr = distance1 + distance2 + distance3 + distance4;
            
            bool littleCondition = ((currentPerimetr == PerimetrOrSurface) && (distance1 == distance3) && (distance2 == distance4));

            _IsCorrect = littleCondition;
        }


        void CheckScalenTriangles()
        {
            float distance1, distance2, distance3;
            distance1 = Vector3.Distance(Childs[0].transform.position, Childs[1].transform.position);
            distance2 = Vector3.Distance(Childs[1].transform.position, Childs[2].transform.position);
            distance3 = Vector3.Distance(Childs[2].transform.position, Childs[0].transform.position);

            bool littleCondition = ((distance1 != distance2) && (distance2 != distance3));
            bool triangleCondition = ((distance1 + distance2 > distance3) && (distance2 + distance3 > distance1) && (distance1 + distance3 > distance2));

            _IsCorrect = (littleCondition && triangleCondition);
        }

        /// <summary>
        /// Teng yonli uchburchakni berilgan asosga ko‘ra chizilganligini tekshiradi.
        /// </summary>
        void CheckIsoscelesTriangleBasis()
        {
            float distance1, distance2, distance3;
            distance1 = Vector3.Distance(Childs[0].transform.position, Childs[1].transform.position);
            distance2 = Vector3.Distance(Childs[1].transform.position, Childs[2].transform.position);
            distance3 = Vector3.Distance(Childs[2].transform.position, Childs[0].transform.position);

            bool condition1 = ((distance1 == distance2) && (distance3 == PerimetrOrSurface));
            bool condition2 = ((distance2 == distance3) && (distance1 == PerimetrOrSurface));
            bool condition3 = ((distance1 == distance3) && (distance2 == PerimetrOrSurface));

            _IsCorrect = (condition1 || condition2 || condition3);
        }


        void CheckScalenTriangleBasis()
        {
            float distance1 = Vector3.Distance(Childs[0].transform.position, Childs[1].transform.position);
            float distance2 = Vector3.Distance(Childs[1].transform.position, Childs[2].transform.position);
            float distance3 = Vector3.Distance(Childs[2].transform.position, Childs[0].transform.position);

            bool cond1 = ((distance1 != distance2) && (distance2 != distance3));
            bool cond2 = ((distance1 == PerimetrOrSurface) || (distance2 == PerimetrOrSurface) || (distance3 == PerimetrOrSurface));

            _IsCorrect = (cond1 && cond2);
        }


    }
}
/*
        void CheckRightTriangle()
        {
            float distance1, distance2, distance3;
            distance1 = Vector3.Distance(Childs[0].transform.position, Childs[1].transform.position);
            distance2 = Vector3.Distance(Childs[1].transform.position, Childs[2].transform.position);
            distance3 = Vector3.Distance(Childs[2].transform.position, Childs[0].transform.position);

            float halfPer = (distance1 + distance2 + distance3) / 2;
            float areaTriangle = Mathf.Sqrt(halfPer * (halfPer - distance1) * (halfPer - distance2) * (halfPer - distance3));

            if ((int)areaTriangle / 1 == PerimetrOrSurface || (PerimetrOrSurface - areaTriangle < 0.1f))            
                _IsCorrect = true;            
            else            
                _IsCorrect = false;            
        }
 */