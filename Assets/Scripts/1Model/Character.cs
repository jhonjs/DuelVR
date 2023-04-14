using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private string _name { get; set; }
    private float _strong { get; set; }
    
    public Character (string name, float strong)
    {
        _name = name;
        _strong = strong;
    }
}
