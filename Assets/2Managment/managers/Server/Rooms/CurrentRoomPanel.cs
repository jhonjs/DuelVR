using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoomPanel : MonoBehaviour
{
    [SerializeField] private PlayerListingsMenu _playerListingMenu;
    [SerializeField] private LeaveRoomMenu _leaveRoomMenu; 

    private RoomPanels _roomPanels;
    public void FirstInitialize(RoomPanels panels)
    {
        _roomPanels = panels;
        _playerListingMenu.FirstInitialize(panels);
        _leaveRoomMenu.FirstInizilize(panels);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
