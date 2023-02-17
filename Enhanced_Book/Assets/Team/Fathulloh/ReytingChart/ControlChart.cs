using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReytingPanel
{
    public class ControlChart : MonoBehaviour
    {        
        public GameObject ParentForChart;        
        float scaleChart = 0.45f;

        public List<GameObject> Prefabs;


        void Start()
        {
            //WorkingTest();
        }


        //void WorkingTest()
        //{
        //    Debug.Log("Started.");
        //}


        public void MaximizeChart(GameObject obj)
        {            
            ParentForChart.SetActive(true);

            if (ParentForChart.transform.childCount > 0)
            {
                Destroy(ParentForChart.transform.GetChild(0).gameObject);                
            }
            
            GameObject prefabObj = Instantiate(obj, ParentForChart.transform);
            prefabObj.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            prefabObj.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            prefabObj.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
            prefabObj.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);

            prefabObj.transform.GetChild(0).transform.localScale = new Vector3(scaleChart, scaleChart, scaleChart);
            prefabObj.GetComponent<Button>().enabled = false;            
        }


        public void CreateChart(int numPrefab)
        {
            ParentForChart.SetActive(true);

            if (ParentForChart.transform.childCount > 0)
            {
                Destroy(ParentForChart.transform.GetChild(0).gameObject);                
            }

            //Debug.Log("Is working! 222");
            for (int i = 0; i < Prefabs.Count + 2; i++)
            {
                if (i == numPrefab)
                {                    
                    GameObject gObj = Instantiate(Prefabs[i - 1], ParentForChart.transform);
                    gObj.SetActive(true);
                    gObj.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
                    gObj.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
                    gObj.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                    gObj.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
                    break;
                }
            }

        }



        //GameObject prefabCloseObj = Instantiate(CloseButton, prefabObj.transform);
        //prefabCloseObj.GetComponent<RectTransform>().anchorMin = new Vector2(1, 1);
        //prefabCloseObj.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        //prefabCloseObj.GetComponent<RectTransform>().offsetMax = new Vector2(-50, 20);
        //prefabCloseObj.GetComponent<RectTransform>().offsetMin = new Vector2(-20, 35);


    }
}
