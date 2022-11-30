using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace YuzlikFathulloh
{
    public class ColumnScript : MonoBehaviour, IDropHandler
    {
        public enum TypeNumber { Ones, Tens, Hundreds, Thousands, TenThousands, HundredThousands }
        public TypeNumber CurrentTypeNumber;
        public int TypeNumberInt;
        public GameManager Gmanager;


        void Start()
        {
            SetTypeNumber();
        }


        void SetTypeNumber()
        {
            if (TypeNumberInt == 0)
                CurrentTypeNumber = TypeNumber.Ones;
            else if (TypeNumberInt == 1)
                CurrentTypeNumber = TypeNumber.Tens;
            else if (TypeNumberInt == 2)
                CurrentTypeNumber = TypeNumber.Hundreds;
            else if (TypeNumberInt == 3)
                CurrentTypeNumber = TypeNumber.Thousands;
            else if (TypeNumberInt == 4)
                CurrentTypeNumber = TypeNumber.TenThousands;
            else if (TypeNumberInt == 5)
                CurrentTypeNumber = TypeNumber.HundredThousands;
        }


        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("Item Dropped! CurrentTypeNumber = " + CurrentTypeNumber + " " + gameObject.name);
            Gmanager.IsArea = true;
        }



    }
}
