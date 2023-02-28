using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using TMPro;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tmp;
    public RoomInfo _roomInfo { get; private set; }
    public void SetRoomInfo(RoomInfo roomInfo)
    {
        _roomInfo = roomInfo;
        tmp.text = roomInfo.MaxPlayers + "," + roomInfo.Name;
    }
}
