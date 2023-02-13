using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Duelos")]
    public int amountWin;
    public GameObject[] imgSkill;

    public string[] skills;
    public GameObject[] slots;

    public PlayerController player;
    public GameObject selectTarget;

    public void attack(string type)
    {
        foreach(string skill in skills)
        {
            if(skill == type)
            {
                print("habilidad:" + skill);
            }
        }
    }

    
    public void SelectTarget(GameObject target)
    {
        selectTarget = target;
    }

    public void UnselectTarget()
    {
        selectTarget = null;
    }


}
