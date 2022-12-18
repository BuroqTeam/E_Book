using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanelScript : MonoBehaviour
{
    public SoundManager_3 soundManager;
    public GameObject[] stars;
    public GameObject[] shine;
    public GameObject buttonsPanel;
    int starsCount;

    IEnumerator StarsActivate()
    {
        while (starsCount < 3)
        {
            soundManager.StarGain();

            shine[starsCount].SetActive(true);
            stars[starsCount].SetActive(true);

            starsCount++;

            yield return new WaitForSeconds(0.3f);

        }

        soundManager.ButtonScaleUp();
        buttonsPanel.SetActive(true);
    }

    public void StartCouroutineOfStars()
    {
        StartCoroutine(StarsActivate());
    }
}
