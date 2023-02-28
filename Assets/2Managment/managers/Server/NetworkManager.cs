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

    public void OnClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected) return;
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 2;
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

}
