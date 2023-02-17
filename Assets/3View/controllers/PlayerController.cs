using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public string playerName;

    [Header("Battle System")]
    public BattleManager battleManager;
    public GameObject markerSelect;

    public Animator animator;
    public GameObject enemy;

    [Header("Attack Cards")]
    public int amountCard = 4;
    public int amountSkills;
    public TextMeshProUGUI txtAmountCard;
    public GameObject cardPanel;
    public bool show;

    private List<DataCard> skills;
    public GameObject folderSkill;
    public GameObject activator;
    private void Awake()
    {
        Init();
    }
    private void Start()
    {   
        skills = new List<DataCard>();
        txtAmountCard.text = amountCard.ToString("");
        cardPanel.SetActive(false);

        var player = JObject.Parse(PlayerPrefs.GetString("player"));
        amountSkills = int.Parse(player.SelectToken("amountSkills").ToString());
        
        for (int i = 0; i < amountSkills; i++)
        {
            skills.Add(FindObjectOfType<GameManager>().getSkill(player.SelectToken("skills")[i].ToString()));
        }

        foreach (var key in skills)
        {
            var sk = Instantiate(activator, folderSkill.transform);
            var gm = FindObjectOfType<GameController>();

            sk.GetComponent<Image>().sprite = key.sprite;
            sk.GetComponent<Button>().onClick.AddListener(() => battleManager.Attack(key.key, animator));

        }

    }
    private void Init()
    {
        battleManager = FindObjectOfType<BattleManager>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if(enemy == null)
        {
            foreach (var _player in GameObject.FindGameObjectsWithTag("Player"))
            {
                if (_player != gameObject)
                {
                    enemy = _player;
                    battleManager.GetEnemy(enemy.GetComponent<EnemyController>().animator);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            animator.SetTrigger("attack");
        }
    }

    public void AddDamage()
    {
        battleManager.AddDamage();
    }

}
