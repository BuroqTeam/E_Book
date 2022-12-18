using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YuzlikFathulloh;

public class GameResultPanel : MonoBehaviour
{
    public GameObject BadgeObj;
    public GameObject BadgeText;
    public GameObject TimerObject;
    public TMP_Text TimeText;


    public Sprite GoldSprite, SilverSprite, BronzeSprite, LoseSprite;
    private const string GoldStr = "Barakalla !";
    private const string SilverStr = "Zo'r !";
    private const string BronzeStr = "Yaxshi !";
    private const string LoseStr = "Yomon !";


    public int TimeGold;
    public int TimeSilver;
    public int TimeBronze;


    void Start()
    {
        
    }


    /// <summary>
    /// Game1 dagi 10 daqiqalik vaqtga moslangan Badgeni tanlab beradi.
    /// </summary>
    public void ChooseBadge()
    {
        float spendingTime = TimerObject.GetComponent<Timer>().currentTime;

        if (spendingTime > 200)        {
            BadgeObj.GetComponent<Image>().sprite = GoldSprite;
            BadgeText.GetComponent<TMP_Text>().text = GoldStr;
        }
        else if (spendingTime > 120)
        {
            BadgeObj.GetComponent<Image>().sprite = SilverSprite;
            BadgeText.GetComponent<TMP_Text>().text = SilverStr;
        }
        else if (spendingTime > 0)
        {
            BadgeObj.GetComponent<Image>().sprite = BronzeSprite;
            BadgeText.GetComponent<TMP_Text>().text = BronzeStr;
        }
        else if (spendingTime <= 0)
        {
            BadgeObj.GetComponent<Image>().sprite = LoseSprite;
            BadgeText.GetComponent<TMP_Text>().text = LoseStr;
        }

        TimeText.text = TimerObject.transform.GetChild(0).GetComponent<TMP_Text>().text;
    }


    /// <summary>
    /// public orqali kiritilgan vaqtlarga ko'ra sovrin beradi.
    /// </summary>
    public void ChooseBadgeHandle()
    {
        float spendingTime = TimerObject.GetComponent<Timer>().currentTime;

        if (spendingTime > TimeGold)
        {
            BadgeObj.GetComponent<Image>().sprite = GoldSprite;
            BadgeText.GetComponent<TMP_Text>().text = GoldStr;
        }
        else if (spendingTime > TimeSilver)
        {
            BadgeObj.GetComponent<Image>().sprite = SilverSprite;
            BadgeText.GetComponent<TMP_Text>().text = SilverStr;
        }
        else if (spendingTime > TimeBronze)
        {
            BadgeObj.GetComponent<Image>().sprite = BronzeSprite;
            BadgeText.GetComponent<TMP_Text>().text = BronzeStr;
        }
        else if (spendingTime <= 0)
        {
            BadgeObj.GetComponent<Image>().sprite = LoseSprite;
            BadgeText.GetComponent<TMP_Text>().text = LoseStr;
        }

        TimeText.text = TimerObject.transform.GetChild(0).GetComponent<TMP_Text>().text;
    }

    
}
