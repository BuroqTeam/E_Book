using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{

    List<GameObject> _buttons = new List<GameObject>();

    private void Awake()
    {
        for (int i = 0;  i < transform.childCount; i++)
        {
            _buttons.Add(transform.GetChild(i).gameObject);
        }
    }

    public void ClickMenuButton(GameObject clickedObj)
    {
        foreach (GameObject obj in _buttons)
        {
            if (obj.Equals(clickedObj))
            {
                obj.GetComponent<Menu>().SetOn();
            }
            else
            {
                obj.GetComponent<Menu>().SetOff();
            }
        }
    }

   
}
