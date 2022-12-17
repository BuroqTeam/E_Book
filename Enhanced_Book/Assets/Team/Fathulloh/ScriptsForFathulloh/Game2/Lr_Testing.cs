using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game2_Fathulloh
{
    public class Lr_Testing : MonoBehaviour
    {
        public bool _IsFinished = false;
        [SerializeField] private Transform[] Points;
        [SerializeField] private LineManager LineM;


        
        private void Start()
        {            
            LineM.SetUpLine(Points);

            _IsFinished = true;
        }


    }
}
