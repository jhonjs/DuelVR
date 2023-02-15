using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using TMPro;

public class PlayerController : MonoBehaviour
{
   // private Player player;
    public string playerName;

    [Header("Battle System")]
    public BattleManager battleManager;
    public GameObject markerSelect;

    [Header("Actions Player")]
    public GameObject folderButtons;
    public GameObject[] actions;
    /*public GameObject action;*/

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
        battleManager.GetAnimator(animator);
        skills = new List<DataCard>();
        txtAmountCard.text = amountCard.ToString("");
        cardPanel.SetActive(false);

        var player = JObject.Parse(PlayerPrefs.GetString("player"));
        amountSkills = int.Parse(player.SelectToken("amountSkills").ToString());

        //print(string.Join(",", player.SelectToken("skills")));
        for (int i = 0; i < amountSkills; i++)
        {
            skills.Add(FindObjectOfType<GameManager>().getSkill(player.SelectToken("skills")[i].ToString()));
        }

        foreach (var key in skills)
        {
            var sk = Instantiate(activator, folderSkill.transform);
            var gm = FindObjectOfType<GameController>();

            sk.GetComponent<Image>().sprite = key.sprite;
            sk.GetComponent<Button>().onClick.AddListener(() => battleManager.Attack(key.key));

        }

    }
    private void Init()
    {
        battleManager = FindObjectOfType<BattleManager>();
        print(battleManager);
        animator = GetComponentInChildren<Animator>();
        actions = new GameObject[4];

        foreach (var _player in GameObject.FindGameObjectsWithTag("Player"))
        {//players.Add(_player);
            if (_player != gameObject) enemy = _player;
        }

        Skill skill = new();

        skill._name = "cut";

        /*print($"El objeto mencionado es {JsonUtility.ToJson(player)}");

        for(int i = 0; i < folderButtons.GetComponentsInChildren<GameObject>().Length; i++)
        {
            actions[i] = folderButtons.GetComponentsInChildren<GameObject>()[i];
        }
        player = gameObject.AddComponent<Player>();
        player.id += 1; 
        player.name = playerName;*/
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            animator.SetTrigger("attack");
        }
    }

    public void AddDamage()
    {
        enemy.GetComponent<EnemyController>().SetAnimationOnTrigger("damage");
    }

}
