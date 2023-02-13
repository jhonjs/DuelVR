using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public int amountCard = 4;
    public int amountSkills;
    public TextMeshProUGUI txtAmountCard;
    public GameObject cardPanel;
    public bool show;

    private List<DataCard> skills;
    public GameObject folderSkill;
    public GameObject activator;
    
    void Start()
    {
        skills = new List<DataCard>();
        txtAmountCard.text = amountCard.ToString("");
        cardPanel.SetActive(false);
    }

    public void showPanel()
    {
        show = !show;

        cardPanel.SetActive(show);
        if (show)
        {
            var player = JObject.Parse(PlayerPrefs.GetString("player"));
            amountSkills = int.Parse(player.SelectToken("amountSkills").ToString());

            print(string.Join(",", player.SelectToken("skills")));
            for (int i = 0; i < amountSkills; i++)
            {
                skills.Add(FindObjectOfType<GameManager>().getSkill(player.SelectToken("skills")[i].ToString()));
            }

            foreach(var key in skills)
            {
                var sk = Instantiate(activator, folderSkill.transform);
                var gm = FindObjectOfType<GameController>();
                sk.GetComponent<Image>().sprite = key.sprite;
                sk.GetComponent<Button>().onClick.AddListener(() => gm.attack(key.key));
            }

        }

    }
}
