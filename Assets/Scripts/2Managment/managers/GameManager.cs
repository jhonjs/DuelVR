using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using TMPro;

public class GameManager : MonoBehaviour
{
    private string currentScene = "";
    [SerializeField] GameObject[] panelsHide;
    public enum gameState { menu, play, pause }
    public gameState state;

    public AudioSource sound;
    Player player = new();

    public DataCard[] _skills;
    
    [SerializeField] private TextMeshProUGUI txtAmountCards;
    [SerializeField] private GameObject panelWinner;
    [SerializeField] private GameObject folderCards;
    private int amountCards = 0;
    public int cardsPublished = 11;

    [SerializeField] private TextMeshProUGUI txtScore;
    [SerializeField] private TextMeshProUGUI txtTimer;
    private float score;
    private float time = 0;
    private bool endGame;


    private void Start()
    {
        foreach (GameObject showPanel in panelsHide)
        {
            showPanel.SetActive(false);
        }
        if(txtAmountCards != null) txtAmountCards.text = $"{amountCards}/{cardsPublished}";
        amountCards = 0;
        currentScene = SceneManager.GetActiveScene().name;
    }

    private void FixedUpdate()
    {
        if (currentScene == "World")
        {
            if(!endGame) time = Time.time;
            txtTimer.text = ((int) time ).ToString();

            if (time == 300)
            {
                score = ((100 / amountCards) * 4) - ((int)time / 4);
                txtScore.text = $"{(int) score}";
                panelWinner.SetActive(true);
            }
        }
    }

    virtual public void ChangeScene(string scene)
    {
        time = 0;
        StartCoroutine("ChangeSceneTimeOut", scene);
    }
    virtual public void PlaySound(AudioSource sound)
    {
        sound.Play();
    }
    virtual public void Exit()
    {
        Application.Quit();
        print("Juego finalizado!!!!");
    }
    IEnumerator ChangeSceneTimeOut(string scene)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }

    public DataCard getSkill(string name)
    {
        foreach(var skill in _skills)
        {
            if(skill.key == name)
            {
                return skill;
            }
        }
        return null;
    }

    public void addPlayerSkill(string skill)
    {
        var playerMaster = JObject.Parse(PlayerPrefs.GetString("player"));

        amountCards += 1;
        txtAmountCards.text = $"{amountCards}/{cardsPublished}";

        if (amountCards == cardsPublished)
        {
            score = 400 - ((int) time / 4);
            if (time < 30) score = 400;

            txtScore.text = $"{(int) score}";
            endGame = true;
            panelWinner.SetActive(true);
            folderCards.SetActive(false);
            return;
        }

        player.id = (int) playerMaster.SelectToken("id");
        player._name = playerMaster.SelectToken("_name").ToString();
        player._age = (int) playerMaster.SelectToken("_age");

        if(!player.skills.Contains(skill)) player.skills.Add(skill);
        player.amountSkills = player.skills.Count;

        PlayerPrefs.SetString("player", JsonUtility.ToJson(player)); 
    }

    public void OnEnabledPanel(GameObject panel)
    {
        foreach(GameObject showPanel in panelsHide)
        {
            showPanel.SetActive(false);
        }
        panel.SetActive(true);
    }
    public void OnDisabledPanel(GameObject panel)
    {
        panel.SetActive(false);
    }

}
