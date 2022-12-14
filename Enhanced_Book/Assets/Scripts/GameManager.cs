using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<string> GameScenes;
    public List<string> QuizScenes;
    public List<string> MediaScenes;

    public static GameManager Instance;


    private void Awake()
    {
        Instance = this;


    }


    void Update()
    {
        if (Input.GetKey("escape"))
        {            
            Application.Quit();
        }
    }
}
