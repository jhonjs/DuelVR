using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Persistence/Models", order = 5)]
public class DataCard : ScriptableObject
{
    public Sprite sprite;
    public string key;
    public string value;
    public enum TypeSkill {
        attack,
        trap,
        defence
    }
    public TypeSkill type;
    public float damage;
    [TextArea]
    public string description;
}
