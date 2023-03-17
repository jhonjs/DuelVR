using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LeaveRoomMenu : MonoBehaviour
{
    private RoomPanels _roomPanels;
    public void FirstInizilize(RoomPanels panels)
    {
        _roomPanels = panels;
    }

    public void OnClick_LeaveRoom ()
    {
        PhotonNetwork.LeaveRoom(true);
        _roomPanels.CurrentRoomPanel.Hide();
    }

}
