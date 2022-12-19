using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class GamePlayController_3_1 : MonoBehaviour
{

    [Header("Words List")]
    public List<string> wordsMatchLeft;
    public List<string> wordsMatchRight;
    public Text[] localizationUITexts;

    [Header("UI")]
    public GameObject _PrefabHolder;
    public Text levelText;

    [Header("1_Game")]
    public GameObject leftSide;
    public GameObject rightSide;

    [Header("2_Game")]
    public GameObject dialogWindow;
    public Image selectedGOimage;
    public Text[] transportSurface;

    [Header("3_Game")]
    public Text question;
    string answer;
    bool[] answered = new bool[6];

    [Header("4_Game")]
    public Text[] vitaminNames;

    [Header("5_Game")]
    public GameObject[] correctParticleSystem;
    public GameObject letterButton;
    public GameObject nameTextPrefab;
    public GameObject nameHolder;
    public GameObject letterButtonsHolder;
    public char[] planetNameChar;
    [HideInInspector] public int nameFilled;
    public char[] planetNameChar_Filled;
    public Text[] planetNamesText;
    public GameObject clearButton;

    [Header("7_Game")]
    public Transform[] microbePositions;
    public GameObject[] microbePrefabs;

    [Header("8_Game")]
    public GameObject firstQuestionPanel;
    public GameObject secondQuestionPanel;
    public Text questionText;
    public Text[] jobsText;

    [Header("10_Game")]
    public Text questionText_2;

    [Header("Scripts")]
    SoundManager_3 soundManager;
    public CSVreader localization;

    [Header("Colors")]
    public Color fogging;
    public Color textColor;

    [Header("Prefabs")]
    public GameObject matchablePrefab;
    public GameObject StaticPrefab;
    public GameObject HolderPrefab;

    public GameObject[] matchablePrefabs;
    public GameObject[] _matchStatic;
    public GameObject[] _matchHolders;
    [HideInInspector] public GameObject previousGameObject;

    //Main
    public string sceneName;
    public int _Matched;
    public GameObject winPanel;
    public GameObject errorPanel;
    public Slider levelSlider;
    [HideInInspector] public int matchIndex;

    //2_Game
    [HideInInspector] public GameObject selectedGo;
    [HideInInspector] public GameObject selectedGo_2;


    private void Awake()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager_3>();
        sceneName = SceneManager.GetActiveScene().name;
        localization.ChooseLanguage();
    }


    public void BackButton() 
    {
        if (sceneName == "3_5")
        {
            DeleteCharacter();
            previousGameObject.transform.position = previousGameObject.GetComponent<Draggable_3class>().startPos;
            previousGameObject.transform.SetParent(previousGameObject.GetComponent<Draggable_3class>().startTransform, true);
            previousGameObject.GetComponent<Draggable_3class>().matched = false;
            previousGameObject.GetComponentInParent<HorizontalLayoutGroup>().enabled = false;
            previousGameObject.GetComponentInParent<HorizontalLayoutGroup>().enabled = true;
            dialogWindow.transform.GetChild(0).GetComponent<Animator>().SetTrigger("ScaleDown");
            Invoke("CloseDialogWindow", 1);
        }

        if(sceneName == "3_8" || sceneName == "3_9" || sceneName == "3_10") 
        {
            previousGameObject.GetComponent<StaticWordScript>().selectable = false;

            DeleteCharacter();
            Invoke("CloseDialogWindow2", 0.1f);
        }

        //if (sceneName == "3_9")
        //{
        //    DeleteCharacter();
        //    previousGameObject.GetComponent<StaticWordScript>().selectable = false;
        //    Invoke("CloseDialogWindow2", 0.1f);
        //}

    }

    public void LevelStartFunctions()
    {
        if (sceneName == "3_1")
        {
            SetWords();
        }
        else if (sceneName == "3_2")
        {
            CheckAllButtons();
        }
        else if (sceneName == "3_3")
        {
            SetQuestion();



            GameObject trueButton = GameObject.Find("True");
            trueButton.gameObject.transform.GetChild(0).GetComponent<Text>().text = wordsMatchLeft[5];
            GameObject falseButton = GameObject.Find("False");
            falseButton.gameObject.transform.GetChild(0).GetComponent<Text>().text = wordsMatchLeft[6];
        }
        else if (sceneName == "3_4")
        {
            matchablePrefabs = GameObject.FindGameObjectsWithTag("Matchable_Prefabs");
            SetVitaminTexts();
            ShufflematchablePrefabs();
        }
        else if (sceneName == "3_5")
        {
            ShufflePlanets();
        }
        else if (sceneName == "3_6")
        {
            localization.SetLanguage();

            matchablePrefabs = GameObject.FindGameObjectsWithTag("Matchable_Prefabs");

            ShufflematchablePrefabs();
        }
        else if (sceneName == "3_7")
        {
            localization.SetLanguage();

            InstaniateMicrobes();
        }
        else if (sceneName == "3_8")
        {
            localization.SetLanguage();

            _matchStatic = GameObject.FindGameObjectsWithTag("Match_Static");

            for (int i = 0; i < jobsText.Length; i++)
            {
                jobsText[i].text = localizationUITexts[i].text;
            }

            for (int i = 0; i < _matchStatic.Length; i++)
            {
                _matchStatic[i].transform.SetSiblingIndex(Random.Range(0, _matchStatic.Length));
            }
        }

        else if (sceneName == "3_9")
        {
            localization.SetLanguage();

            _matchStatic = GameObject.FindGameObjectsWithTag("Match_Static");

            SetQuestion_3();

            for (int i = 0; i < _matchStatic.Length; i++)
            {
                _matchStatic[i].transform.SetSiblingIndex(Random.Range(0, _matchStatic.Length));
            }
        }

        else if(sceneName == "3_10") 
        {
            localization.SetLanguage();

            _matchStatic = GameObject.FindGameObjectsWithTag("Match_Static");

            SetQuestion2();

            for (int i = 0; i < _matchStatic.Length; i++)
            {
                _matchStatic[i].transform.SetSiblingIndex(Random.Range(0, _matchStatic.Length));
            }
        }
    }

    private void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager_3>();
    }

    void ShufflematchablePrefabs()
    {
        for (int i = 0; i < matchablePrefabs.Length; i++)
        {
            matchablePrefabs[i].transform.SetSiblingIndex(Random.Range(0, matchablePrefabs.Length));
        }
    }

    public void ClickSound_2()
    {
        soundManager.Click();
    }
    public void CorrectSound()
    {
        soundManager.Correct();
    }
    public void IncorrectSound()
    {
        soundManager.Incorrect();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu_3class");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ClickSound()
    {
        soundManager.ButtonScaleUp();
    }

    #region 1_Game
    public void SetWords()
    {
        soundManager.ButtonScaleUp();

        GameObject[] matchStaticTemp = GameObject.FindGameObjectsWithTag("Match_Static");
        GameObject[] matchablePrefabsTemp = GameObject.FindGameObjectsWithTag("Matchable_Prefabs");
        GameObject[] matchHoldersTemp = GameObject.FindGameObjectsWithTag("Matchable_Holders");

        //Sort objects
        _matchStatic = matchStaticTemp.OrderBy(matchStaticTemp => matchStaticTemp.GetComponent<StaticWordScript>().matchIndex).ToArray();
        matchablePrefabs = matchablePrefabsTemp.OrderBy(matchablePrefabsTemp => matchablePrefabsTemp.GetComponent<Draggable_3class>().matchIndex).ToArray();
        _matchHolders = matchHoldersTemp.OrderBy(matchHoldersTemp => matchHoldersTemp.GetComponent<StaticWordScript>().matchIndex).ToArray();

        for (int i = 0; i < matchablePrefabs.Length; i++)
        {
            _matchStatic[i].transform.GetChild(2).GetComponent<Text>().text = wordsMatchLeft[matchIndex];
            _matchStatic[i].GetComponent<StaticWordScript>().matchIndex = matchIndex;

            _matchHolders[i].GetComponent<StaticWordScript>().matchIndex = matchIndex;

            matchablePrefabs[i].transform.GetChild(0).GetComponent<Text>().text = wordsMatchRight[matchIndex];
            matchablePrefabs[i].GetComponent<Draggable_3class>().matchIndex = matchIndex;

            matchIndex++;
        }

        ShufflematchablePrefabs();

    }

    void ResetWords()
    {
        //Instaniate leftside prefab
        for (int i = 0; i < 4; i++)
        {
            GameObject go = Instantiate(StaticPrefab, leftSide.transform);
            go.transform.SetParent(leftSide.transform, true);
        }

        //Instaniate rightside prefab
        for (int i = 0; i < 4; i++)
        {
            GameObject go = Instantiate(HolderPrefab, rightSide.transform);
            go.transform.SetParent(rightSide.transform, true);
        }

        //Instaniate bottom words prefab
        for (int i = 0; i < 4; i++)
        {
            GameObject go = Instantiate(matchablePrefab, _PrefabHolder.transform);
            go.transform.SetParent(_PrefabHolder.transform, true);
        }

        SetWords();

    }

    public void CheckMatchCount()
    {
        if (_Matched == 4)
        {

            if (levelSlider.value == levelSlider.maxValue - 1)
            {
                winPanel.SetActive(true);
                levelSlider.value++;
                levelText.text = levelSlider.value + "/8";
            }

            else if (levelSlider.value < levelSlider.maxValue - 1)
            {
                levelSlider.value++;
                levelText.text = levelSlider.value + "/8";

                for (int i = 0; i < _matchStatic.Length; i++)
                {
                    _matchStatic[i].GetComponent<Animator>().SetTrigger("ScaleDown");
                    Destroy(_matchStatic[i], 1);
                }

                for (int i = 0; i < _matchHolders.Length; i++)
                {
                    _matchHolders[i].GetComponent<Animator>().SetTrigger("ScaleDown");
                    Destroy(_matchHolders[i], 1);
                }
                for (int i = 0; i < matchablePrefabs.Length; i++)
                {
                    matchablePrefabs[i].GetComponent<Animator>().SetTrigger("ScaleDown");
                    Destroy(matchablePrefabs[i], 1);
                }

                soundManager.ButtonScaleDown();

                _Matched = 0;

                Invoke("ResetWords", 1.5f);
            }
        }
    }
    #endregion
    #region 2_Game

    void CheckAllButtons()
    {
        _matchStatic = GameObject.FindGameObjectsWithTag("Match_Static");

        int index = 0;

        //Set name of transport
        for (int i = 0; i < matchablePrefabs.Length; i++)
        {
            matchablePrefabs[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = wordsMatchLeft[i];
        }

        //Set transport moving surfaces
        for (int i = 12; i < transportSurface.Length + 12; i++)
        {
            transportSurface[index].text = wordsMatchLeft[i];
            index++;
        }

        //Shuffle transports
        for (int i = 0; i < matchablePrefabs.Length; i++)
        {
            matchablePrefabs[i].transform.SetSiblingIndex(Random.Range(0, matchablePrefabs.Length));
            _matchStatic[i].transform.SetSiblingIndex(Random.Range(0, _matchStatic.Length));
        }



        Invoke("DisableGridLayout", 1);
    }

    void DisableGridLayout()
    {
        leftSide.GetComponent<GridLayoutGroup>().enabled = false;
        rightSide.GetComponent<GridLayoutGroup>().enabled = false;
    }

    public void CloseOtherButtons(GameObject selected)
    {
        selectedGo = selected;
        for (int i = 0; i < matchablePrefabs.Length; i++)
        {

            if (matchablePrefabs[i].name != selected.name)
            {
                matchablePrefabs[i].GetComponent<Button>().interactable = false;
                matchablePrefabs[i].transform.GetChild(0).GetComponent<Text>().color = fogging;
            }
        }

        for (int i = 0; i < _matchStatic.Length; i++)
        {
            _matchStatic[i].GetComponent<StaticWordScript>().selectable = true;
        }
    }

    public void OpenOtherButtons()
    {
        for (int i = 0; i < matchablePrefabs.Length; i++)
        {
            matchablePrefabs[i].GetComponent<Button>().interactable = true;
            matchablePrefabs[i].transform.GetChild(0).GetComponent<Text>().color = textColor;
        }

        for (int i = 0; i < _matchStatic.Length; i++)
        {
            _matchStatic[i].GetComponent<StaticWordScript>().selectable = false;
        }
    }

    public void AdditionalMatch(int additionalMatchIndex)
    {

        if (additionalMatchIndex == selectedGo.GetComponent<Matchable_3>().additionalIndex)
        {
            if (_Matched < 11)
            {
                _Matched++;
                levelSlider.value++;
                levelText.text = levelSlider.value + "/12";

                selectedGo.GetComponent<Animator>().SetTrigger("ScaleDown");
                selectedGo_2.GetComponent<Animator>().SetTrigger("ScaleDown");

                Invoke("CloseSelectedGO", 0.6f);

                CorrectSound();
                dialogWindow.SetActive(false);
                OpenOtherButtons();
            }

            else if (_Matched == 11)
            {
                levelSlider.value++;
                levelText.text = levelSlider.value + "/12";

                selectedGo.SetActive(false);
                selectedGo_2.SetActive(false);

                CorrectSound();
                dialogWindow.SetActive(false);
                winPanel.SetActive(true);
            }

        }

        else
        {
            IncorrectSound();
        }


    }
    void CloseSelectedGO()
    {
        selectedGo.SetActive(false);
        selectedGo_2.SetActive(false);

    }
    #endregion
    #region 3_Game
    void SetQuestion()
    {
        
        dialogWindow.SetActive(false);
        dialogWindow.SetActive(true);
        question.text = wordsMatchLeft[matchIndex];
        answer = wordsMatchRight[matchIndex];
        matchIndex++;
    }

    public void AnswerToQuestion(string userAnswer)
    {
        ClickSound();

        if (userAnswer == answer && !answered[matchIndex])
        {
            answered[matchIndex] = true;
            _Matched++;
            levelSlider.value++;
            levelText.text = levelSlider.value + "/5";

            if (_Matched < 5)
            {
                dialogWindow.GetComponent<Animator>().SetTrigger("ScaleDown");
                CorrectSound();
                Invoke("SetQuestion", 0.7f);
            }

            else if (_Matched == 5)
            {
                dialogWindow.GetComponent<Animator>().SetTrigger("ScaleDown");
                CorrectSound();
                winPanel.SetActive(true);
            }
        }

        else
        {
            IncorrectSound();
        }
    }

    #endregion
    #region 4_Game
    void SetVitaminTexts()
    {
        for (int i = 0; i < vitaminNames.Length; i++)
        {
            vitaminNames[i].text = wordsMatchLeft[i];
        }
    }

    #endregion
    #region 5_Game
    public void ShufflePlanets()
    {
        _matchStatic = GameObject.FindGameObjectsWithTag("Match_Static");

        matchablePrefabs = GameObject.FindGameObjectsWithTag("Matchable_Prefabs");

        _matchHolders = GameObject.FindGameObjectsWithTag("Matchable_Holders");

        LoadPlanetNames();

        ShufflematchablePrefabs();
    }

    void LoadPlanetNames()
    {
        for (int i = 0; i < wordsMatchLeft.Count; i++)
        {
            planetNamesText[i].text = wordsMatchLeft[i];
        }
    }

    public void InstaniateCorrectPS(GameObject gameObject)
    {
        GameObject ps = Instantiate(correctParticleSystem[0], gameObject.transform.position, Quaternion.identity);
        ps.transform.SetParent(leftSide.transform, true);
        ps.transform.localScale = new Vector3(1, 1, 1);
    }
    public void InstaniateCorrectPS2(GameObject gameObject)
    {
        GameObject ps = Instantiate(correctParticleSystem[1], gameObject.transform.position, Quaternion.identity);
        ps.transform.localScale = new Vector3(1, 1, 1);
    }

    public void FindNameOfPlanet(GameObject gameObject)
    {
        selectedGo = gameObject;
        dialogWindow.SetActive(true);
        string planetName = wordsMatchLeft[matchIndex];
        char[] chars = planetName.ToCharArray();
        planetNameChar = chars;
        planetNameChar_Filled = new char[chars.Length];
        selectedGOimage.sprite = gameObject.GetComponent<Image>().sprite;
        selectedGOimage.rectTransform.sizeDelta = new Vector2(gameObject.GetComponent<Image>().rectTransform.rect.width, gameObject.GetComponent<Image>().rectTransform.rect.height);

        for (int i = 0; i < wordsMatchLeft[matchIndex].Length; i++)
        {
            GameObject letter = Instantiate(letterButton, letterButtonsHolder.transform.position, Quaternion.identity);
            letter.transform.SetParent(letterButtonsHolder.transform, true);
            letter.transform.localScale = new Vector3(1, 1, 1);
            letter.transform.GetChild(0).GetComponent<Text>().text = chars[i].ToString().ToUpper();
            letter.transform.SetSiblingIndex(Random.Range(0, wordsMatchLeft[matchIndex].Length));

            GameObject nameText = Instantiate(nameTextPrefab, nameHolder.transform.position, Quaternion.identity);
            nameText.transform.SetParent(nameHolder.transform, true);
            nameText.transform.localScale = new Vector3(1, 1, 1);
            nameText.GetComponent<NameTextScript>().index = i;
        }
    }

    public void SetNameOfPlanet(char character, GameObject gameObject)
    {
        bool placed = false;
        ClickSound_2();

        if (nameFilled < nameHolder.transform.childCount)
        {
            for (int i = 0; i < nameHolder.transform.childCount; i++)
            {
                if (nameHolder.transform.GetChild(i).GetComponent<Text>().text == "_" && !placed)
                {
                    nameHolder.transform.GetChild(i).GetComponent<Text>().text = character.ToString();
                    nameHolder.transform.GetChild(i).GetComponent<NameTextScript>().nameCharacter = character.ToString();
                    gameObject.transform.SetSiblingIndex(i);
                    planetNameChar_Filled[i] = character;

                    gameObject.SetActive(false);
                    placed = true;

                }
            }

            nameFilled++;

            string pn = new string(planetNameChar);
            string pnf = new string(planetNameChar_Filled);

            if (nameFilled == nameHolder.transform.childCount && pn == pnf)
            {
                _Matched++;
                levelSlider.value++;
                levelText.text = levelSlider.value + "/" + levelSlider.maxValue.ToString();
                selectedGOimage.transform.GetChild(0).gameObject.SetActive(true);
                soundManager.StarGain();
                dialogWindow.transform.GetChild(0).GetComponent<Animator>().SetTrigger("ScaleDown");
                selectedGo.transform.GetChild(0).gameObject.SetActive(true);
                Invoke("CloseDialogWindow", 1);
            }

            else if (nameFilled == nameHolder.transform.childCount && pn != pnf)
            {
                soundManager.Incorrect();
                DeleteCharacter();
            }

            if (_Matched == levelSlider.maxValue)
            {
                winPanel.SetActive(true);
            }
        }
    }

    public void CloseDialogWindow()
    {
        dialogWindow.SetActive(false);

        for (int i = 0; i < nameHolder.transform.childCount; i++)
        {
            Destroy(nameHolder.transform.GetChild(i).gameObject);
            Destroy(letterButtonsHolder.transform.GetChild(i).gameObject);
            nameFilled = 0;
        }
    }

    public void DeleteCharacter()
    {
        ClickSound_2();

        for (int i = 0; i < letterButtonsHolder.transform.childCount; i++)
        {
            letterButtonsHolder.transform.GetChild(i).gameObject.SetActive(true);
        }

        for (int i = 0; i < nameHolder.transform.childCount; i++)
        {
            if (nameHolder.transform.GetChild(i).GetComponent<NameTextScript>())
            {
                nameHolder.transform.GetChild(i).GetComponent<NameTextScript>().DeleteCharacter();
            }
        }

        nameFilled = 0;
    }

    public void DeleteOneCharacter() 
    {
        if (nameFilled >= 0) 
        {
            if (nameFilled > 0) nameFilled--;
            nameHolder.transform.GetChild(nameFilled).GetComponent<NameTextScript>().DeleteCharacter();
            letterButtonsHolder.transform.GetChild(nameFilled).gameObject.SetActive(true);
        }
    }

    #endregion
    #region 6_Game
    public void ChooseSprite()
    {
        if (!selectedGo.GetComponent<Matchable_3>().selected)
        {
            dialogWindow.SetActive(true);
            selectedGOimage.sprite = selectedGo.GetComponent<Image>().sprite;
            selectedGOimage.rectTransform.sizeDelta = new Vector2(selectedGo.GetComponent<Image>().rectTransform.rect.width * 1.5f, selectedGo.GetComponent<Image>().rectTransform.rect.height * 1.5f);
            selectedGo.GetComponent<Matchable_3>().selected = true;
        }
    }

    public void ChooseSide(int index)
    {
        if (_Matched == levelSlider.maxValue - 1)
        {
            if (index == matchIndex)
            {
                if (matchIndex == 0) { selectedGo.transform.SetParent(leftSide.transform, true); }
                if (matchIndex == 1) { selectedGo.transform.SetParent(rightSide.transform, true); }

                dialogWindow.gameObject.SetActive(false);
                selectedGo.transform.GetChild(0).gameObject.SetActive(true);
                levelSlider.value++;
                _Matched++;
                levelText.text = levelSlider.value + "/" + levelSlider.maxValue;
                winPanel.gameObject.SetActive(true);
            }

            else
            {
                IncorrectSound();
            }
        }

        else
        {
            if (index == matchIndex)
            {
                if (matchIndex == 0) { selectedGo.transform.SetParent(leftSide.transform, true); }
                if (matchIndex == 1) { selectedGo.transform.SetParent(rightSide.transform, true); }

                dialogWindow.gameObject.SetActive(false);
                selectedGo.transform.GetChild(0).gameObject.SetActive(true);
                levelSlider.value++;
                _Matched++;
                levelText.text = levelSlider.value + "/" + levelSlider.maxValue;
                CorrectSound();
                Instantiate(correctParticleSystem[1], selectedGo.transform.position, Quaternion.identity);
            }
            else
            {
                IncorrectSound();
            }
        }


    }

    #endregion
    #region 7_Game
    void InstaniateMicrobes()
    {
        //Shuffle microbe transform positions
        for (int i = 0; i < microbePositions.Length; i++)
        {
            microbePositions[i].transform.SetSiblingIndex(Random.Range(0, microbePositions.Length));
        }

        //Instaniate microbes
        for (int i = 0; i < 8; i++)
        {
            GameObject microbe = Instantiate(microbePrefabs[Random.Range(0, microbePrefabs.Length)], microbePositions[i].transform.position, Quaternion.identity); ;
            microbe.transform.SetParent(microbePositions[i].transform, true);
            microbe.transform.localScale = new Vector3(40, 40, 1);
        }

    }

    public void MatchMicrobeType(int buttonIndex)
    {

        if (buttonIndex == matchIndex)
        {
            if (_Matched < levelSlider.maxValue)
            {
                dialogWindow.gameObject.GetComponent<Animator>().SetTrigger("Close");

                soundManager.StarGain();
                levelSlider.value++;
                levelText.text = levelSlider.value + "/" + levelSlider.maxValue.ToString();
            }
            else
            {
                dialogWindow.gameObject.GetComponent<Animator>().SetTrigger("Close");

                soundManager.StarGain();
                levelSlider.value++;
                levelText.text = levelSlider.value + "/" + levelSlider.maxValue.ToString();
                winPanel.SetActive(true);
            }

        }

        else
        {
            IncorrectSound();
        }
    }
    #endregion
    #region 8_Game
    public void OpenDialogWindow()
    {
        dialogWindow.SetActive(true);
        secondQuestionPanel.SetActive(false);
        firstQuestionPanel.SetActive(true);
        soundManager.ButtonScaleUp();

        selectedGOimage = firstQuestionPanel.transform.GetChild(0).gameObject.GetComponent<Image>();
        selectedGOimage.sprite = selectedGo.GetComponent<Image>().sprite;
    }

    public void MatchJob(int buttonIndex)
    {
        if (buttonIndex == matchIndex)
        {
            firstQuestionPanel.SetActive(false);
            secondQuestionPanel.SetActive(true);
            soundManager.ButtonScaleUp();
            string jobName = wordsMatchRight[matchIndex];
            char[] chars = jobName.ToCharArray();
            planetNameChar = chars;
            planetNameChar_Filled = new char[chars.Length];
            questionText.text = wordsMatchLeft[matchIndex + 7];
            selectedGOimage = secondQuestionPanel.transform.GetChild(0).gameObject.GetComponent<Image>();
            selectedGOimage.sprite = selectedGo.GetComponent<Image>().sprite;

            if (!wordsMatchRight[matchIndex].Contains("O‘") && !wordsMatchRight[matchIndex].Contains("SH") && !wordsMatchRight[matchIndex].Contains("CH"))
            {
                for (int i = 0; i < wordsMatchRight[matchIndex].Length; i++)
                {
                    GameObject letter = Instantiate(letterButton, letterButtonsHolder.transform.position, Quaternion.identity);
                    letter.transform.SetParent(letterButtonsHolder.transform, true);
                    letter.transform.localScale = new Vector3(1, 1, 1);
                    letter.transform.GetChild(0).GetComponent<Text>().text = chars[i].ToString().ToUpper();
                    letter.transform.SetSiblingIndex(Random.Range(0, wordsMatchLeft[matchIndex].Length));

                    GameObject nameText = Instantiate(nameTextPrefab, nameHolder.transform.position, Quaternion.identity);
                    nameText.transform.SetParent(nameHolder.transform, true);
                    nameText.transform.localScale = new Vector3(1, 1, 1);
                    nameText.GetComponent<NameTextScript>().index = i;
                }
            }
            if (wordsMatchRight[matchIndex].Contains("O‘") || wordsMatchRight[matchIndex].Contains("SH") || wordsMatchRight[matchIndex].Contains("CH"))
            {
                int deletedCharacter = 0;

                for (int i = 0; i < wordsMatchRight[matchIndex].Length; i++)
                {
                    GameObject letter = Instantiate(letterButton, letterButtonsHolder.transform.position, Quaternion.identity);
                    letter.transform.SetParent(letterButtonsHolder.transform, true);
                    letter.transform.localScale = new Vector3(1, 1, 1);
                    letter.transform.GetChild(0).GetComponent<Text>().text = chars[i].ToString().ToUpper();
                    letter.transform.SetSiblingIndex(Random.Range(0, wordsMatchLeft[matchIndex].Length));
                }

                if (wordsMatchRight[matchIndex].Contains("O‘"))
                {
                    for (int i = 0; i < letterButtonsHolder.transform.childCount; i++)
                    {
                        if (letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text == "O")
                        {
                            letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text += "‘";
                            deletedCharacter++;
                        }

                        if (letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text == "‘")
                        {
                            Destroy(letterButtonsHolder.transform.GetChild(i).gameObject);
                        }
                    }

                }
                if (wordsMatchRight[matchIndex].Contains("SH"))
                {
                    for (int i = 0; i < letterButtonsHolder.transform.childCount; i++)
                    {
                        if (letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text == "S")
                        {
                            letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text += "H";
                            deletedCharacter++;
                        }

                        if (letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text == "H")
                        {
                            Destroy(letterButtonsHolder.transform.GetChild(i).gameObject);

                        }
                    }
                }
                if (wordsMatchRight[matchIndex].Contains("CH")) 
                {
                    for (int i = 0; i < letterButtonsHolder.transform.childCount; i++)
                    {
                        if (letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text == "C")
                        {
                            letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text += "H";
                            deletedCharacter++;
                        }

                        if (letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text == "H")
                        {
                            Destroy(letterButtonsHolder.transform.GetChild(i).gameObject);

                        }
                    }
                }

                for (int i = 0; i < wordsMatchRight[matchIndex].Length - deletedCharacter; i++)
                {
                    GameObject nameText = Instantiate(nameTextPrefab, nameHolder.transform.position, Quaternion.identity);
                    nameText.transform.SetParent(nameHolder.transform, true);
                    nameText.transform.localScale = new Vector3(1, 1, 1);
                    nameText.GetComponent<NameTextScript>().index = i;
                }
            }
        }
        else
        {
            IncorrectSound();
        }
    }
    public void MatchJobName(char[] character, GameObject gameObject)
    {
        bool placed = false;
        ClickSound_2();

        if (nameFilled < nameHolder.transform.childCount)
        {
            for (int i = 0; i < nameHolder.transform.childCount; i++)
            {
                if (nameHolder.transform.GetChild(i).GetComponent<Text>().text == "_" && !placed)
                {

                    if (character.Length > 1) 
                    {
                        nameHolder.transform.GetChild(i).GetComponent<Text>().text = new string(character);
                        nameHolder.transform.GetChild(i).GetComponent<NameTextScript>().nameCharacter = new string(character);
                        gameObject.transform.SetSiblingIndex(i);

                        planetNameChar_Filled[i] = character[0];
                        i++;
                        planetNameChar_Filled[i] = character[1];

                        print(i + new string(planetNameChar_Filled));
                        gameObject.SetActive(false);
                        placed = true;
                    }
                    else 
                    {
                        nameHolder.transform.GetChild(i).GetComponent<Text>().text = new string(character);
                        nameHolder.transform.GetChild(i).GetComponent<NameTextScript>().nameCharacter = new string(character);
                        gameObject.transform.SetSiblingIndex(i);

                        planetNameChar_Filled[i] = character[0];
                        print(i + new string(planetNameChar_Filled));
                        gameObject.SetActive(false);
                        placed = true;
                    }

                }
            }

            string pnf = "";

            for (int i = 0; i < nameHolder.transform.childCount; i++)
            {
                pnf += nameHolder.transform.GetChild(i).GetComponent<Text>().text;
            }

            nameFilled++;

            string pn = new string(planetNameChar);
            print(new string(planetNameChar) + " / " + pnf);

            if (nameFilled == nameHolder.transform.childCount && pn == pnf)
            {
                _Matched++;
                levelSlider.value++;
                levelText.text = levelSlider.value + "/" + levelSlider.maxValue.ToString();
                Instantiate(correctParticleSystem[2], nameHolder.transform.position, Quaternion.identity);
                soundManager.StarGain();
                if (sceneName == "3_8") { questionText.text = wordsMatchLeft[matchIndex + 13]; }
                if (sceneName == "3_9") 
                {
                    selectedGo.transform.GetChild(1).gameObject.SetActive(false);
                    selectedGo.transform.GetChild(0).gameObject.SetActive(true);
                    SetQuestion_3();
                }
                
                if(sceneName == "3_10") { SetQuestion2(); }
                selectedGo.transform.GetChild(0).gameObject.SetActive(true);
                Invoke("CloseDialogWindow2", 1);
            }

            else if (nameFilled == nameHolder.transform.childCount && pn != pnf)
            {
                soundManager.Incorrect();
                DeleteCharacter();
            }

            if (_Matched == levelSlider.maxValue)
            {
                winPanel.SetActive(true);
            }
        }
    }

    void CloseDialogWindow2()
    {
        dialogWindow.GetComponent<Animator>().SetTrigger("Close");

        for (int i = 0; i < nameHolder.transform.childCount; i++)
        {
            Destroy(nameHolder.transform.GetChild(i).gameObject);
            Destroy(letterButtonsHolder.transform.GetChild(i).gameObject);
            nameFilled = 0;
        }

    }

    #endregion
    #region 9_Game
    public void SetQuestion_3() 
    {
        questionText_2.text = wordsMatchLeft[_Matched + 6];
        matchIndex = _Matched;
    }

    public void CheckIndex_2(int matchableIndex, GameObject gameObject)
    {
        if (matchIndex == matchableIndex && !dialogWindow.activeInHierarchy)
        {
            soundManager.ButtonScaleUp();
            selectedGo = gameObject;
            dialogWindow.SetActive(true);
            questionText.text = wordsMatchLeft[12];
            string planetName = wordsMatchLeft[matchIndex];
            char[] chars = planetName.ToCharArray();
            planetNameChar = chars;
            chars.OrderBy(chars => wordsMatchLeft[matchIndex]);
            planetNameChar_Filled = new char[chars.Length];
            selectedGOimage.sprite = gameObject.GetComponent<Image>().sprite;
            selectedGOimage.rectTransform.sizeDelta = new Vector2(gameObject.GetComponent<Image>().rectTransform.rect.width, gameObject.GetComponent<Image>().rectTransform.rect.height);
            int deletedCharacterIndex = 99;

            if (!wordsMatchLeft[matchIndex].Contains("O‘") && !wordsMatchLeft[matchIndex].Contains("SH") && !wordsMatchLeft[matchIndex].Contains("CH"))
            {
                for (int i = 0; i < wordsMatchLeft[matchIndex].Length; i++)
                {
                    GameObject letter = Instantiate(letterButton, letterButtonsHolder.transform.position, Quaternion.identity);
                    letter.transform.SetParent(letterButtonsHolder.transform, true);
                    letter.transform.localScale = new Vector3(1, 1, 1);
                    letter.transform.GetChild(0).GetComponent<Text>().text = chars[i].ToString().ToUpper();
                    letter.transform.SetSiblingIndex(Random.Range(0, wordsMatchLeft[matchIndex].Length));

                    GameObject nameText = Instantiate(nameTextPrefab, nameHolder.transform.position, Quaternion.identity);
                    nameText.transform.SetParent(nameHolder.transform, true);
                    nameText.transform.localScale = new Vector3(1, 1, 1);
                    nameText.GetComponent<NameTextScript>().index = i;
                }
            }
            else if (wordsMatchLeft[matchIndex].Contains("O‘") || wordsMatchLeft[matchIndex].Contains("SH") || wordsMatchLeft[matchIndex].Contains("CH"))
            {
                int deletedCharacter = 0;

                for (int i = 0; i < wordsMatchLeft[matchIndex].Length; i++)
                {
                    GameObject letter = Instantiate(letterButton, letterButtonsHolder.transform.position, Quaternion.identity);
                    letter.transform.SetParent(letterButtonsHolder.transform, true);
                    letter.transform.localScale = new Vector3(1, 1, 1);
                    letter.transform.GetChild(0).GetComponent<Text>().text = chars[i].ToString().ToUpper();
                    letter.transform.SetSiblingIndex(Random.Range(0, wordsMatchLeft[matchIndex].Length));
                }

                if (wordsMatchLeft[matchIndex].Contains("O‘"))
                {
                    for (int i = 0; i < letterButtonsHolder.transform.childCount; i++)
                    {
                        if (letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text == "O")
                        {
                            letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text += "‘";
                            deletedCharacter++;
                        }

                        if (letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text == "‘")
                        {
                            Destroy(letterButtonsHolder.transform.GetChild(i).gameObject);
                        }
                    }

                }
                if (wordsMatchLeft[matchIndex].Contains("SH"))
                {
                    int targetCharacterCount = 0;
                    int deletetedTargetCharacter = 1;
                    foreach (char sh in wordsMatchLeft[matchIndex])
                    {
                        if (sh == 'H') { targetCharacterCount++; }

                    }

                    for (int i = 0; i < letterButtonsHolder.transform.childCount; i++)
                    {
                        if (letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text == "S")
                        {
                            for (int j = 0; j < letterButtonsHolder.transform.childCount; j++)
                            {
                                if (letterButtonsHolder.transform.GetChild(j).gameObject.transform.GetChild(0).GetComponent<Text>().text == "H" && deletetedTargetCharacter < targetCharacterCount) 
                                {
                                    letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text += "H";
                                    Destroy(letterButtonsHolder.transform.GetChild(j).gameObject);
                                    deletetedTargetCharacter++;
                                    deletedCharacter++;
                                }
                            }
                        }
                    }
                }
                if (wordsMatchLeft[matchIndex].Contains("CH"))
                {
                    for (int i = 0; i < letterButtonsHolder.transform.childCount; i++)
                    {
                        if (letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text == "C")
                        {
                            letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text += "H";
                            deletedCharacter++;
                        }

                        if (letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text == "H")
                        {
                            Destroy(letterButtonsHolder.transform.GetChild(i).gameObject);

                        }
                    }
                }

                for (int i = 0; i < wordsMatchLeft[matchIndex].Length - deletedCharacter; i++)
                {
                    GameObject nameText = Instantiate(nameTextPrefab, nameHolder.transform.position, Quaternion.identity);
                    nameText.transform.SetParent(nameHolder.transform, true);
                    nameText.transform.localScale = new Vector3(1, 1, 1);
                    nameText.GetComponent<NameTextScript>().index = i;
                }
            }

            gameObject.GetComponent<StaticWordScript>().selectable = true;
        }
        else 
        {
            IncorrectSound();
        }
    }
    #endregion
    #region 10_Game
    public void SetQuestion2() 
    {
        questionText_2.text = wordsMatchLeft[_Matched + 5];
        matchIndex = _Matched;
    }

    public void CheckIndex(int matchableIndex, GameObject gameObject) 
    {
        if (matchIndex == matchableIndex && !dialogWindow.activeInHierarchy)
        {
            selectedGo = gameObject;
            dialogWindow.SetActive(true);
            questionText.text = wordsMatchLeft[10];
            string planetName = wordsMatchLeft[matchIndex];
            char[] chars = planetName.ToCharArray();
            planetNameChar = chars;
            planetNameChar_Filled = new char[chars.Length];
            selectedGOimage.sprite = gameObject.GetComponent<Image>().sprite;
            selectedGOimage.rectTransform.sizeDelta = new Vector2(gameObject.GetComponent<Image>().rectTransform.rect.width, gameObject.GetComponent<Image>().rectTransform.rect.height);


            if (!wordsMatchLeft[matchIndex].Contains("O‘") && !wordsMatchLeft[matchIndex].Contains("SH") && !wordsMatchLeft[matchIndex].Contains("CH"))
            {
                for (int i = 0; i < wordsMatchLeft[matchIndex].Length; i++)
                {
                    GameObject letter = Instantiate(letterButton, letterButtonsHolder.transform.position, Quaternion.identity);
                    letter.transform.SetParent(letterButtonsHolder.transform, true);
                    letter.transform.localScale = new Vector3(1, 1, 1);
                    letter.transform.GetChild(0).GetComponent<Text>().text = chars[i].ToString().ToUpper();
                    letter.transform.SetSiblingIndex(Random.Range(0, wordsMatchLeft[matchIndex].Length));

                    GameObject nameText = Instantiate(nameTextPrefab, nameHolder.transform.position, Quaternion.identity);
                    nameText.transform.SetParent(nameHolder.transform, true);
                    nameText.transform.localScale = new Vector3(1, 1, 1);
                    nameText.GetComponent<NameTextScript>().index = i;
                }
            }
            else if (wordsMatchLeft[matchIndex].Contains("O‘") || wordsMatchLeft[matchIndex].Contains("SH") || wordsMatchLeft[matchIndex].Contains("CH"))
            {
                int deletedCharacter = 0;

                for (int i = 0; i < wordsMatchLeft[matchIndex].Length; i++)
                {
                    GameObject letter = Instantiate(letterButton, letterButtonsHolder.transform.position, Quaternion.identity);
                    letter.transform.SetParent(letterButtonsHolder.transform, true);
                    letter.transform.localScale = new Vector3(1, 1, 1);
                    letter.transform.GetChild(0).GetComponent<Text>().text = chars[i].ToString().ToUpper();
                    letter.transform.SetSiblingIndex(Random.Range(0, wordsMatchLeft[matchIndex].Length));
                }

                if (wordsMatchLeft[matchIndex].Contains("O‘"))
                {
                    for (int i = 0; i < letterButtonsHolder.transform.childCount; i++)
                    {
                        if (letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text == "O")
                        {
                            letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text += "‘";
                            deletedCharacter++;
                        }

                        if (letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text == "‘")
                        {
                            Destroy(letterButtonsHolder.transform.GetChild(i).gameObject);
                        }
                    }

                }
                if (wordsMatchLeft[matchIndex].Contains("SH"))
                {
                    int targetCharacterCount = 0;
                    int deletetedTargetCharacter = 1;
                    foreach (char sh in wordsMatchLeft[matchIndex])
                    {
                        if (sh == 'H') { targetCharacterCount++; }

                    }

                    for (int i = 0; i < letterButtonsHolder.transform.childCount; i++)
                    {
                        if (letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text == "S")
                        {
                            for (int j = 0; j < letterButtonsHolder.transform.childCount; j++)
                            {
                                if (letterButtonsHolder.transform.GetChild(j).gameObject.transform.GetChild(0).GetComponent<Text>().text == "H" && deletetedTargetCharacter < targetCharacterCount)
                                {
                                    letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text += "H";
                                    Destroy(letterButtonsHolder.transform.GetChild(j).gameObject);
                                    deletetedTargetCharacter++;
                                    deletedCharacter++;
                                }
                            }
                        }
                    }
                }
                if (wordsMatchLeft[matchIndex].Contains("CH"))
                {
                    for (int i = 0; i < letterButtonsHolder.transform.childCount; i++)
                    {
                        if (letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text == "C")
                        {
                            letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text += "H";
                            deletedCharacter++;
                        }

                        if (letterButtonsHolder.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text == "H")
                        {
                            Destroy(letterButtonsHolder.transform.GetChild(i).gameObject);

                        }
                    }
                }

                for (int i = 0; i < wordsMatchLeft[matchIndex].Length - deletedCharacter; i++)
                {
                    GameObject nameText = Instantiate(nameTextPrefab, nameHolder.transform.position, Quaternion.identity);
                    nameText.transform.SetParent(nameHolder.transform, true);
                    nameText.transform.localScale = new Vector3(1, 1, 1);
                    nameText.GetComponent<NameTextScript>().index = i;
                }
            }

            gameObject.GetComponent<StaticWordScript>().selectable = true;

            #region old
            //for (int i = 0; i < wordsMatchLeft[matchIndex].Length; i++)
            //{
            //    GameObject letter = Instantiate(letterButton, letterButtonsHolder.transform.position, Quaternion.identity);
            //    letter.transform.SetParent(letterButtonsHolder.transform, true);
            //    letter.transform.localScale = new Vector3(1, 1, 1);
            //    letter.transform.GetChild(0).GetComponent<Text>().text = chars[i].ToString().ToUpper();
            //    letter.transform.SetSiblingIndex(Random.Range(0, wordsMatchLeft[matchIndex].Length));

            //    GameObject nameText = Instantiate(nameTextPrefab, nameHolder.transform.position, Quaternion.identity);
            //    nameText.transform.SetParent(nameHolder.transform, true);
            //    nameText.transform.localScale = new Vector3(1, 1, 1);
            //    nameText.GetComponent<NameTextScript>().index = i;
            //}
            #endregion
        }

        else 
        {
            IncorrectSound();
        }
    }
    #endregion
}
