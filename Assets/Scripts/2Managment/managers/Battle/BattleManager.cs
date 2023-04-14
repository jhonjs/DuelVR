using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public Animator animatorEnemy;

    public void GetEnemy(Animator enemy)
    {
        animatorEnemy = enemy;
    }

    public void Attack(string name, Animator animator)
    {
        animator.SetTrigger("attack");
    }

    public void AddDamage()
    {
        print(animatorEnemy);
        animatorEnemy.SetTrigger("damage");
    }
}
#region oldCodeSelcetEnemy
/*   
    public GameObject playerActive;
    public GameObject enemyActive;
    public void PlayerSelect(GameObject target){
        playerActive = target;
    }

    public void PlayerUnSelect()
    {
        playerActive = null;
    }

    public void EnemySelect(GameObject target)
    {
        enemyActive = target;
    }

    public void EnemyUnSelect()
    {
        enemyActive.GetComponent<EnemyController>().EnemyUnSelect();
        enemyActive = null;
    }*/
#endregion