using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Sun : MonoBehaviour
{
    public float speed;


    private void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        
    }
    

}
