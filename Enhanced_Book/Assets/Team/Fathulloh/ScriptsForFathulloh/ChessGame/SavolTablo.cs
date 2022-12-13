using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ChessGameFathulloh
{
    public class SavolTablo : MonoBehaviour
    {
        public GameManager Gmanager;

        public const int TotalTaskCount = 8;
        private int CurrentTaskIndex = 0;

        public int BoardSize;
        public int ChessLevel;
        public string Harflar;

        public TMP_Text SavolBoardText;
        public TMP_Text TaskCountText;


        public int sonSavol;
        public int harfIndex;
        public char harfSavol;

        //public GameObject fingerCursor;



        void Start()
        {
            CheckBorderTask();
        }


        public void CheckBorderTask()
        {
            //switch (ChessLevel)
            //{
            //    case 1:
            //        BoardSize = 4;
            //        Harflar = "ABCD";
            //        break;
            //    case 2:
            //        BoardSize = 5;
            //        Harflar = "ABCDE";
            //        break;
            //    case 3:
            //        BoardSize = 6;
            //        Harflar = "ABCDEF";
            //        break;
            //    default:
            //        break;
            //}

            BoardSize = 8;
            Harflar = "ABCDEFGH";

            TaskMaker();
        }


        

        public void TaskMaker()
        {
            CurrentTaskIndex += 1;
            harfIndex = Random.Range(0, BoardSize);
            harfSavol = Harflar[harfIndex];
            sonSavol = Random.Range(1, BoardSize + 1);

            //Debug.Log("harfSavol = " + harfSavol + " sonSavol = " + sonSavol);
            SavolBoardText.text = harfSavol.ToString() + sonSavol.ToString();
            TaskCountText.text = CurrentTaskIndex.ToString() + "/" + TotalTaskCount.ToString();            
        }


        public void CheckFinishing()
        {
            StartCoroutine(CallFinishEvent());
        }

        public IEnumerator CallFinishEvent()
        {
            yield return new WaitForSeconds(0.8f);

            if (CurrentTaskIndex != TotalTaskCount)
            {
                StartCoroutine(Gmanager.MoveChessBoard());
                yield return new WaitForSeconds(0.2f);
                TaskMaker();
            }
            else if (CurrentTaskIndex == TotalTaskCount)
            {
                yield return new WaitForSeconds(0.5f);
                Gmanager.finishEvent.Invoke();
            }
        }



    }
}
