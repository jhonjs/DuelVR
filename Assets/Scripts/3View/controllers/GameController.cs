using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Duelos")]
    public int amountWin;

    public PlayerController player;
    public GameObject selectTarget;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
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
