using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ChessGameFathulloh
{
    public class ChessKatak : MonoBehaviour, IPointerClickHandler
    {        
        public SavolTablo Savoltablo;
        public GameManager GManager;

        public Sprite oqSprite, qoraSprite;
        public int squareIndex;
        //public int level;
        public Color initialColor;
        public Vector3 initialScale;
        public int initialOrderInLayer;

        public Color yangiRang = new(0.8f, 0.3f, 0.3f, 1);

        public int harfRaqam;


        void Start()
        {
            initialColor = GetComponent<SpriteRenderer>().color;
            initialScale = transform.localScale;
            initialOrderInLayer = GetComponent<SpriteRenderer>().sortingOrder;
            qoraSprite = GetComponent<SpriteRenderer>().sprite;
        }



        public void OnPointerClick(PointerEventData eventData)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 7;
            CheckClickedAnswer();
        }

        

        public void CheckClickedAnswer()
        {
            int sonSavol = Savoltablo.sonSavol;
            int boardSize = Savoltablo.BoardSize;
            char harfSavol = Savoltablo.harfSavol;

            switch (harfSavol)
            {
                case 'A':
                    harfRaqam = 1;
                    break;
                case 'B':
                    harfRaqam = 2;
                    break;
                case 'C':
                    harfRaqam = 3;
                    break;
                case 'D':
                    harfRaqam = 4;
                    break;
                case 'E':
                    harfRaqam = 5;
                    break;
                case 'F':
                    harfRaqam = 6;
                    break;
                case 'G':
                    harfRaqam = 7;
                    break;
                case 'H':
                    harfRaqam = 8;
                    break;
                default:
                    break;
            }


            if (((harfRaqam - 1) * boardSize + sonSavol - 1) == squareIndex)            {
                StartCoroutine(Painting());
                GManager.correctEvent.Invoke();
            }
            if (((harfRaqam - 1) * boardSize + sonSavol - 1) != squareIndex)            {
                StartCoroutine(ErrorPainting());
                GManager.errorEvent.Invoke();
            }

        }



        public IEnumerator Painting()
        {
            GetComponent<SpriteRenderer>().sprite = oqSprite;
            GetComponent<Transform>().DOScale(initialScale * 1.5f, 0.3f);
            GetComponent<SpriteRenderer>().color = Color.green;
            yield return new WaitForSeconds(0.3f);

            GetComponent<Transform>().DOScale(initialScale, 0.3f);
            yield return new WaitForSeconds(0.8f);
            GetComponent<SpriteRenderer>().sprite = qoraSprite;
            GetComponent<SpriteRenderer>().color = initialColor;
            GetComponent<SpriteRenderer>().sortingOrder = initialOrderInLayer;
        }


        public IEnumerator ErrorPainting()
        {
            GetComponent<SpriteRenderer>().sprite = oqSprite;
            GetComponent<SpriteRenderer>().color = yangiRang;
            yield return new WaitForSeconds(0.3f);
            GetComponent<SpriteRenderer>().sprite = qoraSprite;
            GetComponent<SpriteRenderer>().color = initialColor;
            GetComponent<SpriteRenderer>().sortingOrder = initialOrderInLayer;

        }




    }
}
