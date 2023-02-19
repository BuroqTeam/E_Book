using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

namespace Buroq.Transitions.UI
{
    public static class TransitionExtension
    {
        // Rectangle move transition
        /// <summary>
        /// Make Transition to up, down, back, forward.
        /// </summary>
        /// <param name="obj">Transition bo'ladigan obyektning RectTransformi</param>
        /// <param name="vec">Choose Vector3 and up, down, back or forward</param>
        /// <param name="durration">time</param>
        public static void TransitionMovementStart(this RectTransform rectTransform, Vector3 vec, float durration)
        {
            rectTransform.offsetMax = new Vector2(0, 0);
            rectTransform.offsetMin = new Vector2(0, 0);

            rectTransform.DOAnchorMax(new Vector2(1, 1), 0);
            rectTransform.DOAnchorMin(new Vector2(0, 0), 0);

            rectTransform.DOAnchorPos(new Vector3(0, 0, 0), 0);

            GameObject gObj = GameObject.Find("Canvas");
            Vector2 resolution = gObj.GetComponent<CanvasScaler>().referenceResolution;

            if (vec == Vector3.forward)
                rectTransform.DOAnchorPosX(/*Screen.width / 2*/ resolution.x, durration);
            else if (vec == Vector3.back)
                rectTransform.DOAnchorPosX(/*-Screen.width / 2*/ -resolution.x, durration);
            else if (vec == Vector3.up)
                rectTransform.DOAnchorPosY(/*Screen.height / 2*/ resolution.y, durration);
            else if (vec == Vector3.down)
                rectTransform.DOAnchorPosY(/*-Screen.height / 2*/ -resolution.y, durration);
            
            //Debug.Log(rectTransform.anchoredPosition + " Screen.width = " + Screen.width + " Screen.height = " + Screen.height);
        }

                
        public static void TransitionMovementEnd(this RectTransform rectTransform, Vector3 vec, float durration)
        {
            rectTransform.offsetMax = new Vector2(0, 0);
            rectTransform.offsetMin = new Vector2(0, 0);

            rectTransform.DOAnchorMax(new Vector2(1, 1), 0);
            rectTransform.DOAnchorMin(new Vector2(0, 0), 0);

            GameObject gObj = GameObject.Find("Canvas");
            if (gObj != null)
            {
                Vector2 resolution = gObj.GetComponent<CanvasScaler>().referenceResolution;

                if (vec == Vector3.forward)                {
                    rectTransform.DOAnchorPos(new Vector3(resolution.x, 0), 0);
                    //Debug.Log(resolution.x);
                }
                else if (vec == Vector3.back)                {
                    rectTransform.DOAnchorPos(new Vector3(-resolution.x, 0), 0);
                    //Debug.Log(-resolution.x);
                }
                else if (vec == Vector3.up)                {
                    rectTransform.DOAnchorPos(new Vector3(0, resolution.y), 0);
                    //Debug.Log(resolution.y);
                }
                else if (vec == Vector3.down)                {
                    rectTransform.DOAnchorPos(new Vector3(0, -resolution.y), 0);
                    //Debug.Log(-resolution.y);
                }                                
                //Debug.Log(resolution.GetType() + "   Reference resolution = " + resolution);                    
            }
            rectTransform.DOAnchorPos(new Vector3(0, 0, 0), durration);                        
        }


        public static void TransitionMovementEnd(this RectTransform rectTransform, Vector3 vec, float durration, string sceneName)
        {
            GameObject gObj = GameObject.Find("Canvas");
            if (gObj != null)
            {
                Vector2 resolution = gObj.GetComponent<CanvasScaler>().referenceResolution;

                if (vec == Vector3.forward)                
                    rectTransform.DOAnchorPos(new Vector3(resolution.x, 0), 0);                
                else if (vec == Vector3.back)                
                    rectTransform.DOAnchorPos(new Vector3(-resolution.x, 0), 0);                
                else if (vec == Vector3.up)                
                    rectTransform.DOAnchorPos(new Vector3(0, resolution.y), 0);                
                else if (vec == Vector3.down)                
                    rectTransform.DOAnchorPos(new Vector3(0, -resolution.y), 0);                               
            }
            rectTransform.DOAnchorPos(new Vector3(0, 0, 0), durration);
             
        }

        
        //   Panel fade transition

        public static void TransitionPanelFadeStart(this GameObject obj, CanvasGroup canGroup, Color col, float durration)
        {
            obj.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            obj.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            obj.GetComponent<RectTransform>().DOAnchorMax(new Vector2(1, 1), 0);
            obj.GetComponent<RectTransform>().DOAnchorMin(new Vector2(0, 0), 0);

            obj.GetComponent<Image>().DOColor(col, 0);
            obj.GetComponent<Image>().DOFade(0, durration);

            canGroup.interactable = false;
            canGroup.blocksRaycasts = false;
        }


        public static void TransitionPanelFadeEnd(this GameObject obj, CanvasGroup canGroup, Color col, float durration)
        {
            obj.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            obj.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);

            obj.GetComponent<RectTransform>().DOAnchorMax(new Vector2(1, 1), 0);
            obj.GetComponent<RectTransform>().DOAnchorMin(new Vector2(0, 0), 0);

            obj.GetComponent<Image>().DOFade(0, 0);

            obj.GetComponent<Image>().DOFade(1, durration);
            obj.GetComponent<Image>().DOColor(col, durration);
                        
            canGroup.interactable = true;
            canGroup.blocksRaycasts = true;
        }

        
        //Hali tayyor emas bu metod.
        public static void TransitionBlackCircleStart(this RectTransform rectTransform, float circleSize, float durration)
        {
            rectTransform.GetComponent<RectTransform>().DOScale(new Vector3(circleSize, circleSize), 0);
            rectTransform.sizeDelta = new Vector2(100, 100);
            rectTransform.DOAnchorMax(new Vector2(0.5f, 0.5f), 0);
            rectTransform.DOAnchorMin(new Vector2(0.5f, 0.5f), 0);
                       
            rectTransform.GetComponent<RectTransform>().DOAnchorPos(new Vector3(0, 0, 0), 0);
            //rectTransform.GetComponent<RectTransform>().DOScale(0, durration);            
            rectTransform.GetComponent<RectTransform>().DOScale(new Vector3(0, 0), durration);            
        }


        public static void TransitionBlackCircleEnd(this RectTransform rectTransform, float circleSize, float durration)
        {
            rectTransform.DOAnchorPos(new Vector3(0, 0, 0), 0);
            rectTransform.DOAnchorMax(new Vector2(0.5f, 0.5f), 0);
            rectTransform.DOAnchorMin(new Vector2(0.5f, 0.5f), 0);
            rectTransform.DOScale(0, durration);
            rectTransform.GetComponent<RectTransform>().DOScale(new Vector3(circleSize, circleSize), durration);            
        }
        


        public static void TransitionHorizontalGateStart(this List<GameObject> objs, float durration)
        {
            GameObject gObj = GameObject.Find("Canvas");
            Vector2 resolution;
            if (gObj != null)
            {
                resolution = gObj.GetComponent<CanvasScaler>().referenceResolution;
                
                objs[0].GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
                objs[0].GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);

                objs[1].GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
                objs[1].GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);

                objs[0].GetComponent<RectTransform>().offsetMax = new Vector2(-resolution.x / 2, 0);
                objs[0].GetComponent<RectTransform>().DOAnchorMin(new Vector2(0, 0), 0);
                objs[0].GetComponent<RectTransform>().DOAnchorMax(new Vector2(1, 1), 0);

                objs[1].GetComponent<RectTransform>().offsetMin = new Vector2(resolution.x / 2, 0);
                objs[1].GetComponent<RectTransform>().DOAnchorMin(new Vector2(0, 0), 0);
                objs[1].GetComponent<RectTransform>().DOAnchorMax(new Vector2(1, 1), 0);
                
                objs[0].GetComponent<RectTransform>().DOAnchorPos(new Vector3(-resolution.x, 0), durration);
                objs[1].GetComponent<RectTransform>().DOAnchorPos(new Vector3(resolution.x, 0), durration);
            }

        }


        public static void TransitionHorizontalGateEnd(this List<GameObject> objs, float durration)
        {
            GameObject gObj = GameObject.Find("Canvas");
            Vector2 resolution;
            if (gObj != null)
            {
                resolution = gObj.GetComponent<CanvasScaler>().referenceResolution;

                objs[0].GetComponent<RectTransform>().offsetMin = new Vector2(-resolution.x / 2, 0);
                objs[0].GetComponent<RectTransform>().offsetMax = new Vector2(-resolution.x, 0);

                objs[1].GetComponent<RectTransform>().offsetMin = new Vector2(resolution.x, 0);
                objs[1].GetComponent<RectTransform>().offsetMax = new Vector2(resolution.x / 2, 0);

                objs[0].GetComponent<RectTransform>().DOAnchorMin(new Vector2(0, 0), 0);
                objs[0].GetComponent<RectTransform>().DOAnchorMax(new Vector2(1, 1), 0);

                objs[1].GetComponent<RectTransform>().DOAnchorMin(new Vector2(0, 0), 0);
                objs[1].GetComponent<RectTransform>().DOAnchorMax(new Vector2(1, 1), 0);
                Debug.Log("Ishladi!");
                objs[0].GetComponent<RectTransform>().DOAnchorPos(new Vector3(-resolution.x / 4, 0), durration);
                objs[1].GetComponent<RectTransform>().DOAnchorPos(new Vector3(resolution.x / 4, 0), durration);
            }
        }
          


    }
}
