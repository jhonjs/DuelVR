using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardController : MonoBehaviour
{
    public int amountCard = 4;
    public TextMeshProUGUI txtAmountCard;
    public GameObject cardPanel;
    public bool show;
    void Start()
    {
        txtAmountCard.text = amountCard.ToString("");
        cardPanel.SetActive(false);
    }

    void Update()
    {
        
    }

    public void showPanel()
    {
        show = !show;
        cardPanel.SetActive(show);
    }
}
