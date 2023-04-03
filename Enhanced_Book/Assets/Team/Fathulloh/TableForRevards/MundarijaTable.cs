using SLS.Widgets.Table;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace FathullohMundarijaTable
{
    public class MundarijaTable : MonoBehaviour
    {
        public enum TableType { None, ChapterOne, ChapterTwo, ChapterThree, ChapterFour };
        public TableType CurrentChapter;

        public MundarijaManager MunManager;
        //public GameObject MainObject;
        public Table MyTable;
        public string TopicStr;
        public List<string> NumberOfTopics;
        public List<string> AllTemas;
        public List<string> PageOfTemas;

        public List<Sprite> Sprites;
        bool _IsFirstTime = true;
        string strHeader;

        //public UnityEvent SoundEvent;

        void Start()
        {
            ChooseChapter();

            DrawTable();
        }


        private void OnEnable()
        {
            if (_IsFirstTime)
            {
                _IsFirstTime = false;
            }
            else if (!_IsFirstTime)
            {
                //Debug.Log("Need drawTableAgain");
                DrawTableAgain();                
            }
        }


        void DrawTable()
        {
            this.MyTable.ResetTable();

            this.MyTable.AddTextColumn("", null, -1, 18);
            this.MyTable.AddTextColumn(strHeader, null);            
            Column c = this.MyTable.AddTextColumn("", null, -1, 16);
            c.horAlignment = Column.HorAlignment.CENTER;

            this.MyTable.Initialize(this.OnRowSelected);

            for (int i = 0; i < AllTemas.Count; i++)
            {
                Datum dat = Datum.Body(TopicStr + i.ToString());
                dat.elements.Add(NumberOfTopics[i]);
                dat.elements.Add(AllTemas[i]);
                dat.elements.Add(PageOfTemas[i]);

                if (i == 14 - 1)
                {
                    dat.elements[0].color = new Color(1, 1, 1, 1);
                    dat.elements[1].color = new Color(1, 1, 1, 1);
                    dat.elements[2].color = new Color(1, 1, 1, 1);

                    dat.elements[0].backgroundColor = new Color(0.26f, 0.43f, 0.71f);
                    dat.elements[1].backgroundColor = new Color(0.26f, 0.43f, 0.71f);
                    dat.elements[2].backgroundColor = new Color(0.26f, 0.43f, 0.71f);                    
                }
                this.MyTable.data.Add(dat);
            }
            this.MyTable.StartRenderEngine();
        }


        private void OnRowSelected(Datum datum)
        {
            if (CurrentChapter == TableType.ChapterOne)
            {
                if (datum.uid.ToString().Equals(TopicStr + "0"))
                {
                    //Debug.Log(datum.uid.ToString().Contains(TopicStr + "0"));
                    ChangePage(0);
                }
                else if (datum.uid.ToString().Equals(TopicStr + "1"))
                {
                    //Debug.Log(datum.uid.ToString().Contains(TopicStr + "1"));
                    ChangePage(1);
                }
                else if (datum.uid.ToString().Equals(TopicStr + "2"))                
                    ChangePage(2);                
                else if (datum.uid.ToString().Equals(TopicStr + "3"))                                   
                    ChangePage(3);                               
            }

            //print("You Clicked: " + datum.uid);
            //for (int i = 0; i < datum.elements.Count; i++)            
            //    print(datum.elements[i].value);            
        }

        
        void ChooseChapter()
        {
            if (CurrentChapter == TableType.None)
            {
                Chapter1();
                Chapter2();
            }
            else if (CurrentChapter == TableType.ChapterOne)
                Chapter1();
            else if (CurrentChapter == TableType.ChapterTwo)
                Chapter2();
            else if (CurrentChapter == TableType.ChapterThree)
                Chapter3();
            else if (CurrentChapter == TableType.ChapterFour)
                Chapter4();
        }


        /// <summary>
        /// SeActive(false) va SetActive(true) bo'lganda qayta ishga tushirish uchun qo'llaniladigan metod.
        /// </summary>
        public void DrawTableAgain()
        {
            this.MyTable.ResetTable();

            this.MyTable.AddTextColumn("", null, -1, 20);
            this.MyTable.AddTextColumn(strHeader, null);
            Column c = this.MyTable.AddTextColumn("", null, -1, 18);
            c.horAlignment = Column.HorAlignment.CENTER;

            this.MyTable.Initialize(this.OnRowSelected);

            for (int i = 0; i < AllTemas.Count; i++)
            {
                Datum dat = Datum.Body(TopicStr + i.ToString());
                dat.elements.Add(NumberOfTopics[i]);
                dat.elements.Add(AllTemas[i]);
                dat.elements.Add(PageOfTemas[i]);

                if (i == 14 - 1)
                {
                    dat.elements[0].color = new Color(1, 1, 1, 1);
                    dat.elements[1].color = new Color(1, 1, 1, 1);
                    dat.elements[2].color = new Color(1, 1, 1, 1);

                    dat.elements[0].backgroundColor = new Color(0.26f, 0.43f, 0.71f);
                    dat.elements[1].backgroundColor = new Color(0.26f, 0.43f, 0.71f);
                    dat.elements[2].backgroundColor = new Color(0.26f, 0.43f, 0.71f);
                }
                this.MyTable.data.Add(dat);
            }
            this.MyTable.StartRenderEngine();
        }


        void ChangePage(int num)
        {
            MunManager.BookObj.transform.GetChild(0).GetComponent<Image>().sprite = Sprites[num];
            MunManager.PageEvent.Invoke();            
            //MainObject.transform.GetChild(0).GetComponent<Image>().sprite = Sprites[num];
            gameObject.transform.parent.transform.parent.gameObject.SetActive(false);
        }


        void Chapter1()
        {
            strHeader = "I bob. Natural sonlarni qoʻshish va ayirish";
            NumberOfTopics.Add("1.1");
            AllTemas.Add("Natural sonlar va nol");
            PageOfTemas.Add("8");

            NumberOfTopics.Add("1.2");
            AllTemas.Add("Sodda geometrik shakllar");
            PageOfTemas.Add("16");

            NumberOfTopics.Add("1.3");
            AllTemas.Add("Shkalalar va sonlar nuri.");
            PageOfTemas.Add("23");

            NumberOfTopics.Add("1.4");
            AllTemas.Add("Natural sonlarni taqqoslash. Katta va kichik");
            PageOfTemas.Add("23");

            NumberOfTopics.Add("1.5");
            AllTemas.Add("Natural sonlarni yaxlitlash");
            PageOfTemas.Add("23");

            NumberOfTopics.Add("1.6");
            AllTemas.Add("Natural sonlarni qoʻshish");
            PageOfTemas.Add("37");

            NumberOfTopics.Add("1.7");
            AllTemas.Add("Natural sonlarni ayirish");
            PageOfTemas.Add("46");

            NumberOfTopics.Add("1.8");
            AllTemas.Add("Sonli va harfli ifodalar");
            PageOfTemas.Add("53");

            NumberOfTopics.Add("1.9");
            AllTemas.Add("Masalaning matematik modeli. Tenglamalar");
            PageOfTemas.Add("61");

            NumberOfTopics.Add("1.10");
            AllTemas.Add("Bobga doir murakkabroq va nostandart masalalarni yechish");
            PageOfTemas.Add("70");

            NumberOfTopics.Add("1.11");
            AllTemas.Add("Loyiha ishi");
            PageOfTemas.Add("80");

            NumberOfTopics.Add("");
            AllTemas.Add("Summativ baholash topshiriqlaridan namunalar");
            PageOfTemas.Add("83");

            NumberOfTopics.Add("");
            AllTemas.Add("Bob bo‘yicha test topshiriqlari");
            PageOfTemas.Add("85");    
        }


        void Chapter2()
        {
            strHeader = "II bob. Natural sonlarni ko‘paytirish va boʻlish";

            NumberOfTopics.Add("2.1");
            AllTemas.Add("Natural sonlarni ko‘paytirish");
            PageOfTemas.Add("90");

            NumberOfTopics.Add("2.2");
            AllTemas.Add("Natural sonlarni bo‘lish");
            PageOfTemas.Add("97");

            NumberOfTopics.Add("2.3");
            AllTemas.Add("Qoldiqli bo‘lish");
            PageOfTemas.Add("104");

            NumberOfTopics.Add("2.4");
            AllTemas.Add("Qulay usullarda hisoblash");
            PageOfTemas.Add("111");

            NumberOfTopics.Add("2.5");
            AllTemas.Add("Sonli ifodalarni soddalashtirish");
            PageOfTemas.Add("119");

            NumberOfTopics.Add("2.6");
            AllTemas.Add("To‘rt amalga doir hisoblash algoritmlari");
            PageOfTemas.Add("119");

            NumberOfTopics.Add("2.7");
            AllTemas.Add("Sonning darajasi. Sonning kvadrati va kubi");
            PageOfTemas.Add("126");

            NumberOfTopics.Add("2.8");
            AllTemas.Add("Ma’lumotlar bilan ishlash");
            PageOfTemas.Add("132");

            NumberOfTopics.Add("2.9");
            AllTemas.Add("Bobga doir murakkabroq va nostandart masalalarni yechish");
            PageOfTemas.Add("146");

            NumberOfTopics.Add("");
            AllTemas.Add("Summativ baholash topshiriqlaridan namunalar");
            PageOfTemas.Add("155");

            NumberOfTopics.Add("");
            AllTemas.Add("Bob bo‘yicha test topshiriqlari");
            PageOfTemas.Add("156");
        }


        void Chapter3()
        {
            strHeader = "III bob. Matnli masalalar";

            NumberOfTopics.Add("3.1");
            AllTemas.Add("Matnli masalalar");
            PageOfTemas.Add("160");

            NumberOfTopics.Add("3.2");
            AllTemas.Add("Harakatga doir masalalar");
            PageOfTemas.Add("166");

            NumberOfTopics.Add("3.3");
            AllTemas.Add("Ikki jism harakatiga doir masalalar");
            PageOfTemas.Add("176");

            NumberOfTopics.Add("3.4");
            AllTemas.Add("Iqtisodiy mazmundagi masalalar");
            PageOfTemas.Add("183");

            NumberOfTopics.Add("3.5");
            AllTemas.Add("Bajarilgan ishga doir masalalar");
            PageOfTemas.Add("189");

            NumberOfTopics.Add("3.6");
            AllTemas.Add("Sonli naqshlar");
            PageOfTemas.Add("197");

            NumberOfTopics.Add("3.7");
            AllTemas.Add("Mantiqiy masalalar");
            PageOfTemas.Add("206");

            NumberOfTopics.Add("3.8");
            AllTemas.Add("Quyish va tortishga doir masalalar");
            PageOfTemas.Add("218");

            NumberOfTopics.Add("3.9");
            AllTemas.Add("Bobga doir murakkabroq va nostandart masalalarni yechish");
            PageOfTemas.Add("223");

            NumberOfTopics.Add("3.10");
            AllTemas.Add("Loyiha ishi");
            PageOfTemas.Add("232");

            NumberOfTopics.Add("");
            AllTemas.Add("Summativ baholash topshiriqlaridan namunalar");
            PageOfTemas.Add("235");

            NumberOfTopics.Add("");
            AllTemas.Add("Bob bo‘yicha test topshiriqlari");
            PageOfTemas.Add("237");
        }


        void Chapter4()
        {
            strHeader = "IV bob. Geometrik shakllar";

            NumberOfTopics.Add("4.1");
            AllTemas.Add("Burchaklar");
            PageOfTemas.Add("242");

            NumberOfTopics.Add("4.2");
            AllTemas.Add("Parallel va perpendikular to‘g‘ri chiziqlar");
            PageOfTemas.Add("253");

            NumberOfTopics.Add("4.3");
            AllTemas.Add("Koordinatalar burchagi");
            PageOfTemas.Add("260");

            NumberOfTopics.Add("4.4");
            AllTemas.Add("Ko‘pburchak");
            PageOfTemas.Add("268");

            NumberOfTopics.Add("4.5");
            AllTemas.Add("To‘g‘ri to‘rtburchak va kvadratning yuzi");
            PageOfTemas.Add("277");

            NumberOfTopics.Add("4.6");
            AllTemas.Add("Yuz o‘lchov birliklari");
            PageOfTemas.Add("284");

            NumberOfTopics.Add("4.7");
            AllTemas.Add("Murakkab shakllarning yuzi");
            PageOfTemas.Add("293");

            NumberOfTopics.Add("4.8");
            AllTemas.Add("Bobga doir murakkabroq va nostandart masalalarni yechish");
            PageOfTemas.Add("303");

            NumberOfTopics.Add("4.9");
            AllTemas.Add("Loyiha ishi");
            PageOfTemas.Add("314");

            NumberOfTopics.Add("");
            AllTemas.Add("Summativ baholash topshiriqlaridan namunalar");
            PageOfTemas.Add("316");

            NumberOfTopics.Add("");
            AllTemas.Add("Bob bo‘yicha test topshiriqlari");
            PageOfTemas.Add("318");

            NumberOfTopics.Add("");
            AllTemas.Add("Foydalanilgan va tavsiya etiladigan adabiyotlar ro‘yxati");
            PageOfTemas.Add("322");

            //NumberOfTopics.Add("");
            //AllTemas.Add("");
            //PageOfTemas.Add("");
        }

    }
}
