using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;
using Photon.Pun;

public class CardController : MonoBehaviour
{
    public GameObject cardPanel;
    public TextMeshProUGUI txtAmoutCards;
    public bool show;

    public void showPanel()
    {
        show = !show;
        cardPanel.SetActive(show);
    }
}
