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
        public List<GameObject> InitialDots;
        public GameObject BoardObj;
        public Vector3 InitialPos, CurrentPos;
        public List<GameObject> ListHooks;

        public int HookNumbers = 0;


        void Start()
        {
            TakeList();
        }


        void TakeList()
        {
            ListHooks = BoardObj.GetComponent<Board>().Hooks;
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
            CheckOnHook();
        }


        void CheckOnHook()
        {
            for (int i = 0; i < ListHooks.Count; i++)
            {
                if ((Vector3.Distance(transform.position, ListHooks[i].transform.position) < 0.35f))
                {
                    CurrentPos = ListHooks[i].transform.position;
                    HookNumbers++;
                }
            }

            if (HookNumbers >= 1)       {
                HookNumbers = 0;
                transform.position = CurrentPos;
            }
            else if (HookNumbers == 0)         {
                transform.position = CurrentPos;
            }

            gameObject.transform.parent.GetComponent<GeoFigure>().CheckFigure();

            
        }





    }
}
