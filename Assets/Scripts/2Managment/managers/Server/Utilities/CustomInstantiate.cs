using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CustomInstantiate : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform first;
    [SerializeField] private Transform second;

    private void Awake()
    {
        Vector3 position = new Vector3(0, 0, Random.Range(-4, 4));

        var instance = MasterManager.NetworkInstantiate(_prefab,  position, Quaternion.identity);

        if(!instance.GetComponent<PhotonView>().Owner.IsMasterClient)
        {   instance.transform.SetParent(second);
            instance.transform.position = second.position;
        }
        else
        {
            instance.transform.SetParent(first);
            instance.transform.position = first.position;
            instance.transform.rotation = first.rotation;
        }
    }

}
