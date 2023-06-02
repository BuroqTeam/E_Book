using System;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePlayerNumber : MonoBehaviour
{
    public string NextSceneName = null;
    public Button BoshlashBut;

    public GameObject FirstButton;
    public GameObject SecondButton;

    public string FirstScene;
    public string SecondScene;
    public SceneLoader SLoader;


    public void ChangeSceneName(string sceneName)
    {
        if (sceneName == FirstScene)
        {
            NextSceneName = sceneName;
            FirstButton.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
            SecondButton.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (sceneName == SecondScene)
        {
            NextSceneName = sceneName;
            SecondButton.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
            FirstButton.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    
    
    public void NextScenePlay()
    {
        bool isNull = String.IsNullOrEmpty(NextSceneName);
        if (isNull)
        {
            //Debug.Log("Null");
        }
        else if (!isNull)
        {
            SLoader.LoadSceneByName(NextSceneName);
        }
    }


}
