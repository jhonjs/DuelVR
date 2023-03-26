using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using TMPro;
using Photon.Pun;
public class PlayerController : MonoBehaviourPun, IPunObservable
{
    public string playerName;

    [SerializeField] private Camera _camera;

    [Header("Battle System")]
    public BattleManager battleManager;
    public GameObject markerSelect;
    public bool attackState;

    public Animator animator;
    public GameObject enemy;

    #region cards
    [Header("Attack Cards")]
    public int amountCard = 4;
    public int amountSkills;
    private TextMeshProUGUI txtAmountCard;
    public GameObject cardPanel;
    public bool show;

    private List<DataCard> skills;
    public GameObject folderSkill;
    public GameObject activator;
    #endregion
    
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
        txtAmountCard = FindObjectOfType<CardController>().txtAmoutCards;
        cardPanel = FindObjectOfType<CardController>().cardPanel;

        if (photonView.IsMine) _camera.gameObject.SetActive(true);
    }

    private void Update()
    {
        if(enemy == null)
        {
            foreach (var _player in GameObject.FindGameObjectsWithTag("Player"))
            {
                if (!photonView.IsMine)
                {
                    enemy = _player;
                    battleManager.GetEnemy(enemy.GetComponent<EnemyController>().animator);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.M) && photonView.IsMine)
        {
            animator.SetTrigger("attack");
        }
    }

    public void AddDamage()
    {
        battleManager.AddDamage();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else if (stream.IsReading)
        {
            transform.position = (Vector3) stream.ReceiveNext();
            transform.rotation = (Quaternion) stream.ReceiveNext();
        }
    }
}
