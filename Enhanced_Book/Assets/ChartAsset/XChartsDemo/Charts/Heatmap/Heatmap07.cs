using System;
using System.Collections.Generic;
using UnityEngine;
using XCharts.Runtime;

namespace XCharts.Demo
{

    [ExecuteInEditMode]
    [DisallowMultipleComponent]
    public class Heatmap07 : MonoBehaviour
    {
        [Serializable]
        class JsonInfo
        {
            public string name;
            public string country;
            public double value;
        }

        HeatmapChart m_Chart;

        void Awake()
        {
            m_Chart = GetComponent<HeatmapChart>();
            PraseJson(Resources.Load<TextAsset>("heatmap07F1").text);
        }

        private void PraseJson(string json)
        {
            var infos = JsonHelper.GetJsonArray<JsonInfo>(json);
            m_Chart.ClearData();

            var xData = new List<string>();
            var yData = new List<string>();
            foreach (var info in infos)
            {
                if (!yData.Contains(info.country))
                    yData.Add(info.country);
                if (!xData.Contains(info.name))
                    xData.Add(info.name);
            }
            var xAxis = m_Chart.GetOrAddChartComponent<XAxis>();
            xAxis.data = xData;
            var yAxis = m_Chart.GetOrAddChartComponent<YAxis>();
            yAxis.data = yData;

            var visualMap = m_Chart.GetOrAddChartComponent<VisualMap>();
            var colors = new List<string> { "#aa3523", "#fd8b6f", "#7eadfc", "#0d5fbb" };
            visualMap.AddColors(colors);
            visualMap.autoMinMax = true;

            foreach (var info in infos)
            {
                var xValue = (double) xData.IndexOf(info.name);
                var yValue = (double) yData.IndexOf(info.country);
                m_Chart.AddData(0, new List<double>() { xValue, yValue, info.value });
            }
        }

        public class JsonHelper
        {
            public static T[] GetJsonArray<T>(string json)
            {
                string newJson = "{ \"array\": " + json + "}";
                Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
                return wrapper.array;
            }

            [Serializable]
            private class Wrapper<T>
            {
#pragma warning disable 0649
                public T[] array;
#pragma warning restore 0649
            }
        }
    }
}