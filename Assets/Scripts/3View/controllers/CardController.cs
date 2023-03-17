using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public GameObject cardPanel;
    public bool show;

    public void showPanel()
    {
        show = !show;
        cardPanel.SetActive(show);
    }
}
