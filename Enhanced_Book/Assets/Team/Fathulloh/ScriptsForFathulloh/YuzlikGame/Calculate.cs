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


            if (CorrectColumns == Gmanager.XonalarSoni)
            {
                Debug.Log(" + ");
                NextTaskEvent.Invoke();                
            }
            else
            {
                Debug.Log(" - ");
                WrongEvent.Invoke();                
            }
                

        }



    }
}
