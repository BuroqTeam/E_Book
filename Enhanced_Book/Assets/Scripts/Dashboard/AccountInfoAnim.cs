using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AccountInfoAnim : MonoBehaviour
{
    public TMP_Text OveralScore;
    public TMP_Text Level;
    public TMP_Text Badges;

    private void OnEnable()
    {
        StartCoroutine(OveralScoretAnim());
        StartCoroutine(LeveltAnim());
        StartCoroutine(BadgestAnim());
    }

    public IEnumerator OveralScoretAnim()
    {
        for (float i = 0; i < 49; i++)
        {
            OveralScore.GetComponent<TMP_Text>().text = (i * 0.1f).ToString();
            yield return new WaitForSeconds(0.02f);
        }
    }

    public IEnumerator LeveltAnim()
    {
        for (int i = 0; i < 5; i++)
        {
            Level.GetComponent<TMP_Text>().text = i.ToString();
            yield return new WaitForSeconds(0.225f);
        }
    }

    public IEnumerator BadgestAnim()
    {
        for (int i = 0; i < 15; i++)
        {
            Badges.GetComponent<TMP_Text>().text = i.ToString();
            yield return new WaitForSeconds(0.065f);
        }
    }
}
