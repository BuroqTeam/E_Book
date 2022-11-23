using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FathullohExample
{
    public class ChapterElement : MonoBehaviour
    {
        public List<GameObject> Topics;
        public List<GameObject> ReverseTopics;
        public Sprite OpenArrow, CloseArrow;
        public bool _IsOpen;

        const float switchDuration = 0.08f;
        Button button;

        
        void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(SpriteChange);
            ReverseTopics = new List<GameObject>(Topics);
            ReverseTopics.Reverse();
        }


        public void SpriteChange()
        {
            if (_IsOpen)
            {
                _IsOpen = false;
                gameObject.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = CloseArrow;
                StartCoroutine(SwitchOnTopics(true));
                //Debug.Log("Open Arrow.");
            }
            else if(!_IsOpen)
            {
                _IsOpen = true;
                gameObject.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = OpenArrow;
                StartCoroutine(SwitchOffTopics(false));
                //Debug.Log("Close Arrow.");
            }
        }


        IEnumerator SwitchOnTopics(bool _isTrue)
        {
            for (int i = 0; i < Topics.Count; i++)
            {
                yield return new WaitForSeconds(switchDuration);
                Topics[i].SetActive(_isTrue);
            }

            yield return new WaitForSeconds(switchDuration - 0.01f);
        }


        IEnumerator SwitchOffTopics(bool _isTrue)
        {
            for (int i = 0; i < ReverseTopics.Count; i++)
            {
                yield return new WaitForSeconds(switchDuration);
                ReverseTopics[i].SetActive(_isTrue);
            }
            yield return new WaitForSeconds(switchDuration - 0.01f);
        }


        



    }
}
