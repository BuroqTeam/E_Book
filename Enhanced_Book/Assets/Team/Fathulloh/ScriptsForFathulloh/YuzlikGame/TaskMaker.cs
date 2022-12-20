using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace YuzlikFathulloh
{
    public class TaskMaker : MonoBehaviour
    {
        public int HowManyQuestion = 10;
        public int CurrentQuestionIndex = 0;

        public GameObject QuestionTablo;
        public GameObject TaskObj;

        public TMP_Text QuestionText;
        private string QuestionStr = "Sonlar yordamida *n sonini hosil qiling.";
        public int CurrentTask;


        public UnityEvent FinishEvent;


        void Start()
        {
            MakeQuestion();
        }

        
        public void MakeQuestion()
        {
            if (HowManyQuestion > CurrentQuestionIndex)   {
                //Debug.Log(" HowManyQuestion = " + HowManyQuestion + " > CurrentQuestionIndex = " + CurrentQuestionIndex);
                IncreaseIndex();
                CurrentTask = Random.Range(100000, 1000000);
                string str0 = (CurrentTask / 1000).ToString() + " " + ((CurrentTask.ToString()).Substring(3));
                
                string QuestionStr1 = QuestionStr.Replace("*n", str0.ToString());
                TaskObj.GetComponent<TMP_Text>().text = QuestionStr1.ToString();
                ShowQuestionIndex();
            }
            else if (HowManyQuestion == CurrentQuestionIndex)    {
                //Debug.Log(" HowManyQuestion = " + HowManyQuestion + "  ==  CurrentQuestionIndex = " + CurrentQuestionIndex);
                ShowQuestionIndex();
                //StartCoroutine(Finishing());
                FinishEvent.Invoke();
            }                        
        }


        public void ShowQuestionIndex()
        {            
            string str = CurrentQuestionIndex.ToString() + " / " + HowManyQuestion.ToString();
            QuestionTablo.transform.GetChild(0).GetComponent<TMP_Text>().text = str;
        }


        public void IncreaseIndex()
        {
            //Debug.Log("Increase Index");
            CurrentQuestionIndex += 1;
        }


        public void TimeEnd()
        {
            FinishEvent.Invoke();
        }

        IEnumerator Finishing()
        {
            yield return new WaitForSeconds(0.1f);
            FinishEvent.Invoke();
        }

    }
}
