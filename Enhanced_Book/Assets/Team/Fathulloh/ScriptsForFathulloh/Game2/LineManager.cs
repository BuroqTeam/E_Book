using UnityEngine;

namespace Game2_Fathulloh
{
    /// <summary>
    /// LineRenderer chiziq chizish uchun ishlatiladigan componentasi. 
    /// </summary>
    public class LineManager : MonoBehaviour
    {
        private LineRenderer LineR;
        private Transform[] Points;


        private void Awake()
        {
            LineR = GetComponent<LineRenderer>();
        }



        public void SetUpLine(Transform[] points)
        {
            LineR.positionCount = points.Length;
            this.Points = points;

        }



        private void Update()
        {
            for (int i = 0; i < Points.Length; i++)
            {
                LineR.SetPosition(i, Points[i].position);
            }
        }

        //private LineRenderer LineR;
        //private Transform[] Points;


        //private void Awake()
        //{
        //    LineR = GetComponent<LineRenderer>();
        //}


        //public void SetUpLine(Transform[] points)
        //{
        //    LineR.positionCount = points.Length;
        //    this.Points = points;
        //}


        //private void Update()
        //{
        //    for (int i = 0; i < Points.Length; i++)            
        //        LineR.SetPosition(i, Points[i].position);            
        //}





    }
}
