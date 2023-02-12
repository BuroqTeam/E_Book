using SLS.Widgets.Table;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace TableReward
{
    /// <summary>
    /// Mustaqil ravishda qilinayotgan Tablening kodi shu scriptda yozilayabdi.
    /// </summary>
    public class CreateTable0 : MonoBehaviour
    {        
        public Table MyTable;
        public Sprite FirstPalace;
        public Sprite SecondPalace;
        public Sprite ThirdPalace;

        public int NumberOfRows;
        public string StrTask;

        private Dictionary<string, Sprite> SpriteDict;
        private List<string> SpriteNames;
        
        List<DataOfRow> ReserveTable = new List<DataOfRow>();

        //public List<Sprite> GameSprites;
        //public List<Sprite> TaskSprites;
        //public List<Sprite> ExamSprites;

        //private Dictionary<string, Sprite> GameSpriteDict;
        //private Dictionary<string, Sprite> TaskSpriteDict;
        //private Dictionary<string, Sprite> ExamSpriteDict;

        //private List<string> GameSpriteNames;
        //private List<string> TaskSpriteNames;
        //private List<string> ExamSpriteNames;


        void Start()
        {
            DrawTable();
        }
        

        //void MakeDictionary()
        //{
        //    this.GameSpriteDict = new Dictionary<string, Sprite>();
        //    this.GameSpriteDict.Add("1", GameSprites[0]);
        //    this.GameSpriteDict.Add("2", GameSprites[1]);
        //    this.GameSpriteDict.Add("3", GameSprites[2]);
        //    this.GameSpriteNames = new List<string>(GameSpriteDict.Keys);

        //    this.TaskSpriteDict = new Dictionary<string, Sprite>();
        //    this.TaskSpriteDict.Add("1", TaskSprites[0]);
        //    this.TaskSpriteDict.Add("2", TaskSprites[1]);
        //    this.TaskSpriteDict.Add("3", TaskSprites[2]);
        //    this.TaskSpriteNames = new List<string>(TaskSpriteDict.Keys);

        //    this.ExamSpriteDict = new Dictionary<string, Sprite>();
        //    this.ExamSpriteDict.Add("1", ExamSprites[0]);
        //    this.ExamSpriteDict.Add("2", ExamSprites[1]);
        //    this.ExamSpriteDict.Add("3", ExamSprites[2]);
        //    this.ExamSpriteNames = new List<string>(ExamSpriteDict.Keys);
        //}


        public void DrawTable()
        {
            //MakeDefaults.Set();
            this.SpriteDict = new Dictionary<string, Sprite>();
            this.SpriteDict.Add("1", this.FirstPalace);
            this.SpriteDict.Add("2", this.SecondPalace);
            this.SpriteDict.Add("3", this.ThirdPalace);

            this.SpriteNames = new List<string>(this.SpriteDict.Keys);

            this.MyTable.ResetTable();

            this.MyTable.AddTextColumn("index", null/*, 25, 45*/);
            this.MyTable.AddTextColumn("Topshiriq");
            this.MyTable.AddTextColumn("Mavzu nomi");
            this.MyTable.AddImageColumn("Sovrin", null, 35, 35);

            this.MyTable.Initialize(this.OnRowSelected, this.SpriteDict);

            for (int i = 0; i < NumberOfRows; i++)
            {
                Datum dat = Datum.Body(StrTask + i.ToString());
                dat.elements.Add(i + 1);
                dat.elements.Add(StrTask + " " + (i + 1).ToString());
                dat.elements.Add("Kasrlar");
                string str0 = RandomSprite();
                dat.elements.Add(str0);

                DataOfRow myRow = new DataOfRow();
                myRow.IndexNumber = (i + 1).ToString();
                myRow.TaskType = StrTask + " " + (i + 1).ToString();
                myRow.TopicName = "Kasrlar";
                myRow.SpriteStr = str0;
                ReserveTable.Add(myRow);
                                
                //dat.uid = i.ToString();
                this.MyTable.data.Add(dat);
            }                        

            this.MyTable.StartRenderEngine();            
        }
        

        string RandomSprite()
        {
            int spriteIndex = Random.Range(0, SpriteNames.Count);
            return this.SpriteNames[spriteIndex];
        }


        // Handle the Row Selection however you wish
        private void OnRowSelected(Datum datum)
        {
            print("You Clicked: " + datum.uid);
            for (int i = 0; i < datum.elements.Count; i++)
            {
                //print(datum.elements[i].value);
            }
        }


        public void SortTable(GameObject ObjDropDown)
        {
            string str = ObjDropDown.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text;
            Debug.Log("str = " + str );

            if (str == "Oltin")
            {
                Debug.Log("Oltin");
                RemoveRows(1);
            }
            else if (str == "Kumush")
            {
                RemoveRows(2);
            }
            else if (str == "Bronza")
            {
                RemoveRows(3);
            }
            else if (str == "Barchasi")
            {
                this.MyTable.data.Clear();
                ReCreateTable();                
            } 
            
        }


        public void RemoveRows(int number)
        {
            if (NumberOfRows != this.MyTable.data.Count)
            {
                Debug.Log(" Restart qilib olindi. " + " this.MyTable.data.Count = " + this.MyTable.data.Count);
                this.MyTable.data.Clear();
                ReCreateTable();
            }

            for (int i = this.MyTable.data.Count; i > 0; i--)
            {                
                Datum datum = this.MyTable.data[i - 1];
                
                if (datum.elements[3].value != number.ToString())
                {
                    //Debug.Log(i + " datum.elements[3].value = " + datum.elements[3].value.ToString());
                    this.MyTable.data.RemoveAt(i - 1);
                }                
            }
                       
        }


        public void ReCreateTable()
        {
            for (int i = 0; i < NumberOfRows; i++)
            {
                Datum dat = Datum.Body(StrTask + i.ToString());
                DataOfRow myRow = ReserveTable[i];
                dat.elements.Add(myRow.IndexNumber);
                dat.elements.Add(myRow.TaskType);
                dat.elements.Add(myRow.TopicName);                
                dat.elements.Add(myRow.SpriteStr);

                this.MyTable.data.Add(dat);
            }

            this.MyTable.StartRenderEngine();
        }



    }


    [SerializeField]
    public class DataOfRow
    {
        public string IndexNumber;
        public string TaskType;
        public string TopicName;
        public string SpriteStr;
    }

}
