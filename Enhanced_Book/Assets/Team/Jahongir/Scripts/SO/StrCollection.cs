using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "StrCollection", menuName = "ScriptableObjects/StrCollection", order = 3)]
public class StrCollection : ScriptableObject
{
    public List<string> StrGroup = new List<string>();
}
