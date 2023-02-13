using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
public class GameManager : MonoBehaviour
{
    public enum gameState { menu, play, pause }
    public gameState state;
    public AudioSource sound;
    Player player = new();

    public DataCard[] _skills;
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

        if(!player.skills.Contains(skill))player.skills.Add(skill);

        player.amountSkills = player.skills.Count;

        PlayerPrefs.SetString("player", JsonUtility.ToJson(player)); 
    }

    public void addPlayerSkill2(string skill)
    {
        var playerMaster = JObject.Parse(PlayerPrefs.GetString("player"));

        player.id = (int)playerMaster.SelectToken("id");
        player._name = playerMaster.SelectToken("_name").ToString();
        player._age = (int)playerMaster.SelectToken("_age");

        player.skills2.Add(skill);

        print($"addPlayerSkill2: {JsonUtility.ToJson(player)}");

        PlayerPrefs.SetString("player", JsonUtility.ToJson(player));

        /*var mock = JObject.Parse(PlayerPrefs.GetString("player"));
         *print($"{ JsonConvert.DeserializeObject(PlayerPrefs.GetString("player"))}");*/
    }

    public void setSkills(string name)
    {
        Skill skill = new();

        skill.skillId += 10;
        skill._name = name;
        skill.userID = (int) JObject.Parse(PlayerPrefs.GetString("player")).SelectToken("id");
        switch (name)
        {
            case "cut":
                skill.damage = 10;
                break;
            case "copy":
                skill.damage = 15;
                break;
            case "paste":
                skill.damage = 20;
                break;
            case "close":
                skill.damage = 25;
                break;
            case "open":
                skill.damage = 30;
                break;
        }
        var persever = JsonUtility.ToJson(skill);
        //var persever2 = JsonConvert.SerializeObject(skill);
        addPlayerSkill2(persever);
    }
}
