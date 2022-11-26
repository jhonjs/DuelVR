using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum gameState { menu, play, pause }
    public gameState state;
    public AudioSource sound;
   

    public void ChangeScene (string scene)
    {
        StartCoroutine("ChangeSceneTimeOut", scene);
        
    }
    public void PlaySound(AudioSource sound)
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
}
