using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace FathullohExample
{
    public class BookContent : MonoBehaviour
    {
        public GameObject ParentObject;
        public GameObject ChapterPrefab;
        public GameObject TopicPrefab;
        public GameObject PinkLinePrefab;

        public string[][] Mavzular = new string[][]
        { new string[]{ "I Bob", "1. Natural sonlar va nol", "2. Sodda geometrik shakllar", "3. Shkalalar va sonlar nuri",
            "4. Natural sonlarni taqqoslash. Katta va kichik", "5. Natural sonlarni yaxlitlash", "6. Natural sonlarni qo‘shish", 
            "7. Natural sonlarni yaxlitlash" },
        new string[]{ "II Bob", "1. Natural sonlarni ko‘paytirish", "2. Natural sonlarni bo‘lish", "3. Qoldiqli bo‘lish" },
        new string[]{ "III Bob", "1. Matnli masalalar", "2. Harakatga doir masalalar", "3. Ikki jism harakatiga doir masalalar", "4. Iqtisodiy mazmundagi masalalar" },
        new string[]{ "IV Bob", "1. Burchaklar", "2. Paralel va perpendikular to‘g‘ri chiziqlar", "3. Kordinatalar burchagi", "4. Ko‘pburchak", "5. To‘g‘ri to‘rtburchak va kvadratning yuzi" }};


        public List<GameObject> Chapters, Topics;


        void Start()
        {
            WorkingWithArray();
        }


        void WorkingWithArray()
        {            

            for (int i = 0; i < Mavzular.Length; i++)
            {
                for (int j = 0; j < Mavzular[i].Length; j++)
                {                    
                    if (j == 0)   {
                        GameObject newChapter = Instantiate(ChapterPrefab, this.transform);
                        newChapter.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = Mavzular[i][j];
                        newChapter.transform.SetParent(ParentObject.transform);

                        Chapters.Add(newChapter);
                    }
                    else {
                        GameObject newTopic = Instantiate(TopicPrefab, this.transform);
                        newTopic.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = Mavzular[i][j];
                        newTopic.transform.SetParent(ParentObject.transform);
                        newTopic.GetComponent<TopicElement>().ChapterObj = Chapters[i];
                        Chapters[i].GetComponent<ChapterElement>().Topics.Add(newTopic);
                        Chapters[i].GetComponent<ChapterElement>().MainPanel = gameObject;

                        Topics.Add(newTopic);
                    }                    
                }
                GameObject newLine = Instantiate(PinkLinePrefab, ParentObject.transform);
                newLine.transform.SetParent(newLine.transform);
            }
        }


        public void CloseAllChapters(Vector3 currentPos)
        {
            for (int i = 0; i < Chapters.Count; i++)
            {
                Chapters[i].GetComponent<ChapterElement>().TurnOffChapter(currentPos);
            }
        }


    }
}



//[Serializable]
//public class Math5Chapter
//{
//    public List<Math5Topic> Topics;
//}


//[Serializable]
//public class Math5Topic
//{
//    public string TopicName;
//}


