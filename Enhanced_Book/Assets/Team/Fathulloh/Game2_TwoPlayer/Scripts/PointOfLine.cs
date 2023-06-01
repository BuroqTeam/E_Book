using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game2_TwoPlayer
{
    /// <summary>
    /// LineRenderer dagi nuqtalarni drag and drop qilish uchun ishlatiladigan script.
    /// </summary>
    public class PointOfLine : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public GameObject BoardObj;
        public Vector3 InitialPos, CurrentPos;
        public List<GameObject> ListHooks;

        /*public*/ int nearHookNums = 0;
        public GameEventSO DragEvent, DropEvent, FallEvent;
        public Sprite GreenSprite, RedSprite;
        private Sprite InitialSprite;

        int numGreen = 0;  // Point birorta hookga yaqin kelgan bo‘lsa 1 dan katta bo‘ladi bu.


        void Start()
        {
            TakeList();
        }

        
        void TakeList()
        {
            ListHooks = BoardObj.GetComponent<GeoBoard>().Hooks;
            
            InitialSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        }


        public void OnBeginDrag(PointerEventData eventData)
        {
            InitialPos = transform.position;
            DragEvent.Raise();
        }       


        public void OnDrag(PointerEventData eventData)
        {            
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(pos.x, pos.y, 0);
            SpriteChanger();
        }

        
        void SpriteChanger()
        {
            for (int i = 0; i < ListHooks.Count; i++)
            {
                if (Vector3.Distance(transform.position, ListHooks[i].transform.position) < 0.35f)                
                    numGreen += 1;                   
            }

            if (numGreen > 0)
            {                
                gameObject.GetComponent<SpriteRenderer>().sprite = GreenSprite;
            }
            else if (numGreen == 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = RedSprite;
            }

            numGreen = 0;
        }


        public void OnEndDrag(PointerEventData eventData)
        {            
            CheckOnHook();            
        }
        
        
        /// <summary>
        /// Biror nuqtaga yaqin yoki yo‘qligi tekshiriladi.
        /// </summary>
        void CheckOnHook()
        {
            for (int i = 0; i < ListHooks.Count; i++)
            {
                if (Vector3.Distance(transform.position, ListHooks[i].transform.position) < 0.25f)
                {
                    nearHookNums++;
                    CurrentPos = ListHooks[i].transform.position;
                }
            }

            if (nearHookNums >= 1) 
            {
                nearHookNums = 0;
                transform.position = CurrentPos;
                DropEvent.Raise();                
            }
            else if (nearHookNums == 0)
            {
                transform.position = InitialPos;
                FallEvent.Raise();
            }

            gameObject.GetComponent<SpriteRenderer>().sprite = InitialSprite;
            gameObject.transform.parent.GetComponent<GeoFigure>().CheckFigure();
        }


    }
}
