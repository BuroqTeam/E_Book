using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace FathullohExample
{
    public class OpenCloseButton : MonoBehaviour
    {
        public GameObject MundarijaPanel;
        public Ease MovementEase;
        public float MoveDuration;
        public bool _IsCenter = true;
        float panelPosition;

        public Sprite ToRightSprite, ToLeftSprite;

        
        void Start()
        {

            TakeDate();
        }



        void TakeDate()
        {
            panelPosition = MundarijaPanel.GetComponent<RectTransform>().anchoredPosition.x;            
        }



        public void PanelMoveToLeft()
        {                                  

            if (_IsCenter)
            {
                //Debug.Log(-MundarijaPanel.GetComponent<RectTransform>().sizeDelta.x / 3.7f);
                MundarijaPanel.GetComponent<RectTransform>()
                    .DOAnchorPosX(-MundarijaPanel.GetComponent<RectTransform>().sizeDelta.x / 3.65f, MoveDuration)
                    .SetEase(MovementEase);
                _IsCenter = false;
                transform.GetChild(1).GetComponent<Image>().sprite = ToRightSprite;
            }
            else if (!_IsCenter)
            {
                MundarijaPanel.GetComponent<RectTransform>()
                    .DOAnchorPosX(panelPosition, MoveDuration)
                    .SetEase(MovementEase);
                _IsCenter = true;
                transform.GetChild(1).GetComponent<Image>().sprite = ToLeftSprite;
            }

        }





    }
}
