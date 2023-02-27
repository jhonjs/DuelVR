using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviour
{
    public MonoBehaviour[] ignoreScripts;
    private PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine)
        {
            foreach(var script in ignoreScripts)
            {
                script.enabled = false;
            }
        }
        else {
            FindObjectOfType<PlayerController>().attackState = true;
        }
    }
}
