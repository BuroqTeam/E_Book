using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game2_TwoPlayer
{
    public class GameManage : MonoBehaviour
    {

        List<string> Questions_1 = new()
        {
            $"To'g'ri burchakli uchburchak yasang.",  
            $"Perimetri {n1} cm ga teng bo'lgan kvadrat yasang.",
            $"Teng yonli to'g'ri burchakli uchburchak yasang.", 
            $"Perimetri {n3} cm ga teng bo'lgan to'rtburchakni yasang.",
            $"Turli tomonli uchburchakni yasang."
        };
        const int n0 = 12, n1 = 16, n2 = 8, n3 = 14, n4 = 5;

        List<string> Questions_2 = new()
        {
            $"To'g'ri burchakli uchburchak yasang.",
            $"Perimetri {n6} cm ga teng bo'lgan kvadrat yasang.",
            $"Teng yonli to'g'ri burchakli uchburchak yasang.",
            $"Perimetri {n8} cm ga teng bo'lgan to'rtburchakni yasang.",
            $"Turli tomonli uchburchakni yasang."
        };
        const int n5 = 0, n6 = 12, n7 = 0, n8 = 0, n9 = 0;


        void Start()
        {

        }

        
        void Update()
        {

        }
    }
}
