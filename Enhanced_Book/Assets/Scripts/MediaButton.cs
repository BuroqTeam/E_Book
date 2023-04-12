using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediaButton : MonoBehaviour
{
    public string SceneName;
    public string PageName1;
    public string PageName2;
    public string PageName3;

    public GameObject MediaPanel1;
    public GameObject MediaPanel2;

    public Image PageImg;
   


    Button _button;
    string _sceneName;


    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Onlclick);
        SaveDataForYoutubePlayerScene();
        //ChangeMediaSceneName();


        if (gameObject.name == "Tutor") //F++
        {
            SaveDataForYoutubePlayerScene();
        }
    }

    private void Onlclick()
    {
        GetComponent<SceneLoader>().LoadSceneByName(_sceneName);
    }

    public void ChangeMediaSceneName()
    {        
        if (PageImg.sprite.name.Equals(PageName1))
        {
            gameObject.SetActive(true);
            transform.SetParent(MediaPanel1.transform);
            _sceneName = SceneName + " 1";

        }
        else if (PageImg.sprite.name.Equals(PageName2))
        {
            gameObject.SetActive(true);
            transform.SetParent(MediaPanel2.transform);
            _sceneName = SceneName + " 2";

        }
        else if (PageImg.sprite.name.Equals(PageName3))
        {
            gameObject.SetActive(true);
            transform.SetParent(MediaPanel1.transform);
            _sceneName = SceneName + "3Update";

        }
        else
        {
            gameObject.SetActive(false);
        }
    }


    /// <summary>
    /// ForYoutubeVideos scene uchun VideoNameSo ga link nomini saqlab beradigan metodni chaqiradi.
    /// </summary>
    public void SaveDataForYoutubePlayerScene()   // F++
    {
        //Debug.Log("YoutubePlayerScene ishladi. ");
        GameObject nextSceneData = GameObject.Find("NextSceneDataSave");
        

        if (PageImg.sprite.name.Equals(PageName1))
        {
            gameObject.SetActive(true);
            transform.SetParent(MediaPanel1.transform);
            _sceneName = SceneName;
            nextSceneData.GetComponent<VideoNameSave>().WriteVideoName("Media 1");
        }
        else if (PageImg.sprite.name.Equals(PageName2))
        {
            gameObject.SetActive(true);
            transform.SetParent(MediaPanel2.transform);
            _sceneName = SceneName;
            nextSceneData.GetComponent<VideoNameSave>().WriteVideoName("Media 2");
        }
        else if (PageImg.sprite.name.Equals(PageName3))
        {
            gameObject.SetActive(true);
            transform.SetParent(MediaPanel1.transform);
            _sceneName = SceneName;
            nextSceneData.GetComponent<VideoNameSave>().WriteVideoName("Media 3");
        }
        else
        {
            gameObject.SetActive(false);
        }
    }


}
