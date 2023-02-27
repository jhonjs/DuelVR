using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public Transform spawnPoint;
    public Transform viewPoint;

    public TMP_InputField _roomName;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void OnClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected) return;
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 2;
        print(_roomName.text);
        PhotonNetwork.JoinOrCreateRoom(_roomName.text, options, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        print("CONNECTED SUCCESFULLY");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print($"Room created filed, {message}");
    }
    public override void OnConnectedToMaster()
    {
        print("Connected Succesfully");
        PhotonNetwork.JoinLobby();
    }

    /*    public override void OnJoinedLobby()
        {
            PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 2 }, TypedLobby.Default);
        }

        public override void OnJoinedRoom()
        {
            PhotonNetwork.Instantiate("Player", new Vector3(0, 0, Random.Range(-4, 4)), Quaternion.identity);
        }*/
}
