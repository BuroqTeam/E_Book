using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace YuzlikFathulloh
{
    /// <summary>
    /// Javobni tekshirish va keyingi savolni tuzib beruvchi metodlar chaqiriladigan script.
    /// </summary>
    public class Calculate : MonoBehaviour
    {

        public GameManager Gmanager;
        public TaskMaker Tmaker;
        public int CurrentTaskNum;
        public List<int> Digits;
        public int number;
        //public List<bool> CoulmnStatus;
        public int CorrectColumns;

        public float WaitTime = 0.75f;
        public float MaxScaleSize = 1;

        public UnityEvent NextTaskEvent;
        public UnityEvent WrongEvent;


        void Start()
        {

        }

        
        public void CheckAnswer()
        {
            Digits.Clear();
            CorrectColumns = 0;

            CurrentTaskNum = Tmaker.CurrentTask;
            number = CurrentTaskNum;
            while (number >= 1)
            {
                if (number > 10)    {
                    Digits.Add(number % 10);
                    number /= 10;
                }
                else     {
                    Digits.Add(number);
                    number = 0;
                }                
            }


            for (int i = 0; i < Gmanager.NumberColumns.Count; i++)
            {
                int n1 = Gmanager.NumberColumns[i].transform.GetChild(1).transform.childCount;
                if (n1 == Digits[i])     {
                    CorrectColumns++;
                }
            }


            if (CorrectColumns == Gmanager.XonalarSoni)        {
                NextTaskEvent.Invoke();                
            }
            else            {
                WrongEvent.Invoke();                
            }      

        }


        public GameObject Xobject;
        public bool _IsTrueWrongAnim = true;


        public void WrongAnim()
        {
            if (_IsTrueWrongAnim)
            {
                _IsTrueWrongAnim = false;
                StartCoroutine(WrongAnimation());
            }    

        }


        IEnumerator WrongAnimation()
        {
            Vector3 initialScale = Xobject.transform.localScale;
            Xobject.SetActive(true);
            Xobject.transform.DOScale(MaxScaleSize, WaitTime);
            yield return new WaitForSeconds(WaitTime/5);
            Xobject.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 0), WaitTime);
            yield return new WaitForSeconds(WaitTime);

            Xobject.SetActive(false);
            Xobject.transform.DOScale(initialScale, 0);
            Xobject.GetComponent<SpriteRenderer>().DOColor(new Color(1, 1, 1, 1), 0);

            _IsTrueWrongAnim = true;
        }



    }
}
