using SLS.Widgets.Table;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TableReward
{
    public class CreateTable2 : MonoBehaviour
    {
        public Table table;
        public Sprite sprite1;
        public Sprite sprite2;
        public Sprite sprite3;
        public int RowNumbers;

        private Dictionary<string, Sprite> spriteDict;
        private List<string> spriteNames;


        void Start()
        {
            MakeTable();
        }

        
        void MakeTable()
        {
            MakeDefaults.Set();
            this.spriteDict = new Dictionary<string, Sprite>();
            this.spriteDict.Add("1", this.sprite1);
            this.spriteDict.Add("2", this.sprite2);
            this.spriteDict.Add("3", this.sprite3);
            

            this.spriteNames = new List<string>(this.spriteDict.Keys);

            this.table.ResetTable();

            this.table.AddImageColumn("h0", "f0", 32, 32);
            this.table.AddTextColumn("h1", "f1");
            this.table.AddImageColumn("h3", "f3", 32, 32);
            this.table.AddImageColumn("h6", "f6", 32, 32);

            this.table.Initialize(this.OnRowSelected, this.spriteDict);

            // Populate Your Rows (obviously this would be real data here)
            for (int i = 0; i < 8; i++)
            {
                Datum d = this.MakeDatum("INIT_" + i.ToString());
                d.uid = i.ToString();
                this.table.data.Add(d);
            }

            // Draw Your Table
            this.table.StartRenderEngine();
        }


        private Datum MakeDatum(string pfx)
        {
            string sfx = Time.realtimeSinceStartup.ToString();
            Datum d = Datum.Body(sfx);
            d.elements.Add(this.RandomSprite());
            d.elements.Add("Col1:" + pfx + ":" + sfx);
            
            d.elements.Add(this.RandomSprite());
            
            d.elements.Add(this.RandomSprite());
            
            return d;
        }

        private string RandomSprite()
        {
            int idx = Random.Range(0, this.spriteNames.Count);
            return this.spriteNames[idx];
        }

        IEnumerator DoRandomData()
        {
            yield return new WaitForSeconds(2f);
            while (true)
            {
                float action = Random.Range(0, 50);
                if (action < 5)
                {
                    this.table.data.Add(this.MakeDatum("ADD"));
                }
                else if (action < 10)
                {
                    this.PushRowTop();
                }
                else if (action < 13)
                {
                    this.PushRowRandom();
                }
                else if (action < 16)
                {
                    this.PushRowBottom();
                }
                else if (action < 20)
                {
                    this.DeleteRow();
                }
                else if (action < 25)
                {
                    int cidx = Random.Range(0, this.table.columns.Count);
                    string x = "UPD:" + Time.realtimeSinceStartup.ToString();
                    for (int i = 1; i < Random.Range(0, 10); i++)
                    {
                        x = x + "\nLine:" + i.ToString();
                    }
                    this.table.columns[cidx].headerValue = x;
                }
                else if (action < 30)
                {
                    int cidx = Random.Range(0, this.table.columns.Count);
                    string x = "UPD:" + Time.realtimeSinceStartup.ToString();
                    for (int i = 1; i < Random.Range(0, 4); i++)
                    {
                        x = x + "\nLine:" + i.ToString();
                    }
                    this.table.columns[cidx].footerValue = x;
                }
                else
                {
                    this.UpdateRow();
                }
                yield return new WaitForSeconds(Random.Range(0.5f, 1f));
                //yield return new WaitForSeconds(0.5f);
            }
        }

        // Handle the Row Selection however you wish
        private void OnRowSelected(Datum datum)
        {
            print("You Clicked: " + datum.uid);
            for (int i = 0; i < datum.elements.Count; i++)
            {
                print(datum.elements[i].value);
            }
        }

        // Handle Header Selection however you wish
        private void OnHeaderSelected(Column column)
        {
            print("You Clicked Column: " + column.idx + " " + column.headerValue);
        }

        public void PushRowTop()
        {
            this.table.data.Insert(0, this.MakeDatum("TOP"));
        }

        public void PushRowRandom()
        {
            int ridx = Random.Range(0, this.table.data.Count);
            this.table.data.Insert(ridx, this.MakeDatum("INS"));
        }

        public void PushRowBottom()
        {
            this.table.data.Insert(this.table.data.Count, this.MakeDatum("BOT"));
        }

        public void DeleteRow()
        {
            if (this.table.data.Count == 0)
                return;
            int ridx = Random.Range(0, this.table.data.Count);
            this.table.data.RemoveAt(ridx);
        }

        public void UpdateRow()
        {
            int ridx = Random.Range(0, this.table.data.Count);
            int cidx = Random.Range(0, this.table.columns.Count);
            //print("Updating Row: " + ridx + " Column: " + cidx);
            if (cidx != 0 && cidx != 3 && cidx != 6)
            {
                string x = "UPD:" + Time.realtimeSinceStartup.ToString();
                for (int i = 1; i < Random.Range(0, 20); i++)
                {
                    x = x + "\nLine:" + i.ToString();
                }
                this.table.data[ridx].elements[cidx].value = x;
            }
            else
                this.table.data[ridx].elements[cidx].value =
                  this.RandomSprite();
        }

    }
}
