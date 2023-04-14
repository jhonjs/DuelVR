using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform _content;
    [SerializeField] private RoomListing _roomListing;

    private List<RoomListing> _listings = new List<RoomListing>();
    private RoomPanels _roomPanels;

    public void FirstInitialize(RoomPanels panels)
    {
        _roomPanels = panels;
    }

    public override void OnJoinedRoom()
    {
        _roomPanels.CurrentRoomPanel.Show();
        _content.DestroyChildren();
        _listings.Clear();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
       foreach(RoomInfo info in roomList)
       {
            //remove from roomlist
            if (info.RemovedFromList)
            {
                int index = _listings.FindIndex(x => x._RoomInfo.Name == info.Name);
                if(index != -1)
                {
                    Destroy(_listings[index].gameObject);
                    _listings.RemoveAt(index);
                }
            }
            //add to roomlist
            else
            {
                int index = _listings.FindIndex(x => x._RoomInfo.Name == info.Name);
                if(index == -1)
                {
                    RoomListing listing = Instantiate(_roomListing, _content);
                    if(listing != null)
                    {
                        listing.SetRoomInfo(info);
                        _listings.Add(listing);
                    }
                }
                else
                {
                    //modify listing here
                }
            }
       }
    }
}
