using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
   
    [Scene]
    public string SceneTobeLoaded;   

    public void LoadDesiredScene()
    {
        SceneManager.LoadScene(SceneTobeLoaded, LoadSceneMode.Single);
    }


}
