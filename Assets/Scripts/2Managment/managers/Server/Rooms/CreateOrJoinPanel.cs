using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinPanel : MonoBehaviour
{
    [SerializeField] private CreateRoomMenu _createRoomMenu;
    [SerializeField] private RoomListingsMenu _roomListingMenu;
    private RoomPanels _roomPanels;
    public void FirstInitialize(RoomPanels panels)
    {
        _roomPanels = panels;
        _createRoomMenu.FirstInitialize(panels);
        _roomListingMenu.FirstInitialize(panels);
    }
}
