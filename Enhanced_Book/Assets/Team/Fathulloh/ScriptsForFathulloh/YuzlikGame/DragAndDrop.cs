using UnityEngine;
using UnityEngine.EventSystems;

namespace YuzlikFathulloh
{
    public class DragAndDrop : MonoBehaviour, /*IPointerDownHandler,*/ IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public enum TypeNumber { Ones, Tens, Hundreds, Thousands, TenThousands, HundredThousands }
        public TypeNumber CurrentTypeNumber;

        public Vector3 InitialPos, LastPos;

        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        bool _IsTrue = true;


        void Start()
        {
            TakePositions();
        }


        void TakePositions()
        {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            if (_IsTrue)            {
                _IsTrue = false;
                InitialPos = gameObject.transform.position;
            }

        }

        

        public void OnBeginDrag(PointerEventData eventData)
        {
            LastPos = gameObject.transform.position;

            canvasGroup.blocksRaycasts = false;
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
        }


        //public void OnPointerDown(PointerEventData eventData)
        //{
        //    throw new System.NotImplementedException();
        //}


    }
}
