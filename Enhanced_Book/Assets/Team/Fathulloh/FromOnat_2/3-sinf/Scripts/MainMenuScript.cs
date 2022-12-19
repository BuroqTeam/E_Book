using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using I2.Loc;
using UnityEngine.SceneManagement;
//using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.AsyncOperations;
//using UnityEngine.ResourceManagement.ResourceProviders;

public class MainMenuScript : MonoBehaviour
{
    //public AssetReference[] AddressableCsvGroup;
    public Dropdown languageChanger;
    public Sprite[] dropDownFlags;
    public static int languageIndex;
    public static int levelIndex;
    public Slider loadingBar;
    public GameObject loadingPanel;
    string levelNameMain;
    public Image flagImage;
    public GameObject noInternet;
    //string languageName;

    void Start()
    {
        SetFlags();
        LoadLAnguage();
        SetLanguage();
    }

    void LoadLAnguage() 
    {
        if (!PlayerPrefs.HasKey("Language"))
        {
            PlayerPrefs.SetInt("Language", languageChanger.value);
            languageChanger.value = PlayerPrefs.GetInt("Language");
        }
        else
        {
            languageChanger.value = PlayerPrefs.GetInt("Language");
        }
    }

    public void SetLanguage()
    {
        //if (MainMenuScript.languageIndex == 0) { languageName = "Uzbek"; }
        //else if (MainMenuScript.languageIndex == 1) { languageName = "karakalpak"; }
        //else if (MainMenuScript.languageIndex == 2) { languageName = "Kazakh"; }
        //else if (MainMenuScript.languageIndex == 3) { languageName = "Kirghiz"; }
        //else if (MainMenuScript.languageIndex == 4) { languageName = "Turkmen"; }
        //else if (MainMenuScript.languageIndex == 5) { languageName = "Tajik"; }
        //else if (MainMenuScript.languageIndex == 6) { languageName = "Russian"; }

        //LocalizationManager.CurrentLanguage = languageName;
    }

    public void SetFlags() 
    {
        languageChanger.ClearOptions();

        List<Dropdown.OptionData> flags = new List<Dropdown.OptionData>();

        foreach (var flag in dropDownFlags)
        {
            var flagOption = new Dropdown.OptionData(flag.name, flag);
            flags.Add(flagOption);
        }

        languageChanger.AddOptions(flags);
    }

    public void SetLanguageIndex()
    {
        languageIndex = languageChanger.value;
        SetLanguage();
        PlayerPrefs.SetInt("Language", languageChanger.value);
    }

    public void GetIndex(int index)
    {
        levelIndex = index;
    }

    public void BackToClassScene() 
    {
        SceneManager.LoadScene("ClassScene");
    }

    public void StartLevel(string levelName)
    {
        if (!PlayerPrefs.HasKey("AddressableLoaded"))
        {
            if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
            {
                levelNameMain = levelName;
                StartCoroutine(StartLevel_Coroutine(levelNameMain));
            }
            else
            {
                noInternet.SetActive(true);
            }
        }

        else if (PlayerPrefs.HasKey("AddressableLoaded"))
        {
            levelNameMain = levelName;
            StartCoroutine(StartLevel_Coroutine(levelNameMain));
        }
    }

    IEnumerator StartLevel_Coroutine(string levelName)
    {
        //AsyncOperationHandle loading = Addressables.LoadSceneAsync(levelName, LoadSceneMode.Single);
        //loadingPanel.SetActive(true);
        //float time = 0;

        //while (loadingBar.value < 0.9f && !loading.IsDone)
        //{
        //    float progress = Mathf.Clamp01(loading.PercentComplete);
            
        //    loadingBar.value = Mathf.Lerp(loadingBar.value, progress, time / 100);
        //    time += Time.deltaTime;

        //    if (loading.PercentComplete >= 0.9f)
        //    {
        //        if (!PlayerPrefs.HasKey("AddressableLoaded"))
        //        {
        //            PlayerPrefs.SetInt("AddressableLoaded", 1);
        //        }

        //        loadingBar.value = loadingBar.maxValue;
        //    }

            yield return null;

        //}

    }



}
