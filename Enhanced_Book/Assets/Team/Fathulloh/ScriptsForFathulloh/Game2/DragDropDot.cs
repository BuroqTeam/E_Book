using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game2_Fathulloh
{
    /// <summary>
    /// LineRenderer dagi nuqtalarni drag and drop qilish uchun ishlatiladigan script.
    /// </summary>
    public class DragDropDot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        private RectTransform rectTransform;

        public Vector3 InitialPos;


        void Start()
        {

        }


        public void OnBeginDrag(PointerEventData eventData)
        {
            InitialPos = transform.position;

        }


        public void OnDrag(PointerEventData eventData)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(pos.x, pos.y, 0);
        }


        public void OnEndDrag(PointerEventData eventData)
        {
            
        }

        
        





    }
}
