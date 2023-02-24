using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace FathullohVideoPlayer
{
    /// <summary>
    /// Videolarni unityni ichiga joylab VideoPlayer orqali play qiladigan bo'ldik.
    /// </summary>
    public class VideoController : MonoBehaviour
    {
        public List<VideoClip> Videos;
        public VideoNameSO VideoEvent;
        public GameObject MyVideoPlayer;


        private void Awake()
        {
            CheckCurrentVideo();
            
        }



        void CheckCurrentVideo()
        {
            string nameVideo = VideoEvent.VideoName;
            //Debug.Log(nameVideo);
            if (nameVideo == "Media 1")
            {
                MyVideoPlayer.GetComponent<VideoPlayer>().clip = Videos[0];
            }
            else if (nameVideo == "Media 2")
            {
                MyVideoPlayer.GetComponent<VideoPlayer>().clip = Videos[1];
            }
            else if (nameVideo == "Media 3")
            {
                MyVideoPlayer.GetComponent<VideoPlayer>().clip = Videos[2];
            }
            else if (nameVideo == "Video 1")
            {
                MyVideoPlayer.GetComponent<VideoPlayer>().clip = Videos[3];
            }
            else if (nameVideo == "Video 2")
            {
                MyVideoPlayer.GetComponent<VideoPlayer>().clip = Videos[4];
            }
            else
            {
                MyVideoPlayer.GetComponent<VideoPlayer>().clip = Videos[0];
            }
            PlayVideoPlayer();
        }


        void PlayVideoPlayer()
        {
            MyVideoPlayer.GetComponent<VideoPlayer>().Play();
        }
        
    }
}
