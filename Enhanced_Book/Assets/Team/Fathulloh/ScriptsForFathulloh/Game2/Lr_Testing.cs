using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game2_Fathulloh
{
    public class Lr_Testing : MonoBehaviour
    {
        [SerializeField] private Transform[] Points;
        [SerializeField] private LineManager LineM;


        
        private void Start()
        {
            Debug.Log(gameObject.name);
            LineM.SetUpLine(Points);
        }


    }
}
