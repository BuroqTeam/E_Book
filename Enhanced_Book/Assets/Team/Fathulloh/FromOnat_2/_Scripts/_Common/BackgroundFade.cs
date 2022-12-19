using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ActionManager;

public class BackgroundFade : MonoBehaviour
{
    public Color color;
    SpriteRenderer sp;


    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();

        
    }


    public void Finish()
    {
        sp.color = color;
        //StartCoroutine(Actions.FadeOverTime(sp, 150.0f, 0.25f));
        
    }
    
}
