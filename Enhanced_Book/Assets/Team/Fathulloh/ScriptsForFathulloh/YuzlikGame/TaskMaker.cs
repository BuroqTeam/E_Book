using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace YuzlikFathulloh
{
    public class TaskMaker : MonoBehaviour
    {
        public GameObject TaskObj;
        public TMP_Text QuestionText;
        private string QuestionStr = "Sonlar yordamida *n sonini hosil qiling.";
        public int CurrentTask;


        void Start()
        {
            MakeQuestion();
        }

        
        public void MakeQuestion()
        {
            CurrentTask = Random.Range(100000, 1000000);
            QuestionStr = QuestionStr.Replace("*n", CurrentTask.ToString());
            TaskObj.GetComponent<TMP_Text>().text = QuestionStr.ToString();

        }


    }
}
