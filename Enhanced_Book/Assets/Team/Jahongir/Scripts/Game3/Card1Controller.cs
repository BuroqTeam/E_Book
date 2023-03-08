using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card1Controller : MonoBehaviour
{
    public string Str;
    public int Index;

    private void Start()
    {
        InputData();
    }
    public void InputData()
    {
        transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = Str;
    }

}
