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
    public class CreateTable : MonoBehaviour
    {   
        public enum TableType { GameTable, TaskTable, ExamTable};
        public TableType CurrentTable;

        public Table MyTable;
        public Sprite FirstPalace;
        public Sprite SecondPalace;
        public Sprite ThirdPalace;

        public int NumberOfRows;
        public string StrTask;

        private Dictionary<string, Sprite> SpriteDict;
        private List<string> SpriteNames;
        
        List<DataOfRow> ReserveTable = new List<DataOfRow>();
        
        private List<string> Topics = new List<string>();


        void Start()
        {
            CreateTopicList();
            DrawTable();
        }
                  

        public void DrawTable()
        {
            //MakeDefaults.Set();
            this.SpriteDict = new Dictionary<string, Sprite>();
            this.SpriteDict.Add("1", this.FirstPalace);
            this.SpriteDict.Add("2", this.SecondPalace);
            this.SpriteDict.Add("3", this.ThirdPalace);

            this.SpriteNames = new List<string>(this.SpriteDict.Keys);

            this.MyTable.ResetTable();
                        
            this.MyTable.AddTextColumn("№", null, -1, 30);
            this.MyTable.AddTextColumn("Topshiriq", null, -1, 90);
            this.MyTable.AddTextColumn("Mavzu nomi");
            this.MyTable.AddImageColumn("Sovrin", null, 20, 20);

            this.MyTable.Initialize(this.OnRowSelected, this.SpriteDict);

            for (int i = 0; i < NumberOfRows; i++)
            {
                Datum dat = Datum.Body(StrTask + i.ToString());
                dat.elements.Add(i + 1);
                dat.elements.Add((i + 1).ToString() + "-" + StrTask);
                dat.elements.Add(Topics[i]);
                string str0 = RandomSprite();
                dat.elements.Add(str0);

                DataOfRow myRow = new DataOfRow();
                myRow.IndexNumber = (i + 1).ToString();
                myRow.TaskType =  (i + 1).ToString() + "-" + StrTask;
                myRow.TopicName = Topics[i];
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
            //print("You Clicked: " + datum.uid);
            for (int i = 0; i < datum.elements.Count; i++)
            {
                //print(datum.elements[i].value);
            }
        }


        public void SortTable(GameObject ObjDropDown)
        {
            string str = ObjDropDown.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text;
            //Debug.Log("str = " + str );

            if (str == "Oltin")
            {
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

            
            for (int i = 0; i < this.MyTable.data.Count; i++)
            {
                Datum datum = this.MyTable.data[i];
                datum.elements[0].value = (i + 1).ToString();
            }
            
        }


        /// <summary>
        /// Table ni qaytadan yasaydigan metod.
        /// </summary>
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


        void CreateTopicList()
        {
            Topics.Add("Natural sonlar va nol");
            Topics.Add("Sodda geometrik shakllar");
            Topics.Add("Shkalalar va sonlar nuri");
            Topics.Add("Natural sonlarni taqqoslash. Katta va kichik");
            Topics.Add("Natural sonlarni yaxlitlash");
            Topics.Add("Natural sonlarni qoʻshish");
            Topics.Add("Natural sonlarni ayirish");
            Topics.Add("Sonli va harfli ifodalar");
            Topics.Add("Masalaning matematik modeli. Tenglamalar");

            Topics.Add("Natural sonlarni ko‘paytirish");
            Topics.Add("Natural sonlarni bo‘lish");
            Topics.Add("Qoldiqli bo‘lish");
            Topics.Add("Qulay usullarda hisoblash ");
            Topics.Add("Sonli ifodalarni soddalashtirish");
            Topics.Add("To‘rt amalga doir hisoblash algoritmlari");
            Topics.Add("Sonning darajasi. Sonning kvadrati va kubi");
            Topics.Add("Ma’lumotlar bilan ishlash"); 

            Topics.Add("Matnli masalalar"); 
            Topics.Add("Harakatga doir masalalar");
            Topics.Add("Ikki jism harakatiga doir masalalar");
            Topics.Add("Iqtisodiy mazmundagi masalalar");
            Topics.Add("Bajarilgan ishga doir masalalar");
            Topics.Add("Sonli naqshlar");
            Topics.Add("Mantiqiy masalalar");
            Topics.Add("Quyish va tortishga doir masalalar");

            Topics.Add("Burchaklar");
            Topics.Add("Paralel va perpendikular to‘g‘ri chiziqlar");
            Topics.Add("Koordinatalar burchagi");
            Topics.Add("Ko‘pburchak");
            Topics.Add("To‘g‘ri to‘rtburchak va kvadratning yuzi");
            Topics.Add("Yuz o‘lchov birliklari");
            Topics.Add("Murakkab shakllarning yuzi");
            //Topics.Add("");
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
