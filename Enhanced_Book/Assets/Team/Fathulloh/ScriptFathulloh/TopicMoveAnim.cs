using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class TopicMoveAnim : MonoBehaviour
{
    public List<GameObject> SwitchedObjects;
    public List<GameObject> ReverseObjects;
    float _duration = 0.08f;


    void Start()
    {
        ReverseObjects = new List<GameObject>(SwitchedObjects);
        ReverseObjects.Reverse();
    }

    
    public void OpenTopic()        // Topiclarni ochish uchun.
    {
        StartCoroutine(OpenTopics());        
    }


    IEnumerator OpenTopics()
    {
        for (int i = 0; i < SwitchedObjects.Count; i++)
        {   
            yield return new WaitForSeconds(_duration);
            SwitchedObjects[i].SetActive(true);            
        }
        yield return new WaitForSeconds(_duration - 0.01f);
        gameObject.SetActive(false);        
    }


    public void CloseTopic()        // Topiclarni yopish uchun.
    {
        StartCoroutine(CloseTopics());
    }


    IEnumerator CloseTopics()
    {
        for (int i = 0; i < ReverseObjects.Count; i++)
        {
            yield return new WaitForSeconds(_duration);
            ReverseObjects[i].SetActive(false);
        }

        gameObject.SetActive(false);
    }


    public void SwitchObj()
    {
        SwitchedObjects[0].SetActive(true);
    }

}
