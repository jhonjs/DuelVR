using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GameController : NetworkBehaviour
{
    [Header("Player")]
    public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();
    public GameObject player;
    public Transform spawnPoint;
    public bool isCreate;

    [Header("Duelos")]
    public int amountWin;

    public override void OnNetworkSpawn()
    {
        if (IsOwner) {
            if (NetworkManager.Singleton.IsServer)
            {
                Position.Value = spawnPoint.position;
            }
            Position.Value = spawnPoint.position;
        }
    }
    private void OnMouseDown()
    {
        if (isCreate) return;
        else {
            Instantiate(player, spawnPoint.position, spawnPoint.rotation, spawnPoint);
            isCreate = true;
        }
    }
}
