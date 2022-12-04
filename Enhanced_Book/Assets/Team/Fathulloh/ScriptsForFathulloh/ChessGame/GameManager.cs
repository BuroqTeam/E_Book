using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ChessGameFathulloh
{
    public class GameManager : MonoBehaviour
    {
        public GameObject Parentobject;

        public GameObject SavolTablo;
        public Vector3 outPos = new Vector3(0, 80, 0);
        public Vector3 initialPos = new Vector3(0, -25, 0);

        public const int Level = 1;

        public float initialPosChessBoard;
        public Ease easeForBoard;


        public GameObject square4x4, square6x6, square8x8;
        public List<GameObject> squares;


        public GameObject chessBoard, chessBoardAlphabet;
        public Sprite oqSprite;
        public UnityEvent correctEvent, errorEvent, finishEvent;


        private void Awake()
        {
            //SavolTablo.GetComponent<RectTransform>().DOAnchorPosY(outPos.y, 0f); //++
            
            SavolTablo.GetComponent<SavolTablo>().ChessLevel = Level;
        }


        void Start()
        {
            //SwitchingBoxCollider(false);
            CheckLevel();
            //StartCoroutine(MoveChessBoard());
        }


        public void CheckLevel()
        {
            //if (Level == 1)    //4 ga 4
            //{
            //    chessBoardAlphabet = Instantiate(square4x4, new Vector3(0, -0.1f, 0), Quaternion.identity);
            //}
            //else if (Level == 2)        // 5 ga 5  
            //{
            //    chessBoardAlphabet = Instantiate(square6x6, new Vector3(0, -0.1f, 0), Quaternion.identity);
            //}
            //else if (Level == 3)        // 6 ga 6         
            //{
            //    chessBoardAlphabet = Instantiate(square8x8, new Vector3(0, -0.1f, 0), Quaternion.identity);
            //}
            chessBoard = chessBoardAlphabet.transform.GetChild(0).gameObject;


            initialPosChessBoard = chessBoardAlphabet.transform.position.y;     // ChessBoard animatsiyasi uchun ishlangan kod.
            //chessBoardAlphabet.transform.DOMoveY(-11, 0);

            TakeChilds();
        }


        void TakeChilds()
        {
            for (int i = 0; i < chessBoard.transform.childCount; i++)
            {
                chessBoard.transform.GetChild(i).GetComponent<ChessSquare>().Savoltablo = SavolTablo.GetComponent<SavolTablo>();
                chessBoard.transform.GetChild(i).GetComponent<ChessSquare>().squareIndex = i;
                chessBoard.transform.GetChild(i).GetComponent<ChessSquare>().GManager = this;
                chessBoard.transform.GetChild(i).GetComponent<ChessSquare>().oqSprite = oqSprite;
                squares.Add(chessBoard.transform.GetChild(i).gameObject);
            }
            //StartCoroutine(chessTablo.FingerAnim());
        }


        public void SwitchingBoxCollider(bool TF)
        {
            foreach (GameObject item in squares)
            {
                item.GetComponent<BoxCollider2D>().enabled = TF;
            }
        }



        int nl = 0;
        int bl = 0;

        public IEnumerator MoveChessBoard()
        {
            if (bl == 0) // ChessBoard animatsiyasi uchun ishlangan kod.
            {
                chessBoardAlphabet.transform
                    .DOMoveY(initialPosChessBoard, 0.8f)
                    .SetEase(easeForBoard);
                bl += 1;
            }

            if (nl != 0)
            {
                SwitchingBoxCollider(false);
                SavolTablo.GetComponent<RectTransform>().DOAnchorPosY(outPos.y, 0.5f);
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(0.1f);
            SavolTablo.GetComponent<RectTransform>().DOAnchorPosY(initialPos.y, 0.6f);
            yield return new WaitForSeconds(0.6f);
            SwitchingBoxCollider(true);

            nl += 1;
        }



        public void SetActivation()
        {
            chessBoardAlphabet.SetActive(false);
        }


    }
}
