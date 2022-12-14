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
        ChangeMediaSceneName();
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
            _sceneName = SceneName + " 3";

        }
        else
        {
            gameObject.SetActive(false);
        }
    }



}
