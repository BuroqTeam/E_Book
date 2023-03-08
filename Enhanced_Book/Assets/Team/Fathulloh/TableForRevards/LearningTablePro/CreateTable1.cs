using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SLS.Widgets.Table;

namespace TableReward
{
    /// <summary>
    /// TablePro assetidagi Simple scriptini o'rniga tayyorlangan script. Keraksiz.
    /// </summary>
    public class CreateTable1 : MonoBehaviour
    {
        private Table table;
        public int ROWS = 10;
        string str;

        public Sprite GoldSprite, SilverSprite, BronzeSprite;
        private Dictionary<string, Sprite> spriteDict;
        private List<string> spriteNames;

        void Start()
        {
            MakeTable();
        }


        void MakeTable()
        {
            // this instantiates default fonts for ALL tables when not explicitely defined on an individual table
            //  ProTip: You don't need to do this if you just set a font for your table in the editor
            MakeDefaults.Set();

            this.spriteDict = new Dictionary<string, Sprite>();
            this.spriteDict.Add("1", this.GoldSprite);
            this.spriteDict.Add("2", this.SilverSprite);
            this.spriteDict.Add("3", this.BronzeSprite);

            this.spriteNames = new List<string>(this.spriteDict.Keys);


            this.table = this.GetComponent<Table>();

            this.table.ResetTable();

            this.table.AddTextColumn("id");
            this.table.AddTextColumn("Topshiriq");
            this.table.AddTextColumn("Mavzu");
            this.table.AddImageColumn("Sovrin");

            // Initialize Your Table
            this.table.Initialize(this.OnTableSelected);


            // Populate Your Rows (obviously this would be real data here)
            for (int i = 0; i < ROWS; i++)
            {
                Datum d = Datum.Body(i.ToString());
                d.elements.Add(/*"Col1:Row" + */i.ToString());
                d.elements[0].color = new Color(0, .45f, 0.38f);
                d.elements[0].backgroundColor = new Color(0.2f, 0, 0);
                d.elements.Add("Col2:Row" + i.ToString());
                d.elements.Add("Col3:Row" + i.ToString());
                d.elements.Add(this.RandomSprite());
                this.table.data.Add(d);
            }

            // Draw Your Table
            this.table.StartRenderEngine();

        }


        // Handle the row selection however you wish (be careful as column can be null here
        //  if your table doesn't fill the full horizontal rect space and the user clicks an edge)
        private void OnTableSelected(Datum datum, Column column)
        {
            string cidx = "N/A";
            if (column != null)
                cidx = column.idx.ToString();
            if (datum != null)
                print("You Clicked: " + datum.uid + " Column: " + cidx);
            else
                print("Selection Cleared!");
        }

        public void HandleSelectRandomClick()
        {
            int idx = Random.Range(0, this.table.data.Count - 1);
            this.table.SetSelected(this.table.data[idx], null, true, true);
        }

        public void HandleClearSelectionClick()
        {
            this.table.lastSelectedDatum = null;
        }

        private string RandomSprite()
        {
            int idx = Random.Range(0, this.spriteNames.Count);
            return this.spriteNames[idx];
        }
    }
}
