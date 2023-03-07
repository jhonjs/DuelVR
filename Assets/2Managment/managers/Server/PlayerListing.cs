using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

using TMPro;

public class PlayerListing : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    private Photon.Realtime.Player _player { get; set; }

    public void SetPlayerInfo(Photon.Realtime.Player player)
    {
        _player = player;
        _text.text = player.NickName;
    }
}
