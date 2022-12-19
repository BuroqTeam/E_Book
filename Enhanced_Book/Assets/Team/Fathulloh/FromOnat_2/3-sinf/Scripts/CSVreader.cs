using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.AsyncOperations;

public class CSVreader : MonoBehaviour
{
    public GamePlayController_3_1 gamePlayController;
    public List<TextAsset> localization;
    //public AssetReference[] assetReferences;
    public string[] strings;
    public string[] CSVdata;
    int language;
    public int languageIndex;
    int levelIndex;
    //1 - Uzbek
    //3 - Kazakh
    //5 - Kyrgyz
    //7 - Tajik
    //9 - Turkman
    //11 - ???

    public void ChooseLanguage() 
    {
        language = MainMenuScript.languageIndex;
        levelIndex = MainMenuScript.levelIndex;

        //for (int i = 0; i < assetReferences.Length; i++)
        //{
        //    assetReferences[i].LoadAssetAsync<TextAsset>().Completed += LocalCSVSet;
        //}

        if (language == 0) 
        {
            languageIndex = 1;
        }
        else if(language == 1) 
        {
            languageIndex = 3; 
        }
        else if(language == 2) 
        {
            languageIndex = 5; 
        }
        else if(language == 3) 
        {
            languageIndex = 7; 
        }
        else if(language == 4) 
        {
            languageIndex = 9; 
        }
        else if(language == 5) 
        {
            languageIndex = 11; 
        }
        else if(language == 6) 
        {
            languageIndex = 13; 
        }
        List<TextAsset> sortedList = localization.OrderBy(n => n.name).ToList();
        localization = sortedList;
        LoadCSV();
        CheckLocalization();
        gamePlayController.LevelStartFunctions();
    }

    //void LocalCSVSet(AsyncOperationHandle<TextAsset> textAsset) 
    //{
    //    if(textAsset.Status == AsyncOperationStatus.Succeeded) 
    //    {
    //        localization.Add(textAsset.Result);

    //        //if(localization.Count == assetReferences.Length) 
    //        //{
    //        //    List<TextAsset> sortedList = localization.OrderBy(n => n.name).ToList();
    //        //    localization = sortedList;
    //        //    LoadCSV();
    //        //    CheckLocalization();
    //        //    gamePlayController.LevelStartFunctions();

    //        //}
    //    }
    //}

    public void CheckLocalization() 
    {
        if(CSVdata[15 + languageIndex] == "")
        {
            gamePlayController.errorPanel.SetActive(true);
        }
    }

    public void LoadCSV() 
    {
        CSVdata = localization[levelIndex].text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        int tableSize = CSVdata.Length / 15 - 1;

        if (gamePlayController.sceneName == "3_1") 
        {
            for (int i = 0; i < gamePlayController.wordsMatchLeft.Count; i++)
            {
                gamePlayController.wordsMatchLeft[i] = CSVdata[15 * (i + 1) + languageIndex];
                gamePlayController.wordsMatchRight[i] = CSVdata[15 * (i + 1) + languageIndex + 1];
            }
        }
        
        else if(gamePlayController.sceneName == "3_2") 
        {
            for (int i = 0; i < gamePlayController.wordsMatchLeft.Count; i++)
            {
                gamePlayController.wordsMatchLeft[i] = CSVdata[15 * (i + 1) + languageIndex];
            }
        }

        else if(gamePlayController.sceneName == "3_3") 
        {
            for (int i = 0; i < gamePlayController.wordsMatchLeft.Count; i++)
            {
                gamePlayController.wordsMatchLeft[i] = CSVdata[15 * (i + 1) + languageIndex];
                gamePlayController.wordsMatchRight[i] = CSVdata[15 * (i + 1) + languageIndex+1];
            }
        }

        else if(gamePlayController.sceneName == "3_4") 
        {
            for (int i = 0; i < gamePlayController.wordsMatchLeft.Count; i++)
            {
                gamePlayController.wordsMatchLeft[i] = CSVdata[15 * (i + 1) + languageIndex];
            }
        }

        else if (gamePlayController.sceneName == "3_5")
        {
            for (int i = 0; i < gamePlayController.wordsMatchLeft.Count; i++)
            {
                gamePlayController.wordsMatchLeft[i] = CSVdata[15 * (i + 1) + languageIndex];
            }
        }

    }

    public void SetLanguage() 
    {
        CSVdata = localization[levelIndex].text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        int tableSize = CSVdata.Length / 15 - 1;
        gamePlayController.wordsMatchLeft = new List<string>(new string[tableSize]);
        gamePlayController.wordsMatchRight = new List<string>(new string[tableSize]);

        for (int i = 0; i < tableSize; i++)
        {
            gamePlayController.wordsMatchLeft[i] = CSVdata[15 * (i + 1) + languageIndex];
            gamePlayController.wordsMatchRight[i] = CSVdata[15 * (i + 1) + languageIndex + 1];
            
        }

        for (int i = 0; i < gamePlayController.localizationUITexts.Length; i++)
        {
            gamePlayController.localizationUITexts[i].text = gamePlayController.wordsMatchLeft[i];
        }
    }

}
