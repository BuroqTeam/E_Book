using LightShaft.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoManager : MonoBehaviour
{
    public GameObject YoutubePlayerObject;
    
    public VideoNameSO VideoEvent;
    public GameObject NoInternetPanel;
    public GameObject LoadingObj;
    public List<string> VideoLinks;

    //public static VideoManager Instance;
    //public TextAsset DataCSV;


    private void Awake()
    {
        CheckVideoLink();
        //NoInternetPanelActive();
    }


    void Start()
    {
        
    }

        
    
    void CheckVideoLink()
    {
        string sceneName = VideoEvent.VideoName;
        if (sceneName == "Media 1")
        {
            YoutubePlayerObject.GetComponent<YoutubePlayer>().youtubeUrl = VideoLinks[0];
        }
        else if (sceneName == "Media 2")
        {
            YoutubePlayerObject.GetComponent<YoutubePlayer>().youtubeUrl = VideoLinks[1];
        }
        else if (sceneName == "Media 3")
        {
            YoutubePlayerObject.GetComponent<YoutubePlayer>().youtubeUrl = VideoLinks[2];
        }
        else if (sceneName == "Video 1")
        {
            YoutubePlayerObject.GetComponent<YoutubePlayer>().youtubeUrl = VideoLinks[3];
        }
        else if (sceneName == "Video 2")
        {
            YoutubePlayerObject.GetComponent<YoutubePlayer>().youtubeUrl = VideoLinks[4];
        }
        else
        {
            Debug.Log("No name.");
            YoutubePlayerObject.GetComponent<YoutubePlayer>().youtubeUrl = VideoLinks[4];
        }
    }


    public void TestBackButton()
    {
        Debug.Log("Back Button on VideoPlayerScene is working.");
    }


    public void ClearText(GameObject obje)
    {
        Debug.Log("Cleare Text is working");
        obje.transform.GetChild(0).gameObject.GetComponent<Text>().text = "";
    }


    public void NoInternetPanelActive()
    {        
        Debug.Log("Write current scene name. " + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        //LoadingObj.SetActive(false);
        LoadingObj.transform.GetChild(0).gameObject.GetComponent<Text>().text = "";
        NoInternetPanel.SetActive(true);
    }


}
