using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MarkedPage : MonoBehaviour
{

    public TMP_Text PageNumber;
    Button _button;
    


    private void Awake()
    {
        _button = transform.GetChild(1).GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Destroy(gameObject);
    }


}
