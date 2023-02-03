using LightShaft.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : MonoBehaviour
{
    public GameObject YoutubePlayerObject;
    public VideoUrlSO VideoEvent;

    public List<string> VideoLinks;
    

    //public TextAsset DataCSV;


    private void Awake()
    {
        CheckVideoLink();        
    }


    void Start()
    {
        
    }

        
    
    void CheckVideoLink()
    {
        string sceneName = VideoEvent.sceneName;
        if (sceneName == "media1")
        {
            YoutubePlayerObject.GetComponent<YoutubePlayer>().youtubeUrl = VideoLinks[0];
        }
        else if (sceneName == "media2")
        {
            YoutubePlayerObject.GetComponent<YoutubePlayer>().youtubeUrl = VideoLinks[1];
        }
        else if (sceneName == "media3")
        {
            YoutubePlayerObject.GetComponent<YoutubePlayer>().youtubeUrl = VideoLinks[2];
        }
        else if (sceneName == "ustoz1")
        {
            YoutubePlayerObject.GetComponent<YoutubePlayer>().youtubeUrl = VideoLinks[3];
        }
        else if (sceneName == "ustoz2")
        {
            YoutubePlayerObject.GetComponent<YoutubePlayer>().youtubeUrl = VideoLinks[3];
        }
    }


    public void TestBackButton()
    {
        Debug.Log("Back Button on VideoPlayerScene is working.");
    }
    
}
