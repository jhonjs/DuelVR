using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerVR : MonoBehaviour
{
    public enum StateGame
    {
        none,
        kinemat,
        pause,
        play,
        lose,
        win
    }
    public StateGame state;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            state = StateGame.pause;
        }
    }

    public void GetState()
    {

    }
}
