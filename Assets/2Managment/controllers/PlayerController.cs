using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
   // private Player player;
    public GameObject[] skills;
    public string playerName;

    [Header("Battle System")]
    private BattleManager battleManager;
    public GameObject markerSelect;

    [Header("Actions Player")]
    public GameObject folderButtons;
    public GameObject[] actions;
    /*public GameObject action;*/

    public Animator anim;
    public GameObject enemy;

    private void Init()
    {
        battleManager = FindObjectOfType<BattleManager>();
        anim = GetComponent<Animator>();
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
    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            anim.SetTrigger("attack");
        }
    }

    public void AddDamage()
    {
        enemy.GetComponent<EnemyController>().SetAnimationOnTrigger("damage");
    }

}
