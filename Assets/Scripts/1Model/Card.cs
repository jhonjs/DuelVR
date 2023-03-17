using UnityEngine;

public class Card : MonoBehaviour
{
    private int _amount { get; set; }
    private string _name { get; set; }
    private string _description { get; set; }

    public Card (int amount, string name, string description)
    {
        _amount = amount;
        _name = name;
        _description = description;
    }

}
