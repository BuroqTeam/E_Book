using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;


public class FinishPanel : MonoBehaviour
{
    public GameObject background;
    public List<GameObject> starGroup;
    public List<GameObject> offGroup;
    public string homeSceneName;
    public string sceneName;


    private void Awake()
    {
        background.GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<RectTransform>().DOScale(0, 0);

    }

    public void StarAnimation()
    {
        StartCoroutine(StarAnim());
        
    }


    IEnumerator StarAnim()
    {
        foreach (var item in offGroup)
        {
            item.gameObject.SetActive(false);
        }
        background.GetComponent<SpriteRenderer>().enabled = true;
        background.GetComponent<SpriteRenderer>().DOColor(Color.white, 0.5f);
        GetComponent<RectTransform>().DOScale(1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        foreach (var item in starGroup)
        {
            item.GetComponent<Image>().color = Color.white;
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(0.5f);
        }        
    }


    public void ClickHomeButton()
    {
        SceneManager.LoadScene(homeSceneName);
        
    }

    public void ClickReplayButton()
    {
        SceneManager.LoadScene(sceneName);
    }

    
}
