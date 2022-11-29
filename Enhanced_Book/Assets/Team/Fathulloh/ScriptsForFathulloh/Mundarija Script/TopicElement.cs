using UnityEngine;


namespace FathullohExample
{
    public class TopicElement : MonoBehaviour
    {
        public GameObject ChapterObj;


        void Start()
        {

        }

        

        public void WhenOnClicked()
        {
            ChapterObj.GetComponent<ChapterElement>().TopicsOff();

            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }


        public void WhenOffClicked()
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }





    }
}
