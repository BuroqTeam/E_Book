using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl_P2 : MonoBehaviour
{
    public Pattern_2 Pattern2;
    public bool Answer;
    public bool Select;
    private void Start()
    {
        if (transform.GetChild(0).GetComponent<TMP_Text>().text.Contains('*'))
        {
            Answer = true;
            transform.GetChild(0).GetComponent<TMP_Text>().text = transform.GetChild(0).GetComponent<TMP_Text>().text.Replace("*","");
        }
    }

    public void OnClick()
    {
        if (Select)
        {
            transform.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            transform.GetChild(0).GetComponent<TMP_Text>().color = new Color32(50, 50, 50, 255);
            Select = false;
        }
        else
        {
            transform.GetComponent<Image>().color = new Color32(0, 148, 255, 255);
            transform.GetChild(0).GetComponent<TMP_Text>().color = new Color32(255, 255, 255, 255);
            Select = true;
        }
        Pattern2.Check();
    }
}
