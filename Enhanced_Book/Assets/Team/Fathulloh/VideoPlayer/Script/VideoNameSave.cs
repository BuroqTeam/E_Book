using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoNameSave : MonoBehaviour
{
    public VideoNameSO NextSceneData;

    
    void Start()
    {
        
    }


    public void WriteVideoName(string nameVideo)
    {
        NextSceneData.VideoName = nameVideo;
    }

    
}
