using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Texture2D CursorOn;
    public Texture2D CursorOff;

    

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Cursor.SetCursor(CursorOn, Vector3.zero, CursorMode.ForceSoftware);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(CursorOff, Vector3.zero, CursorMode.ForceSoftware);
    }

  

}
