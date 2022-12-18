using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Draggable_3class : MonoBehaviour
{
    [Header("Scripts")]
    GamePlayController_3_1 gamePlayController;

    [Header("GameObjects")]
    public Text wordText;
    GameObject collisionGameObject;

    [Header("Variables")]
    Camera mainCamera;
    [HideInInspector] public bool matched;

    [Header("Transforms")]
    public Transform startTransform;

    public string _SceneName;

    //Integers
    public int matchIndex;

    //Vectors
    public Vector3 startPos;
    public Vector3 draggingOffset;
    public Vector3 snappingPoint;


    private void Awake()
    {
        matched = false;
        mainCamera = Camera.main;
    }

    private void Start()
    {
        startTransform = transform.parent;
        startPos = transform.position;
        gamePlayController = GameObject.FindGameObjectWithTag("GPC").GetComponent<GamePlayController_3_1>();
        _SceneName = gamePlayController.sceneName;
    }

    private void OnMouseDown()
    {
        draggingOffset = transform.position - GetMousePosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Matchable_Holders")
        {
            snappingPoint = collision.gameObject.transform.position;
            collisionGameObject = collision.gameObject;
        }
    }


    void CheckCollision() 
    {
        if (_SceneName == "3_1") 
        {
            if (collisionGameObject && collisionGameObject.GetComponent<StaticWordScript>().matchIndex == matchIndex)
            {
                gamePlayController.CorrectSound();
                gameObject.transform.SetParent(collisionGameObject.transform, true);
                transform.position = snappingPoint;
                gamePlayController._Matched++;
                matched = true;
                gamePlayController.CheckMatchCount();
            }

            else
            {
                gamePlayController.IncorrectSound();
                transform.position = startPos;
                gameObject.GetComponentInParent<HorizontalLayoutGroup>().enabled = false;
                gameObject.GetComponentInParent<HorizontalLayoutGroup>().enabled = true;

            }
        }
        if (_SceneName == "3_2") 
        {
            if (collisionGameObject && collisionGameObject.GetComponent<StaticWordScript>().matchIndex == matchIndex)
            {
                gamePlayController.CorrectSound();
                transform.position = snappingPoint;
                gamePlayController._Matched++;
                matched = true;
                gamePlayController.CheckMatchCount();
            }

            else
            {
                gamePlayController.IncorrectSound();
                transform.position = startPos;
                gameObject.GetComponentInParent<GridLayoutGroup>().enabled = false;
                gameObject.GetComponentInParent<GridLayoutGroup>().enabled = true;

            }
        }
        if (_SceneName == "3_4")
        {
            if (collisionGameObject && collisionGameObject.GetComponent<StaticWordScript>().matchIndex == matchIndex)
            {
                gamePlayController._Matched++;

                if (gamePlayController._Matched < gamePlayController.levelSlider.maxValue)
                {
                    gamePlayController.CorrectSound();
                    //transform.position = snappingPoint;

                    gamePlayController.levelSlider.value++;

                    gameObject.transform.SetParent(collisionGameObject.transform, true);
                    gameObject.transform.localPosition = new Vector3(0, 0, 0);
                    gameObject.transform.SetSiblingIndex(0);

                    gamePlayController.levelText.text = gamePlayController.levelSlider.value + "/" + gamePlayController.levelSlider.maxValue.ToString();
                    gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                    gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    Invoke("RigidbodyToKinematic", 0.5f);
                    matched = true;
                }

                else if(gamePlayController._Matched == gamePlayController.levelSlider.maxValue)
                {
                    gamePlayController.CorrectSound();
                    transform.position = snappingPoint;

                    gamePlayController.levelSlider.value++;

                    gameObject.transform.SetParent(collisionGameObject.transform, true);
                    gameObject.transform.SetSiblingIndex(0);

                    gamePlayController.levelText.text = gamePlayController.levelSlider.value + "/" + gamePlayController.levelSlider.maxValue.ToString();
                    gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    //Invoke("RigidbodyToKinematic", 0.5f);
                    matched = true;

                    gamePlayController.winPanel.SetActive(true);
                }

            }

            else
            {
                gamePlayController.IncorrectSound();
                transform.position = startPos;
                gameObject.GetComponentInParent<HorizontalLayoutGroup>().enabled = false;
                gameObject.GetComponentInParent<HorizontalLayoutGroup>().enabled = true;

            }
        }
        if (_SceneName == "3_5")
        {
            if (collisionGameObject && collisionGameObject.GetComponent<StaticWordScript>().matchIndex == matchIndex)
            {
                gamePlayController.InstaniateCorrectPS(collisionGameObject);
                gamePlayController.previousGameObject = gameObject;

                if (gamePlayController._Matched < gamePlayController.levelSlider.maxValue)
                {
                    gamePlayController.CorrectSound();
                    transform.position = snappingPoint;

                    gameObject.transform.SetParent(collisionGameObject.transform, true);

                    gamePlayController.matchIndex = matchIndex;
                    gamePlayController.FindNameOfPlanet(gameObject);
                    matched = true;

                }

                else if (gamePlayController._Matched == gamePlayController.levelSlider.maxValue)
                {
                    gamePlayController.CorrectSound();
                    transform.position = snappingPoint;

                    gamePlayController.levelSlider.value++;

                    gameObject.transform.SetParent(collisionGameObject.transform, true);

                    gamePlayController.levelText.text = gamePlayController.levelSlider.value + "/" + gamePlayController.levelSlider.maxValue.ToString();
                    matched = true;

                    gamePlayController.winPanel.SetActive(true);
                }

            }

            else
            {
                gamePlayController.IncorrectSound();
                transform.position = startPos;
                gameObject.GetComponentInParent<HorizontalLayoutGroup>().enabled = false;
                gameObject.GetComponentInParent<HorizontalLayoutGroup>().enabled = true;
            }
        }
        if(_SceneName == "3_7") 
        {
            if (collisionGameObject && !collisionGameObject.GetComponent<StaticWordScript>().selectable)
            {
                gamePlayController._Matched++;
                gamePlayController.matchIndex = collisionGameObject.GetComponent<StaticWordScript>().matchIndex;

                if (gamePlayController._Matched < gamePlayController.levelSlider.maxValue)
                {
                    gamePlayController.CorrectSound();
                    gamePlayController.InstaniateCorrectPS2(collisionGameObject);
                    collisionGameObject.GetComponent<Animator>().SetTrigger("Found");
                    collisionGameObject.GetComponent<StaticWordScript>().selectable = true;
                    gamePlayController.dialogWindow.gameObject.SetActive(true);
                    gamePlayController.selectedGOimage.sprite = collisionGameObject.GetComponent<Image>().sprite;

                    
                }

                else if (gamePlayController._Matched == gamePlayController.levelSlider.maxValue)
                {
                    gamePlayController.CorrectSound();
                    gamePlayController.InstaniateCorrectPS2(collisionGameObject);
                    collisionGameObject.GetComponent<Animator>().SetTrigger("Found");
                    collisionGameObject.GetComponent<StaticWordScript>().selectable = true;
                    gamePlayController.dialogWindow.gameObject.SetActive(true);
                    gamePlayController.selectedGOimage.sprite = collisionGameObject.GetComponent<Image>().sprite;

                }

            }
        }
    }

    private void OnMouseUp()
    {
        if (!matched) 
        {
            CheckCollision();
        }

    }

    private void OnMouseDrag()
    {
        if (!matched) 
        {
            transform.position = GetMousePosition() + draggingOffset;
        }
    }

    void RigidbodyToKinematic() 
    {
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    Vector3 GetMousePosition() 
    {
        var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        return mousePos;
    }
}
