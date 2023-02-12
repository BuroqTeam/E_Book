using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TableReward
{
    public class TableManager : MonoBehaviour
    {
        public List<GameObject> TableObjects;

        public List<GameObject> DropDownObjects;

        public List<Sprite> TableSprites;

        public List<GameObject> ButtonObjects;

        Color colorOn = new Color(0.196f, 0.196f, 0.196f);
        Color colorOff = new Color(0.627f, 0.643f, 0.658f);

        void Start()
        {
            //for (int i = 0; i < TableObjects.Count; i++)
            //{
            //    int num = TableObjects[i].transform.GetSiblingIndex();
            //    Debug.Log("Name: " + TableObjects[i].name + " index = " + num);
            //}
        }


        public void ChangeTableSprite(int num)
        {
            if (num == 1)
            {
                gameObject.GetComponent<Image>().sprite = TableSprites[0];
            }
            else if (num == 2)
            {
                gameObject.GetComponent<Image>().sprite = TableSprites[1];
            }
            else if (num == 3)
            {
                gameObject.GetComponent<Image>().sprite = TableSprites[2];
            }
        }


        public void NextTable(GameObject gObj)
        {
            Debug.Log("Ishladi.");

            string str = gObj.GetComponent<CreateTable>().CurrentTable.ToString();

            if (str == "GameTable")
                ChangeTable(TableObjects[0], TableSprites[0], DropDownObjects[0], ButtonObjects[0]);
            else if (str == "TaskTable")
                ChangeTable(TableObjects[1], TableSprites[1], DropDownObjects[1], ButtonObjects[1]);
            else if (str == "ExamTable")
                ChangeTable(TableObjects[2], TableSprites[2], DropDownObjects[2], ButtonObjects[2]);

        }


        void ChangeTable(GameObject tableObj, Sprite sprt, GameObject dropdownObj, GameObject buttonObj)
        {
            gameObject.GetComponent<Image>().sprite = sprt;

            for (int i = 0; i < DropDownObjects.Count; i++)
            {
                DropDownObjects[i].SetActive(false);
                ButtonObjects[i].transform.GetChild(0).GetComponent<TMP_Text>().color = colorOff;
            }

            dropdownObj.SetActive(true);
            buttonObj.transform.GetChild(0).GetComponent<TMP_Text>().color = colorOn;

            int countTables = TableObjects.Count;
            tableObj.transform.SetSiblingIndex(countTables - 1);
        }


        public void Test(GameObject gObj)
        {
            Debug.Log("GameObject name = " + gameObject.name);
        }


    }
}
