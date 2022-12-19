using UnityEngine;
using UnityEngine.UI;

public class LetterButtonScript : MonoBehaviour
{
    public char[] _character;
    GamePlayController_3_1 gamePlayController;

    private void Start()
    {
        gamePlayController = GameObject.FindGameObjectWithTag("GPC").GetComponent<GamePlayController_3_1>();
        _character = gameObject.transform.GetChild(0).GetComponent<Text>().text.ToCharArray();
    }

    public void SetCharacter() 
    {
        gamePlayController.SetNameOfPlanet(_character[0], gameObject);
    }
    public void SetCharacter_8Level()
    {
        gamePlayController.MatchJobName(_character, gameObject);
    }
}
