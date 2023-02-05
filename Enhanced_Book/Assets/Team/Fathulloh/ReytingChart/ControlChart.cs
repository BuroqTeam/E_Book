using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReytingPanel
{
    public class ControlChart : MonoBehaviour
    {
        public GameObject ParentForChart;
        float scaleChart = 0.5f;


        void Start()
        {

        }



        public void MaximizeChart(GameObject obj)
        {
            ParentForChart.SetActive(true);

            if (ParentForChart.transform.childCount > 0)
            {
                Destroy(ParentForChart.transform.GetChild(0));
            }
            
            GameObject prefabObj = Instantiate(obj, ParentForChart.transform);
            prefabObj.transform.localScale = new Vector3(scaleChart, scaleChart, scaleChart);

        }



        
    }
}
