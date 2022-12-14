using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResultPanel : MonoBehaviour
{
    public GameObject BadgeObj;

    public Dictionary<string, Sprite> ResultDict = new();

    public Sprite GoldSprite, SilverSprite, BronzeSprite, LoseSprite;
    public string GoldStr = "Barakalla", SilverStr = "Zo'r", BronzeStr = "Yaxshi", LoseStr = "Yomon";


    void Start()
    {
        MakeResultDict();
    }


    public void MakeResultDict()
    {
        ResultDict.Add(GoldStr, GoldSprite);
        ResultDict.Add(SilverStr, SilverSprite);
        ResultDict.Add(BronzeStr, BronzeSprite);
        ResultDict.Add(LoseStr, LoseSprite);

    }


    
}
