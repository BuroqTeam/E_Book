using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.Events;

namespace YuzlikFathulloh
{
    /// <summary>
    /// Raqamlar yozilgan disklarga birlashtirilgan script.
    /// </summary>
    public class DragAndDrop : MonoBehaviour, /*IPointerDownHandler,*/ IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public enum TypeNumber { Ones, Tens, Hundreds, Thousands, TenThousands, HundredThousands }
        public TypeNumber CurrentTypeNumber;

        public Vector3 InitialPos, LastPos, InitialPos2;
        public GameObject ObjGameManager;
        public GameObject InitialParentObj;


        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        bool _IsTrue = true;
        //bool _IsParentColumn = false;

        public GameEventSO DragEvent, DropEvent, FallEvent;


        void Start()
        {
            TakePositions();
        }


        void TakePositions()
        {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();

            InitialParentObj = gameObject.transform.parent.gameObject;

            if (_IsTrue)            {
                _IsTrue = false;
                InitialPos = gameObject.transform.localPosition;
                InitialPos2 = gameObject.GetComponent<RectTransform>().localPosition;
            }
        }

        

        public void OnBeginDrag(PointerEventData eventData)
        {
            DragEvent.Raise();

            gameObject.transform.SetParent(ObjGameManager.transform);
            LastPos = gameObject.transform.localPosition /*gameObject.transform.position*/;
            
            ObjGameManager.GetComponent<GameManager>().CurrentClickedObj = gameObject;
            ObjGameManager.GetComponent<GameManager>().IsArea = false;
            canvasGroup.blocksRaycasts = false;

            //TypeOfTakePosition();
        }


        public void OnDrag(PointerEventData eventData)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(pos.x, pos.y, 0);
            rectTransform.anchoredPosition3D = new Vector3(rectTransform.anchoredPosition3D.x, rectTransform.anchoredPosition3D.y, 0);            
        }


        public void OnEndDrag(PointerEventData eventData)
        {
            canvasGroup.blocksRaycasts = true;

            if (ObjGameManager.GetComponent<GameManager>().IsArea)     {
                DropEvent.Raise();
                ChangeParent();
                //if (!_IsParentColumn)                
                //    ChangeParent();                
                //else if (_IsParentColumn)
                //    gameObject.transform.localPosition = LastPos;
            }
            else    {
                //FallEvent.Raise();                
                gameObject.transform.SetParent(InitialParentObj.transform);
                //_IsParentColumn = false;
                //gameObject.transform.localPosition = InitialPos;
                //gameObject.GetComponent<RectTransform>().DOAnchorPos(InitialPos, 0.2f);
                gameObject.transform.DOLocalMove(InitialPos, 0.2f);
                FallEvent.Raise();
            }
        }


        public void ChangeParent()
        {
            List<GameObject> objects = ObjGameManager.GetComponent<GameManager>().NumberColumns;
            for (int i = 0; i < objects.Count; i++)
            {
                string str = objects[i].GetComponent<ColumnScript>().CurrentTypeNumber.ToString();
                if (str == CurrentTypeNumber.ToString())                {
                    NewParent(objects[i]);
                    break;
                }
            }
            
        }


        void NewParent(GameObject obj)
        {
            //////_IsParentColumn = true;
            gameObject.transform.SetParent(obj.transform.GetChild(1).gameObject.transform);
        }


        public void ReturnInitialPos()
        {
            //_IsParentColumn = false;
            gameObject.transform.SetParent(InitialParentObj.transform);

            gameObject.transform.DOLocalMove(InitialPos, 0.2f);

            //gameObject.GetComponent<RectTransform>().DOAnchorPos(InitialPos, 0.2f);            
        }


        



    }
}



//float flo1 = Vector3.Distance(gameObject.transform.localPosition, InitialPos);


//public void TypeOfTakePosition()
//{
//    Debug.Log(gameObject.transform.position  + "  gameObject.transform.position " );
//    Debug.Log(gameObject.transform.localPosition + "  gameObject.transform.localPosition " );

//    Debug.Log(gameObject.GetComponent<RectTransform>().position + "  gameObject.GetComponent<RectTransform>().position " );
//    Debug.Log(gameObject.GetComponent<RectTransform>().transform.position + "  gameObject.GetComponent<RectTransform>().transform.position");

//    Debug.Log(gameObject.GetComponent<RectTransform>().localPosition + "  gameObject.GetComponent<RectTransform>().localPosition");
//    Debug.Log(gameObject.GetComponent<RectTransform>().transform.localPosition + "  gameObject.GetComponent<RectTransform>().transform.localPosition" );

//    Debug.Log(gameObject.GetComponent<RectTransform>().rect + "  gameObject.GetComponent<RectTransform>().rect");
//    Debug.Log(gameObject.GetComponent<RectTransform>().rect.position + "  gameObject.GetComponent<RectTransform>().rect.position");

//    Debug.Log(gameObject.GetComponent<RectTransform>().anchoredPosition + "  gameObject.GetComponent<RectTransform>().anchoredPosition" );

//    Debug.Log(gameObject.GetComponent<Transform>().position + "  gameObject.GetComponent<Transform>().position ");
//    Debug.Log(gameObject.GetComponent<Transform>().transform.position + "  gameObject.GetComponent<Transform>().transform.position ");

//    Debug.Log(gameObject.GetComponent<Transform>().localPosition + "  gameObject.GetComponent<Transform>().localPosition");
//    Debug.Log(gameObject.GetComponent<Transform>().transform.localPosition + "  gameObject.GetComponent<Transform>().transform.localPosition" );
//}