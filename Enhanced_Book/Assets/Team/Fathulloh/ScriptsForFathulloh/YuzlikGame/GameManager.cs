using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace YuzlikFathulloh
{
    public class GameManager : MonoBehaviour
    {
        public int XonalarSoni = 6;
        public List<GameObject> NumberColumns;
        public List<string> XonalarNomi = new List<string> { "Birlik", "O‘nlik", "Yuzlik", "Minglik", "O‘n Minglik", "Yuz Minglik" };
        

        public List<Color> PrefabColors = new() { new(0.82f, 0.92f, 0.98f), new(0.99f, 0.90f, 0.83f),  new(0.97f, 0.86f, 0.90f), new(0.87f, 0.93f, 0.88f), new(0.69f, 0.56f, 0.75f), new(0.93f, 0.75f, 0.65f) };
        public List<Color> ChildColor = new() { new(0.35f, 0.72f, 0.87f), new(0.85f, 0.67f, 0.39f),  new(0.90f, 0.36f, 0.53f), new(0.24f, 0.67f, 0.24f), new(0.63f, 0.51f, 0.68f), new(0.81f, 0.65f, 0.57f) };
        public GameObject ColumnPrefab;
        public GameObject ParentObj;


        void Start()
        {
            CreateColumns();
        }


        public void CreateColumns()
        {
            for (int i = 0; i < XonalarSoni; i++)
            {
                GameObject newObj = Instantiate( ColumnPrefab, this.transform );
                newObj.GetComponent<Image>().color = PrefabColors[i];
                newObj.transform.GetChild(0).GetComponent<Image>().color = ChildColor[i];
                newObj.transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>().text = XonalarNomi[i];
                newObj.transform.SetParent(ParentObj.transform);
                NumberColumns.Add(newObj);
            }


        }


        void WriteNumberName()
        {
            for (int i = 0; i < XonalarNomi.Count; i++)
            {
                NumberColumns[i].transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>().text = XonalarNomi[i];
            }            
        }


        
    }
}



//public Dictionary<Color, Color> ColorColumns = new()
//{                    
//    { new(0.99f, 0.90f, 0.83f), new(0.85f, 0.67f, 0.39f) },
//    { new(0.82f, 0.92f, 0.98f), new(0.35f, 0.72f, 0.87f) },
//    { new(0.97f, 0.86f, 0.90f), new(0.90f, 0.36f, 0.53f) },
//    { new(0.87f, 0.93f, 0.88f), new(0.24f, 0.67f, 0.24f) },
//    { new(0.69f, 0.56f, 0.75f), new(0.63f, 0.51f, 0.68f) },
//    { new(0.93f, 0.75f, 0.65f), new(0.81f, 0.65f, 0.57f) }
//};

