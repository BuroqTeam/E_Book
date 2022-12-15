using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game2_Fathulloh
{
    public class Lr_Testing : MonoBehaviour
    {
        [SerializeField] private Transform[] Points;
        [SerializeField] private LineManager LineM;


        [SerializeField]
        private void Start()
        {
            LineM.SetUpLine(Points);
        }


    }
}
