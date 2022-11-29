using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FathullohExample
{
    public class ColumnScript : MonoBehaviour, IDropHandler
    {
        

        void Start()
        {

        }


        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("Item Dropped! ");
        }



    }
}
