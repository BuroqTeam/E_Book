using ActionManager;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;


namespace Matching
{
    public class QuestionGenerator : MonoBehaviour
    {
       
        public GameObject particle;
        public List<GameObject> collection;
        public float waitingPeriod;

        public List<string> textCollection;
        public List<Sprite> imageCollection;
        Dictionary<string, Sprite> collectionDict = new Dictionary<string, Sprite>();
        Dictionary<string, Sprite> randomCollectionDict = new Dictionary<string, Sprite>();
        public List<GameObject> enableObjectsGroup = new List<GameObject>();

        public GameEventSO correctEvent;
        public GameEventSO finishEvent;
        //public UnityEvent finishEvent;
        int correctCounter;

        public List<string> Grams;
        public List<string> Kilograms;
        public List<string> MainList;

        private void Awake()
        {
            collection = Actions.ChildrenOfGameobject(gameObject);
            MakeRandomDict();
            
        }

        private void Start()
        {
            ProvideData();
        }

        void MakeRandomDict()
        {
            for (int i = 0; i < textCollection.Count; i++)
            {
                collectionDict.Add(textCollection[i], imageCollection[i]);
            }
            for (int i = 0; i < textCollection.Count; i++)
            {
                int random = Random.Range(0, collectionDict.Count);
                randomCollectionDict.Add(collectionDict.ElementAt(random).Key, collectionDict.ElementAt(random).Value);
                collectionDict.Remove(collectionDict.ElementAt(random).Key);
            }


            for (int i = 0; i < Grams.Count; i++)
            {
                MainList.Add(Grams[i]);
                MainList.Add(Kilograms[i]);
            }
            for (int i = 0; i < Kilograms.Count; i++)            {
                //MainList.Add(Kilograms[i]);
            }
        }

        void ProvideData()
        {
            collection = Actions.ShuffleList(collection);

            //int n = 0;
            //for (int i = 0; i < collection.Count / 2; i++)
            //{
            //    collection[i].GetComponent<Square>().image.sprite = randomCollectionDict.ElementAt(n).Value;
            //    n++;
            //}
            //n = 0;
            //for (int i = collection.Count / 2; i < collection.Count; i++)
            //{
            //    collection[i].GetComponent<Square>().text.text = randomCollectionDict.ElementAt(n).Key;
            //    n++;
            //}

            for (int i = 0; i < MainList.Count; i++)
            {
                collection[i].GetComponent<Square>().text.text = MainList[i];
            }

        }


        public void EnableTwoObjects(GameObject obj, ref bool isCorrect)
        {
            enableObjectsGroup.Add(obj);
           
            if (enableObjectsGroup.Count > 2)
            {
                enableObjectsGroup[0].GetComponent<Square>().InitialCondition();
                enableObjectsGroup.RemoveAt(0);
            }

            if (enableObjectsGroup.Count.Equals(2))
            {                
                string text1 = enableObjectsGroup[0].GetComponent<Square>().text.text;
                string text2 = enableObjectsGroup[1].GetComponent<Square>().text.text;

                //Debug.Log("text1 = " + text1 + "text1 = " + text1);

                text1 = Regex.Replace(text1, "([a-zA-Z,_ ]+|(?<=[a-zA-Z ])[/-])", "");
                text2 = Regex.Replace(text2, "([a-zA-Z,_ ]+|(?<=[a-zA-Z ])[/-])", "");

                //Debug.Log("text1 = " + text1 + "text1 = " + text2);

                if (text1 == text2)                
                    isCorrect = true;                
                else if (text1 != text2)                
                    isCorrect = false;                

                //if (enableObjectsGroup[0].GetComponent<Square>().image.sprite != null)
                //{
                //    string img1 = enableObjectsGroup[0].GetComponent<Square>().image.sprite.name;
                //    if (img1.Equals(text2))                                           
                //        isCorrect = true;                    
                //    else                    
                //        isCorrect = false;                    
                //}
                //else if (enableObjectsGroup[1].GetComponent<Square>().image.sprite != null)
                //{
                //    string img2 = enableObjectsGroup[1].GetComponent<Square>().image.sprite.name;
                //    if (img2.Equals(text1))                                              
                //        isCorrect = true;  
                //    else                    
                //        isCorrect = false;
                //}
            }

        }


        
        public void TurnOffCollection(bool colliderEnableValue, GameObject exceptionObj)
        {
            foreach (GameObject obj in collection)
            {
                if (exceptionObj != obj)
                {
                    obj.GetComponent<BoxCollider2D>().enabled = colliderEnableValue;
                }                
            }

            foreach (GameObject obj in enableObjectsGroup)
            {
                obj.GetComponent<BoxCollider2D>().enabled = false;
            }
        }


        public void CorrectAction()
        {
            correctCounter++;
            correctEvent.Raise();
            foreach (GameObject obj in enableObjectsGroup)
            {
                Instantiate(particle, obj.transform.position, Quaternion.identity);
                collection.Remove(obj);
                Destroy(obj);
            }
            enableObjectsGroup.Clear();
            if (correctCounter.Equals(8))
            {
                StartCoroutine(FinishAction());
            }
        }


        IEnumerator FinishAction()
        {
            yield return new WaitForSeconds(0.5f);
            finishEvent.Raise();
        }

       

    }

}

