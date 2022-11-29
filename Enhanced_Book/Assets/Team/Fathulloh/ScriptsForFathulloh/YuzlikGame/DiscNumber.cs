using UnityEngine;
using UnityEngine.EventSystems;

namespace YuzlikFathulloh
{
    public class DiscNumber : MonoBehaviour, /*IPointerDownHandler,*/ IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public enum TypeNumber { Ones, Tens, Hundreds, Thousands, TenThousands, HundredThousands }
        public TypeNumber CurrentTypeNumber;

        public Vector3 _initialPos, _lastPos;

        private RectTransform _rectTransform;
        bool _IsTrue = true;


        void Start()
        {
            TakePositions();
        }


        void TakePositions()
        {
            _rectTransform = GetComponent<RectTransform>();

            if (_IsTrue)            {
                _IsTrue = false;
                _initialPos = gameObject.transform.position;
            }

        }

        

        public void OnBeginDrag(PointerEventData eventData)
        {
            _lastPos = gameObject.transform.position;

        }


        public void OnDrag(PointerEventData eventData)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(pos.x, pos.y, 0);
            _rectTransform.anchoredPosition3D = new Vector3(_rectTransform.anchoredPosition3D.x, _rectTransform.anchoredPosition3D.y, 0);

            //_rectTransform.anchoredPosition += eventData.delta;
        }



        public void OnEndDrag(PointerEventData eventData)
        {
            
        }

        //public void OnPointerDown(PointerEventData eventData)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
