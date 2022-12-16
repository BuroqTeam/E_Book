using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game2_Fathulloh
{
    /// <summary>
    /// Geo-Board o'yini uchun boardni yasab beruvchi script.
    /// </summary>
    public class Board : MonoBehaviour
    {
        public List<GameObject> Hooks;
        public GameObject HookPrefab;
        public int GridX, GridY;
        public float Xdistance, Ydistance;


        void Start()
        {
            MakeBoard();
        }


        void MakeBoard()
        {
            float xInitial = -(float)GridX / 2 * Xdistance + (float)Xdistance / 2;
            float yInitial = -(float)GridY / 2 * Ydistance + (float)Ydistance / 2;


            for (int i = 0; i < GridX; i++)
            {
                float xPos = xInitial + i * Xdistance;
                for (int j = 0; j < GridY; j++)
                {
                    float yPos = yInitial + j * Ydistance;
                    GameObject obj = Instantiate(HookPrefab);
                    Hooks.Add(obj);
                    obj.transform.position = new Vector3(xPos, yPos);
                    obj.transform.SetParent(this.transform);
                }
            }

        }





    }
}
