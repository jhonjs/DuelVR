using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    /*private BattleManager battleManager;*/
    
    private void Awake()
    {
        //battleManager = FindObjectOfType<BattleManager>();
        animator = GetComponentInChildren<Animator>();
    }
}
#region oldcode_selectEnemy
/*    
    public GameObject markerSelect;
private void OnMouseDown()
    {
        if (battleManager.enemyActive != gameObject && battleManager.enemyActive != null)
        {
            battleManager.EnemyUnSelect();
        }
        EnemySelect();
        battleManager.EnemySelect(gameObject);
    }*/

/*    public void EnemySelect()
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
    }*/
#endregion