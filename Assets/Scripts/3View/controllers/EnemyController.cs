using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemyController : MonoBehaviourPun, IPunObservable
{
    public Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else if (stream.IsReading)
        {
            transform.position = (Vector3)stream.ReceiveNext();
            transform.rotation = (Quaternion)stream.ReceiveNext();
        }
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