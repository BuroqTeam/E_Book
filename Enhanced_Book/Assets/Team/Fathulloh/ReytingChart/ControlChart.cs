using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReytingPanel
{
    public class ControlChart : MonoBehaviour
    {
        public GameObject ParentForChart;
        public GameObject CloseButton;
        float scaleChart = 0.45f;


        void Start()
        {
            WorkingTest();
        }


        void WorkingTest()
        {
            Debug.Log("Started.");
        }


        public void WorkingTest2(string str)
        {
            Debug.Log("string str = " + str);
        }


        public void MaximizeChart(GameObject obj)
        {            
            ParentForChart.SetActive(true);

            if (ParentForChart.transform.childCount > 0)
            {
                Destroy(ParentForChart.transform.GetChild(0).gameObject);
                Debug.Log("Is working!");
            }
            
            GameObject prefabObj = Instantiate(obj, ParentForChart.transform);
            prefabObj.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            prefabObj.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            prefabObj.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
            prefabObj.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);

            prefabObj.transform.GetChild(0).transform.localScale = new Vector3(scaleChart, scaleChart, scaleChart);
            prefabObj.GetComponent<Button>().enabled = false;

            //GameObject prefabCloseObj = Instantiate(CloseButton, prefabObj.transform);
            //prefabCloseObj.GetComponent<RectTransform>().anchorMin = new Vector2(1, 1);
            //prefabCloseObj.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            //prefabCloseObj.GetComponent<RectTransform>().offsetMax = new Vector2(-50, 20);
            //prefabCloseObj.GetComponent<RectTransform>().offsetMin = new Vector2(-20, 35);
            
            //prefabObj.transform.localScale = new Vector3(scaleChart, scaleChart, scaleChart);

        }



        
    }
}
