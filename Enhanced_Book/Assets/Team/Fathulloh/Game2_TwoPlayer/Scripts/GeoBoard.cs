using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game2_TwoPlayer
{
    public class GeoBoard : MonoBehaviour
    {
        public enum BoardOrder {First, Second };
        public BoardOrder CurrentOrder;
        public GameObject ParentForDots;
        public GameObject HookPrefab;

        public int GridX, GridY;
        public float Xdistance, Ydistance;

        public List<GameObject> Hooks;
        public List<GameObject> Lines;  // kerak emas bo‘lishi mumkin.


        void Start()
        {
            MakeBoard();
        }


        void MakeBoard()
        {
            float xInitial = 0.1f + gameObject.transform.position.x - (float)GridX / 2 * Xdistance + (float)Xdistance / 2;
            float yInitial = 0.1f + gameObject.transform.position.y - (float)GridY / 2 * Ydistance + (float)Ydistance / 2;

            for (int i = 0; i < GridX; i++)
            {
                float xPos = xInitial + i * Xdistance;
                for (int j = 0; j < GridY; j++)
                {
                    float yPos = yInitial + j * Ydistance;
                    GameObject obj = Instantiate(HookPrefab, ParentForDots.transform);
                    Hooks.Add(obj);
                    obj.transform.position = new Vector3(xPos, yPos);                    
                }
            }

        }


    }
}
