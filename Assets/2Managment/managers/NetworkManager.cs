using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public Transform spawnPoint;
    public Transform viewPoint;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    private void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        print("Connected Succesfully");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 2 }, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {

        PhotonNetwork.Instantiate("Player", new Vector3(0, 0, Random.Range(-4, 4)), Quaternion.identity);
    }
}
