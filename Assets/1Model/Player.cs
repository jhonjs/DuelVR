using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    public int id;
    public string _name;
    public int _age;
    public int amountSkills;

    public List<string> skills = new List<string>();
    public List<string> skills2 = new List<string>();

    public Player(){}
    public Player(string name, int age)
    {
        id += 1;
        _name = name;
        _age = age;
    }
}
