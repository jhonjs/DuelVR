using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject playerActive;
    public GameObject enemyActive;
    private Animator anim;

    public void PlayerSelect(GameObject target){
        playerActive = target;
    }

    public void PlayerUnSelect()
    {
        //playerActive.GetComponent<PlayerController>().PlayerUnSelect();
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
    }

    public void GetAnimator(Animator animator)
    {
        print(anim);
        anim = animator;
    }
    public void Attack(string name)
    {
        print($"cut {anim}");
        anim.SetTrigger("attack");
    }
}
