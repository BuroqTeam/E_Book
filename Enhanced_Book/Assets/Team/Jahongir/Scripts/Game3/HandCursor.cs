using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCursor : MonoBehaviour
{
    public GameObject Object1;
    public GameObject Object2;



    void Start()
    {
        
    }


    public IEnumerator HandAnimation()
    {
        yield return new WaitForSeconds(0);
    }
}
