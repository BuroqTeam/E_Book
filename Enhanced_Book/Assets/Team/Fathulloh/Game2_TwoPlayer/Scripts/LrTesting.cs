using UnityEngine;

namespace Game2_TwoPlayer
{
    public class LrTesting : MonoBehaviour
    {
        public bool _IsFinished = false;
        [SerializeField] private Transform[] points;
        [SerializeField] private LineController lineControl;


        void Start()
        {
            lineControl.SetUpLine(points);
            _IsFinished = true;
        }


        
    }
}
