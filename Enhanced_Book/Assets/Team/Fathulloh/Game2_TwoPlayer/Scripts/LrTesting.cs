using UnityEngine;

namespace Game2_TwoPlayer
{
    public class LrTesting : MonoBehaviour
    {
        [HideInInspector] public bool _IsFinished = false;
        [SerializeField] private Transform[] points;
        [SerializeField] private LineController lineControl;


        /// <summary>
        /// Agar SetUpLine(points)ni chaqirmasak nuqtalar orasiga chiziqlarni chizib bermaydi.
        /// </summary>
        void Start()
        {
            lineControl.SetUpLine(points);
            _IsFinished = true;
        }


        //private void OnEnable()
        //{
        //    lineControl.SetUpLine(points);
        //    _IsFinished = true;
        //}

        

    }
}
