using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YuzlikFathulloh
{
    /// <summary>
    /// Qayta boshlashni tugmasiga kerakli metod va o'zgaruvchilar shu scriptda.
    /// </summary>
    public class RestartButton : MonoBehaviour
    {
        public List<GameObject> BoxsForDiscs;
        public List<GameObject> Columns;
        public List<GameObject> AllDiscs;


        void Start()
        {
            TakeAllChilds();
        }

        

        void TakeAllChilds()
        {
            
            for (int i = 0; i < BoxsForDiscs.Count; i++)
            {                
                for (int j = 0; j < BoxsForDiscs[i].transform.childCount; j++)
                {
                    //Debug.Log("BoxsForDiscs.name = " + BoxsForDiscs[i].transform.GetChild(j).gameObject.name);
                    AllDiscs.Add(BoxsForDiscs[i].transform.GetChild(j).gameObject);
                }
            }
        }




        public void ReturnDiscsInitialPos()
        {
            for (int i = 0; i < AllDiscs.Count; i++)
            {
                AllDiscs[i].GetComponent<DragAndDrop>().ReturnInitialPos();
            }
        }




    }
}
