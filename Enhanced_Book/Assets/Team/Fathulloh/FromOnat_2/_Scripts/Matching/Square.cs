using ActionManager;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Matching
{
    public class Square : MonoBehaviour, IPointerClickHandler, IBeginDragHandler
    {
        public QuestionGenerator questionGenerator;

        public Sprite front;
        public Sprite back;
       
        public Vector3 initialPos;
        public Vector3 initialScale;

        
        public TMP_Text text;
        public SpriteRenderer image;
        public float period;

        public GameEventSO clickEvent;
        
        

        private void Awake()
        {
            text = transform.GetChild(0).GetComponent<TMP_Text>();
            image = transform.GetChild(1).GetComponent<SpriteRenderer>();
            initialPos = transform.position;
            initialScale = transform.localScale;
        }



        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("Begin Drag");
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //Debug.Log("OnPointerClick");
            //StartCoroutine(Flip());
            StartCoroutine(Flip2());
        }


        IEnumerator Flip2()
        {
            clickEvent.Raise();
            bool val = false;
            questionGenerator.EnableTwoObjects(gameObject, ref val);
            //StartCoroutine(Actions.RotateOverSecondsInYAxis(gameObject, 90, period));
            GetComponent<BoxCollider2D>().enabled = false;
            questionGenerator.TurnOffCollection(false, gameObject);
            ChangeColor();
            yield return new WaitForSeconds(period - 0.05f);
            //ChangeTextColor();
            GetComponent<SpriteRenderer>().sortingOrder = 2;
            transform.GetChild(0).GetComponent<MeshRenderer>().sortingOrder = 2;
            transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = 3;

            //GetComponent<SpriteRenderer>().sprite = ChangeSprite();
            //StartCoroutine(Actions.RotateOverSecondsInYAxis(gameObject, 0, period));
            //StartCoroutine(Actions.ScaleOverSeconds(gameObject, new Vector3(1, 1, 0), period));
            //StartCoroutine(Actions.MoveOverSeconds(gameObject, new Vector3(0, 0, 0), period));
            //yield return new WaitForSeconds(1);
            //StartCoroutine(Actions.ScaleOverSeconds(gameObject, initialScale, period));
            //StartCoroutine(Actions.MoveOverSeconds(gameObject, initialPos, period));
            //yield return new WaitForSeconds(period); //F++
            GetComponent<SpriteRenderer>().sortingOrder = 0;
            transform.GetChild(0).GetComponent<MeshRenderer>().sortingOrder = 0;
            transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = 1;
            questionGenerator.TurnOffCollection(true, gameObject);

            if (val)            
                questionGenerator.CorrectAction();            
        }


        IEnumerator Flip()
        {
            clickEvent.Raise();
            bool val = false;
            questionGenerator.EnableTwoObjects(gameObject, ref val);
            StartCoroutine(Actions.RotateOverSecondsInYAxis(gameObject, 90, period));
            GetComponent<BoxCollider2D>().enabled = false;
            questionGenerator.TurnOffCollection(false, gameObject);
            yield return new WaitForSeconds(period);
            ChangeTextColor();
            GetComponent<SpriteRenderer>().sortingOrder = 2;
            transform.GetChild(0).GetComponent<MeshRenderer>().sortingOrder = 2;
            transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = 3;

            GetComponent<SpriteRenderer>().sprite = ChangeSprite();
            StartCoroutine(Actions.RotateOverSecondsInYAxis(gameObject, 0, period));
            StartCoroutine(Actions.ScaleOverSeconds(gameObject, new Vector3(1, 1, 0), period));
            StartCoroutine(Actions.MoveOverSeconds(gameObject, new Vector3(0, 0, 0), period));
            yield return new WaitForSeconds(1);
            StartCoroutine(Actions.ScaleOverSeconds(gameObject, initialScale, period));
            StartCoroutine(Actions.MoveOverSeconds(gameObject, initialPos, period));
            yield return new WaitForSeconds(period);
            GetComponent<SpriteRenderer>().sortingOrder = 0;
            transform.GetChild(0).GetComponent<MeshRenderer>().sortingOrder = 0;
            transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = 1;
            questionGenerator.TurnOffCollection(true, gameObject);

            if (val)        {                
                questionGenerator.CorrectAction();
            }
        }


        Sprite ChangeSprite()
        {
            if (GetComponent<SpriteRenderer>().sprite.Equals(back))
            {
                return front;
            }
            else
            {
                return back;
            }
        }


        void ChangeTextColor()
        {
            
            Color col = text.color;
            if (text.text != "")
            {                
                if (col.a == 0)                {
                    col.a = 255;
                    text.color = col;
                }
                else if(col.a == 255)          {
                    col.a = 0;
                    text.color = col;
                }
            }
        }


        public void InitialCondition()
        {
            //StartCoroutine(FlipBack());
            StartCoroutine(FlipBack2());

        }

        IEnumerator FlipBack()
        {           
            StartCoroutine(Actions.RotateOverSecondsInYAxis(gameObject, 90, period));
            GetComponent<BoxCollider2D>().enabled = false;            
            yield return new WaitForSeconds(period);
            ChangeTextColor();
            //GetComponent<SpriteRenderer>().sortingOrder = 1;
            transform.GetChild(0).GetComponent<MeshRenderer>().sortingOrder = 0;
            transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = -1;

            GetComponent<SpriteRenderer>().sprite = ChangeSprite();
            StartCoroutine(Actions.RotateOverSecondsInYAxis(gameObject, 0, period));
            //StartCoroutine(Actions.ScaleOverSeconds(gameObject, new Vector3(1, 1, 0), period));
            //StartCoroutine(Actions.MoveOverSeconds(gameObject, new Vector3(0, 0, 0), period));
            //yield return new WaitForSeconds(2);
            //StartCoroutine(Actions.ScaleOverSeconds(gameObject, initialScale, period));
            //StartCoroutine(Actions.MoveOverSeconds(gameObject, initialPos, period));
            yield return new WaitForSeconds(period);
            GetComponent<SpriteRenderer>().sortingOrder = 0;
            //transform.GetChild(0).GetComponent<MeshRenderer>().sortingOrder = 0;
            //transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = 1;
            //questionGenerator.TurnOffCollection(true, gameObject);
            GetComponent<BoxCollider2D>().enabled = true;
        }


        IEnumerator FlipBack2()
        {
            //StartCoroutine(Actions.RotateOverSecondsInYAxis(gameObject, 90, period));
            GetComponent<BoxCollider2D>().enabled = false;
            ChangeColor();
            yield return new WaitForSeconds(period);
            //ChangeTextColor();
            
            transform.GetChild(0).GetComponent<MeshRenderer>().sortingOrder = 0;
            transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = -1;

            //GetComponent<SpriteRenderer>().sprite = ChangeSprite();
            StartCoroutine(Actions.RotateOverSecondsInYAxis(gameObject, 0, period));
            
            yield return new WaitForSeconds(period);
            GetComponent<SpriteRenderer>().sortingOrder = 0;
            
            GetComponent<BoxCollider2D>().enabled = true;
        }


        bool _IsClicked = false;
        public Color newColor;

        public void ChangeColor()
        {
            if (!_IsClicked)            {
                gameObject.GetComponent<SpriteRenderer>().color = newColor;
                _IsClicked = true;
            }                            
            else if (_IsClicked)            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                _IsClicked = false;
            }            
        }


    }

}

