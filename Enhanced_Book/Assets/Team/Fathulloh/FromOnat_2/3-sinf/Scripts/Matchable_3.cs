using UnityEngine;

public class Matchable_3 : MonoBehaviour
{
    public GamePlayController_3_1 gamePlayController;
    string sceneName;
    public int matchIndex;
    public int additionalIndex;
    public bool selectable;
    public bool selected;

    //2_Game
    [HideInInspector]public int transportType;

    private void Start()
    {
        //gamePlayController = GameObject.FindGameObjectWithTag("GPC").GetComponent<GamePlayController_3_1>();
        sceneName = gamePlayController.sceneName;
    }

    public void SetGameObject() 
    {
        if (!selectable) 
        {
            gamePlayController.ClickSound();
            gamePlayController.selectedGo = gameObject;
            gamePlayController.matchIndex = matchIndex;
            selectable = true;
        }

    }

    public void CloseOtherButton() 
    {
        gamePlayController.CloseOtherButtons(gameObject);
    }
}
