using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPoint;
    public bool isCreate;

    private void OnMouseDown()
    {
        if (isCreate) return;
        else {
            Instantiate(player, spawnPoint.position, spawnPoint.rotation, spawnPoint);
            isCreate = true;
        }
    }
}
