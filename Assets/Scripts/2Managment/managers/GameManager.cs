using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] panelsHide;
    public enum gameState { menu, play, pause }
    public gameState state;
    public AudioSource sound;
    Player player = new();

    public DataCard[] _skills;

    private void Start()
    {
        foreach (GameObject showPanel in panelsHide)
        {
            showPanel.SetActive(false);
        }
    }
    virtual public void ChangeScene(string scene)
    {
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
        yield return new WaitForSeconds(3);
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
