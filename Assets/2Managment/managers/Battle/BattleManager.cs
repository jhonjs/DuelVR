using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject playerActive;
    public GameObject enemyActive;

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

}