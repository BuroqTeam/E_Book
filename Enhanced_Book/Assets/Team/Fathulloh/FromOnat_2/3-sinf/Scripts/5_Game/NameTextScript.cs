using UnityEngine;
using UnityEngine.UI;

public class NameTextScript : MonoBehaviour
{

    [HideInInspector] public string nameCharacter;
    [HideInInspector] public int index;
    public Text text;
    GamePlayController_3_1 gamePlayController;

    private void Start()
    {
        gamePlayController = GameObject.FindGameObjectWithTag("GPC").GetComponent<GamePlayController_3_1>();
    }

    public void DeleteCharacter() 
    {
        if (text.text != "_") 
        {
            nameCharacter = "_";
            text.text = nameCharacter;
        }
    }

}
