using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    [Header("Battle System")]
    private BattleManager battleManager;
    public GameObject markerSelect;
    
    private void Awake()
    {
        battleManager = FindObjectOfType<BattleManager>();
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        if (battleManager.enemyActive != gameObject && battleManager.enemyActive != null)
        {
            battleManager.EnemyUnSelect();
        }
        EnemySelect();
        battleManager.EnemySelect(gameObject);
    }

    public void EnemySelect()
    {
        markerSelect.SetActive(true);
    }

    public void EnemyUnSelect()
    {
        markerSelect.SetActive(false);
    }

    public void SetAnimationOnTrigger(string name)
    {
        animator.SetTrigger(name);
    }
}
