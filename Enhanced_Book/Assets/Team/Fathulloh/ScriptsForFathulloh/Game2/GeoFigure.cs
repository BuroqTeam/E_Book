using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game2_Fathulloh
{    
    public class GeoFigure : MonoBehaviour
    {
        public enum FigureType {RightTriangle, Square, IsoscelesRightTriangle, Rhombus, ObtuseScaleneTriangle, Pentagon, Rectangle, Paralellogram }
        public FigureType CurrentFigure;
        bool _IsWorking = true;
        /// <summary>
        /// Uchburchakning boshlang'ich paytdagi nuqtalari.
        /// </summary>
        public List<GameObject> InitialDots;

        public List<GameObject> Childs;

        public int PerimetrOrSurface;
        public bool _IsCorrect;



        void Start()
        {

        }


        void Update()
        {
            if (_IsWorking)
            {
                if ( gameObject.GetComponent<Lr_Testing>()._IsFinished && (InitialDots.Any()) )
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
                case FigureType.RightTriangle:
                    //CheckRightTriangle();
                    CheckRightTrianglewithPifagor();
                    break;
                case FigureType.Square:
                    CheckSquare();
                    break;
                case FigureType.IsoscelesRightTriangle:
                    CheckIsoscalesRightTriangle();
                    break;
                case FigureType.Rhombus:
                    CheckRhombus();
                    break;
                case FigureType.ObtuseScaleneTriangle:
                    CheckObtuseScaleneTriangle();
                    break;
                case FigureType.Pentagon:
                    break;
                case FigureType.Rectangle:
                    break;
                case FigureType.Paralellogram:
                    break;
                default:
                    break;
            }
        }


        public void CheckRightTriangle()
        {
            float distance1, distance2, distance3;
            distance1 = Vector3.Distance(Childs[0].transform.position, Childs[1].transform.position);
            distance2 = Vector3.Distance(Childs[1].transform.position, Childs[2].transform.position);
            distance3 = Vector3.Distance(Childs[2].transform.position, Childs[0].transform.position);

            float halfPer = (distance1 + distance2 + distance3) / 2;
            float areaTriangle = Mathf.Sqrt(halfPer * (halfPer - distance1) * (halfPer - distance2) * (halfPer - distance3));
            if ((int)areaTriangle / 1 == PerimetrOrSurface || (PerimetrOrSurface - areaTriangle < 0.1f)) 
            {
                _IsCorrect = true;
                //Debug.Log("To'g'ri     areaTriangle = " + areaTriangle + " PerimetrOrSurface = " + PerimetrOrSurface);
            }
            else
            {
                _IsCorrect = false;
                //Debug.Log("Xato        areaTriangle = " + areaTriangle + " PerimetrOrSurface = " + PerimetrOrSurface);
            }    
        }

        public void CheckRightTrianglewithPifagor()
        {
            float distance1, distance2, distance3;
            distance1 = Vector3.Distance(Childs[0].transform.position, Childs[1].transform.position);
            distance2 = Vector3.Distance(Childs[1].transform.position, Childs[2].transform.position);
            distance3 = Vector3.Distance(Childs[2].transform.position, Childs[0].transform.position);

            if (distance1 == Mathf.Sqrt(distance2 * distance2 + distance3 * distance3) /*&& (distance1 + distance2 + distance3 == PerimetrOrSurface)*/)
            {
                _IsCorrect = true;
            }
            else if (distance2 == Mathf.Sqrt(distance1 * distance1 + distance3 * distance3) /*&& (distance1 + distance2 + distance3 == PerimetrOrSurface)*/)
            {
                _IsCorrect = true;
            }
            else if (distance3 == Mathf.Sqrt(distance2 * distance2 + distance1 * distance1) /*&& (distance1 + distance2 + distance3 == PerimetrOrSurface)*/)
            {
                _IsCorrect = true;
            }
            else
                _IsCorrect = false;
        }


        public void CheckSquare()
        {
            float distance1, distance2, distance3, distance4;
            distance1 = Vector3.Distance(Childs[0].transform.position, Childs[1].transform.position);
            distance2 = Vector3.Distance(Childs[1].transform.position, Childs[2].transform.position);
            distance3 = Vector3.Distance(Childs[2].transform.position, Childs[3].transform.position);
            distance4 = Vector3.Distance(Childs[3].transform.position, Childs[0].transform.position);

            if ((distance1 == distance3) && (distance2 == distance4) && (distance1 == distance2) && (distance1 * distance2 == PerimetrOrSurface))            
            {
                _IsCorrect = true;
            }
            else            
                _IsCorrect = false;
            
        }


        public void CheckIsoscalesRightTriangle()
        {
            float distance1, distance2, distance3;
            distance1 = Vector3.Distance(Childs[0].transform.position, Childs[1].transform.position);
            distance2 = Vector3.Distance(Childs[1].transform.position, Childs[2].transform.position);
            distance3 = Vector3.Distance(Childs[2].transform.position, Childs[0].transform.position);            

            if ((distance1 == Mathf.Sqrt(distance2 * distance2 + distance3 * distance3)) && (distance2 == distance3))
            {
                //if (distance2 *distance3 == PerimetrOrSurface * 2)
                //    _IsCorrect = true;
                _IsCorrect = true;
            }
            else if ((distance2 == Mathf.Sqrt(distance1 * distance1 + distance3 * distance3)) && (distance1 == distance3))
            {
                //if (distance1 * distance3 == PerimetrOrSurface * 2)
                //    _IsCorrect = true;
                _IsCorrect = true;
            }
            else if ((distance3 == Mathf.Sqrt(distance2 * distance2 + distance1 * distance1)) && (distance2 == distance1))
            {
                //if (distance2 * distance1 == PerimetrOrSurface * 2)
                //    _IsCorrect = true;
                _IsCorrect = true;
            }
            else
            {
                _IsCorrect = false;
                //Debug.Log("None     b1 = " + (distance1 == Mathf.Sqrt(distance2 * distance2 + distance3 * distance3)) );
            }
        }


        public void CheckRhombus()
        {
            float distance1 = Vector3.Distance(Childs[0].transform.position, Childs[1].transform.position);
            float distance2 = Vector3.Distance(Childs[1].transform.position, Childs[2].transform.position);
            float distance3 = Vector3.Distance(Childs[2].transform.position, Childs[3].transform.position);
            float distance4 = Vector3.Distance(Childs[3].transform.position, Childs[0].transform.position);
            float diogonal1 = Vector3.Distance(Childs[2].transform.position, Childs[0].transform.position);
            float diogonal2 = Vector3.Distance(Childs[3].transform.position, Childs[1].transform.position);

            float perimetr = (distance1 + distance2 + distance3 + distance4);

            Vector3 vec0 = Childs[0].transform.position;
            Vector3 vec1 = Childs[1].transform.position;
            Vector3 vec2 = Childs[2].transform.position;
            Vector3 vec3 = Childs[3].transform.position;

            if (PerimetrOrSurface == perimetr && (distance4 == distance2) && (distance1 == distance3))
            {
                _IsCorrect = true;
                //Debug.Log("(distance1 + distance2 + distance3 + distance4) = " + (distance1 + distance2 + distance3 + distance4));
            }
            else
            {
                _IsCorrect = false;
                //Debug.Log("(distance1 + distance2 + distance3 + distance4) = " + (distance1 + distance2 + distance3 + distance4));
            }

            //if ((distance1 == distance3) && (distance2 == distance4) && (distance2 == distance1) && (vec0 != vec1))
            //{
            //    if ((vec0.x == vec2.x || vec0.y == vec2.y) && (vec1.x == vec3.x || vec1.y == vec3.y) && (diogonal1 * diogonal2 / 2 == PerimetrOrSurface))
            //    {
            //        _IsCorrect = true;
            //        Debug.Log("Romb ishladi.");
            //    }
            //    else
            //        _IsCorrect = false;
            //}
            //else      
            //    _IsCorrect = false;            
        }


        public void CheckObtuseScaleneTriangle()
        {
            float distance1 = Vector3.Distance(Childs[0].transform.position, Childs[1].transform.position);
            float distance2 = Vector3.Distance(Childs[1].transform.position, Childs[2].transform.position);
            float distance3 = Vector3.Distance(Childs[2].transform.position, Childs[0].transform.position);

            if ((distance1 != distance2) && (distance2 != distance3) && (distance1 != distance3))
            {
                _IsCorrect = true;
                //float halfPerimetr = (distance1 + distance2 + distance3) / 2;
                //float areaTriangle = Mathf.Sqrt(halfPerimetr * (halfPerimetr - distance1) * (halfPerimetr - distance2) * (halfPerimetr - distance3));
                
                //if ((areaTriangle == PerimetrOrSurface) || (PerimetrOrSurface == (areaTriangle / 1)) || (PerimetrOrSurface - areaTriangle < 0.1f ) )               {
                //    Debug.Log("areaTriangle " + areaTriangle);
                //    _IsCorrect = true;
                //}
                //else
                //{
                //    _IsCorrect = false;
                //    Debug.Log("HalfPerimetr don't work.   " + areaTriangle + " " + areaTriangle / 1);
                //}                    
            }
            else
            {
                _IsCorrect = false;
            }                
        }
                

    }
}
