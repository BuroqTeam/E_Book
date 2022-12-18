using UnityEngine;
using UnityEngine.UI;

public class StaticWordScript : MonoBehaviour
{
    GamePlayController_3_1 gamePlayController;
    public int matchIndex;
    public bool selectable = false;
    bool selected = false;


    private void Start()
    {
        gamePlayController = GameObject.FindGameObjectWithTag("GPC").GetComponent<GamePlayController_3_1>();  
    }
    public void MatchGO() 
    {
        if (selectable) 
        {
            if (matchIndex == gamePlayController.selectedGo.GetComponent<Matchable_3>().matchIndex)
            {
                gamePlayController.dialogWindow.SetActive(true);
                gamePlayController.selectedGo_2 = gameObject;
                gamePlayController.CorrectSound();
                gamePlayController.selectedGOimage.sprite = gameObject.GetComponent<Image>().sprite;
            }
            else
            {
                gamePlayController.IncorrectSound();
                gamePlayController.OpenOtherButtons();
            }
        }

    }

    public void SetIndex() 
    {
        if (!selectable && !gamePlayController.dialogWindow.activeInHierarchy) 
        {
            gamePlayController.matchIndex = matchIndex;
            gamePlayController.selectedGo = gameObject;
            gamePlayController.OpenDialogWindow();
            gamePlayController.previousGameObject = gameObject;
            selectable = true;
        }
    }

    public void CheckIndex() 
    {
        if (gamePlayController.sceneName == "3_10" && !selectable) gamePlayController.CheckIndex(matchIndex, gameObject);
        if (gamePlayController.sceneName == "3_9" && !selectable) gamePlayController.CheckIndex_2(matchIndex, gameObject);
        gamePlayController.previousGameObject = gameObject;

    }

    public void CloseGameObject() 
    {
        gameObject.SetActive(false);
    }

}
