using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPanels : MonoBehaviour
{
    [SerializeField] private CreateOrJoinPanel _createOrJoinPanel;
    public CreateOrJoinPanel CreateOrJoinPanel { get { return _createOrJoinPanel; } }

    [SerializeField] private CurrentRoomPanel _currentRoomPanel;
    public CurrentRoomPanel CurrentRoomPanel { get { return _currentRoomPanel; } }

    private void Awake()
    {
        FirstInitialice();
    }
    private void FirstInitialice()
    {
        CreateOrJoinPanel.FirstInitialize(this);
        CurrentRoomPanel.FirstInitialize(this);
    }

}
