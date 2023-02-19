using Buroq.Transitions.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Linq;

public class Transition : MonoBehaviour
{
    public static Transition Instance;
    public enum TransitionType
    {
        PanelMoveForward,
        PanelMoveBack,
        PanelMoveUp,
        PanelMoveDown,        
        HorizontalGate,
        VerticalGate,
        PanelFade
    }
    public TransitionType CurrentTransition;

    [HideInInspector]
    public List<GameObject> MainObjects;
    private GameObject MainObject, MainObject2;

    public Sprite newSprite;
    public Color ColorImage;

    [Range(0.1f, 10.0f)]
    public float Durration;

    float screenHeight, screenWidth;

    private Texture2D tex;
    private Sprite mySprite1, mySprite2;


    private void Awake()
    {        
        Instance = this;
        InitialMethod();
    }


    void Start()
    {
        //Debug.Log(" " + TransitionType.HorizontalGate.ToString());
        
    }


    void InitialMethod()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
        
        MainObject = transform.GetChild(0).gameObject;
    }


    public void Play()
    {
        ClearList();
        MainObject.SetActive(true);

        if (newSprite != null)        
            MainObject.GetComponent<Image>().sprite = newSprite;        
        
        MainObject.GetComponent<Image>().color = ColorImage;

        switch (CurrentTransition)
        {
            case TransitionType.PanelMoveForward:                
                MainObject.GetComponent<RectTransform>().TransitionMovementStart(Vector3.forward, Durration);
                break;
            case TransitionType.PanelMoveBack:                
                MainObject.GetComponent<RectTransform>().TransitionMovementStart(Vector3.back, Durration);
                break;
            case TransitionType.PanelMoveUp:                
                MainObject.GetComponent<RectTransform>().TransitionMovementStart(Vector3.up, Durration);
                break;
            case TransitionType.PanelMoveDown:                
                MainObject.GetComponent<RectTransform>().TransitionMovementStart(Vector3.down, Durration);
                break;
            case TransitionType.HorizontalGate:
                if (MainObjects.Count == 0) 
                {
                    MainObject2 = Instantiate(MainObject, gameObject.transform);
                    MainObject2.SetActive(true);                    
                    MainObjects.Add(MainObject);
                    MainObjects.Add(MainObject2);
                }
                SliceHorizontal(MainObject, MainObject2);
                MainObjects.TransitionHorizontalGateStart(Durration);
                break;
            case TransitionType.VerticalGate:
                if (MainObjects.Count == 0)
                {
                    MainObject2 = Instantiate(MainObject, gameObject.transform);
                    MainObject2.SetActive(true);
                    MainObjects.Add(MainObject);
                    MainObjects.Add(MainObject2);
                }                
                SliceVertical(MainObject, MainObject2);
                TransitionVerticalGateStart(MainObjects, screenWidth, screenHeight, Durration);                
                break;
            case TransitionType.PanelFade:
                MainObject.TransitionPanelFadeStart(MainObject.GetComponent<CanvasGroup>(), ColorImage, Durration);
                break;
            default:
                break;
        }        
    }


    public void Play(string transitionName)
    {
        MainObject.GetComponent<CanvasGroup>().interactable = true;
        MainObject.GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (TransitionType.PanelMoveForward.ToString() == transitionName)
        {
            CurrentTransition = TransitionType.PanelMoveForward;
        }
        else if (TransitionType.PanelMoveBack.ToString() == transitionName)
        {
            CurrentTransition = TransitionType.PanelMoveBack;
        }
        else if (TransitionType.PanelMoveUp.ToString() == transitionName)
        {
            CurrentTransition = TransitionType.PanelMoveUp;
        }
        else if (TransitionType.PanelMoveDown.ToString() == transitionName)
        {
            CurrentTransition = TransitionType.PanelMoveDown;
        }
        else if (TransitionType.HorizontalGate.ToString() == transitionName)
        {
            CurrentTransition = TransitionType.HorizontalGate;
        }
        else if (TransitionType.VerticalGate.ToString() == transitionName)
        {
            CurrentTransition = TransitionType.VerticalGate;
        }
        else if (TransitionType.PanelFade.ToString() == transitionName)
        {
            CurrentTransition = TransitionType.PanelFade;
        }
        Play();
    }


    public void Ending()
    {
        ClearList();
        MainObject.SetActive(true);

        if (newSprite != null)
            MainObject.GetComponent<Image>().sprite = newSprite;

        MainObject.GetComponent<Image>().color = ColorImage;

        switch (CurrentTransition)
        {
            case TransitionType.PanelMoveForward:
                MainObject.GetComponent<RectTransform>().TransitionMovementEnd(Vector3.forward, Durration);
                break;
            case TransitionType.PanelMoveBack:
                MainObject.GetComponent<RectTransform>().TransitionMovementEnd(Vector3.back, Durration);
                break;
            case TransitionType.PanelMoveUp:
                MainObject.GetComponent<RectTransform>().TransitionMovementEnd(Vector3.up, Durration);
                break;
            case TransitionType.PanelMoveDown:
                MainObject.GetComponent<RectTransform>().TransitionMovementEnd(Vector3.down, Durration);
                break;            
            case TransitionType.HorizontalGate:
                if (MainObjects.Count == 0 )
                {
                    MainObject2 = Instantiate(MainObject, gameObject.transform);
                    MainObject2.SetActive(true);
                    MainObjects.Add(MainObject);
                    MainObjects.Add(MainObject2);
                }
                SliceHorizontal(MainObject, MainObject2);
                MainObjects.TransitionHorizontalGateEnd(Durration);
                break;
            case TransitionType.VerticalGate:
                if (MainObjects.Count == 0 )
                {
                    MainObject2 = Instantiate(MainObject, gameObject.transform);
                    MainObject2.SetActive(true);
                    MainObjects.Add(MainObject);
                    MainObjects.Add(MainObject2);
                }
                SliceVertical(MainObject, MainObject2);
                TransitionVerticalGateEnd(MainObjects, screenWidth, screenHeight, Durration);
                break;
            case TransitionType.PanelFade:
                MainObject.TransitionPanelFadeEnd(MainObject.GetComponent<CanvasGroup>(), ColorImage, Durration);
                break;
            default:
                break;
        }        
    }


    public void Ending(string sceneName)
    {
        ClearList();
        MainObject.SetActive(true);

        if (newSprite != null)
            MainObject.GetComponent<Image>().sprite = newSprite;

        MainObject.GetComponent<Image>().color = ColorImage;

        switch (CurrentTransition)
        {
            case TransitionType.PanelMoveForward:
                MainObject.GetComponent<RectTransform>().TransitionMovementEnd(Vector3.forward, Durration, sceneName);
                break;
            case TransitionType.PanelMoveBack:
                MainObject.GetComponent<RectTransform>().TransitionMovementEnd(Vector3.back, Durration, sceneName);
                break;
            case TransitionType.PanelMoveUp:
                MainObject.GetComponent<RectTransform>().TransitionMovementEnd(Vector3.up, Durration, sceneName);
                break;
            case TransitionType.PanelMoveDown:
                MainObject.GetComponent<RectTransform>().TransitionMovementEnd(Vector3.down, Durration, sceneName);
                break;
            case TransitionType.HorizontalGate:
                if (MainObjects.Count == 0 /*|| (MainObjects.Count == 1)*/)
                {
                    MainObject2 = Instantiate(MainObject, gameObject.transform);
                    MainObject2.SetActive(true);
                    MainObjects.Add(MainObject);
                    MainObjects.Add(MainObject2);
                }
                SliceHorizontal(MainObject, MainObject2);
                MainObjects.TransitionHorizontalGateEnd(Durration);
                break;
            case TransitionType.VerticalGate:
                if (MainObjects.Count == 0 /*|| (MainObjects.Count == 1)*/)
                {
                    MainObject2 = Instantiate(MainObject, gameObject.transform);
                    MainObject2.SetActive(true);
                    MainObjects.Add(MainObject);
                    MainObjects.Add(MainObject2);
                }
                SliceVertical(MainObject, MainObject2);
                TransitionVerticalGateEnd(MainObjects, screenWidth, screenHeight, Durration);
                break;
            case TransitionType.PanelFade:
                MainObject.TransitionPanelFadeEnd(MainObject.GetComponent<CanvasGroup>(), ColorImage, Durration);
                break;
            default:
                break;
        }
        StartCoroutine(NextScene(sceneName, Durration *1.2f));        
    }


    /// <summary>
    /// Load Next scene.
    /// </summary>
    /// <param name="sceneName"></param>
    IEnumerator NextScene(string sceneName, float durration)
    {
        yield return new WaitForSeconds(durration);
        SceneManager.LoadScene(sceneName);
    }


    
    void SliceHorizontal(GameObject obj1, GameObject obj2)
    {        
        tex = newSprite.texture;
        float spriteHeight = tex.height;
        float spriteWidth = tex.width;
        mySprite1 = Sprite.Create(tex, new Rect(0, 0, spriteWidth / 2, spriteHeight), new Vector2(0.5f, 0.5f));
        mySprite2 = Sprite.Create(tex, new Rect(spriteWidth / 2, 0, spriteWidth / 2, spriteHeight), new Vector2(0.5f, 0.5f));

        obj1.GetComponent<Image>().sprite = mySprite1;
        obj2.GetComponent<Image>().sprite = mySprite2;
    }


    void SliceVertical(GameObject obj1, GameObject obj2)
    {        
        tex = newSprite.texture;
        float spriteHeight = tex.height;
        float spriteWidth = tex.width;
        mySprite1 = Sprite.Create(tex, new Rect(0, 0, spriteWidth, spriteHeight / 2), new Vector2(0.5f, 0.5f));
        mySprite2 = Sprite.Create(tex, new Rect(0, spriteHeight / 2, spriteWidth, spriteHeight/2), new Vector2(0.5f, 0.5f));

        obj1.GetComponent<Image>().sprite = mySprite2;
        obj2.GetComponent<Image>().sprite = mySprite1;
    }


    public void TransitionVerticalGateStart( List<GameObject> objs, float screenWidth, float screenHeight, float durration)
    {
        GameObject gObj = GameObject.Find("Canvas");
        Vector2 resolution;

        if (gObj != null)
        {            
            resolution = gObj.GetComponent<CanvasScaler>().referenceResolution;
            float verticalPos = screenHeight / screenWidth * resolution.x;
            //Debug.Log("Screen.height = " + screenHeight + "  Screen.width = " + screenWidth + "  resolution.x = " + resolution.x + "  verticalPos = " + verticalPos);
            
            objs[0].GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            objs[0].GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);

            objs[1].GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            objs[1].GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);

            objs[0].GetComponent<RectTransform>().offsetMin = new Vector2(0, verticalPos / 2);
            objs[0].GetComponent<RectTransform>().DOAnchorMin(new Vector2(0, 0), 0);
            objs[0].GetComponent<RectTransform>().DOAnchorMax(new Vector2(1, 1), 0);

            objs[1].GetComponent<RectTransform>().offsetMax = new Vector2(0, -verticalPos / 2);
            objs[1].GetComponent<RectTransform>().DOAnchorMin(new Vector2(0, 0), 0);
            objs[1].GetComponent<RectTransform>().DOAnchorMax(new Vector2(1, 1), 0);

            objs[0].GetComponent<RectTransform>().DOAnchorPos(new Vector3(0, verticalPos), durration);
            objs[1].GetComponent<RectTransform>().DOAnchorPos(new Vector3(0, -verticalPos), durration);
        }        
    }


    public void TransitionVerticalGateEnd(List<GameObject> objs, float screenWidth, float screenHeight, float durration)
    {
        GameObject gObj = GameObject.Find("Canvas");
        Vector2 resolution;

        if (gObj != null)
        {            
            resolution = gObj.GetComponent<CanvasScaler>().referenceResolution;
            float verticalPos = screenHeight / screenWidth * resolution.x;            
            //Debug.Log("Screen.height =" + Screen.height + " Screen.width = " + Screen.width + " resolution.x " + resolution.x + " verticalPos = " + verticalPos);

            objs[0].GetComponent<RectTransform>().offsetMin = new Vector2(0, verticalPos);
            objs[0].GetComponent<RectTransform>().offsetMax = new Vector2(0, verticalPos / 2);

            objs[1].GetComponent<RectTransform>().offsetMin = new Vector2(0, -verticalPos / 2);
            objs[1].GetComponent<RectTransform>().offsetMax = new Vector2(0, -verticalPos);

            objs[0].GetComponent<RectTransform>().DOAnchorMin(new Vector2(0, 0), 0);
            objs[0].GetComponent<RectTransform>().DOAnchorMax(new Vector2(1, 1), 0);

            objs[1].GetComponent<RectTransform>().DOAnchorMin(new Vector2(0, 0), 0);
            objs[1].GetComponent<RectTransform>().DOAnchorMax(new Vector2(1, 1), 0);

            objs[0].GetComponent<RectTransform>().DOAnchorPosY(verticalPos / 4, durration);
            objs[1].GetComponent<RectTransform>().DOAnchorPosY(-verticalPos / 4, durration);                      
        }
    }


    void ClearList()
    {
        if (gameObject.transform.childCount > 1)
        {
            Destroy(gameObject.transform.GetChild(1).gameObject);
        }
        
        MainObjects.Clear();
        MainObject2 = null;
        MainObject.GetComponent<CanvasGroup>().interactable = true;
        MainObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }



}



