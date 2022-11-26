using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : GameManager
{
    //[Range(0, 1)] public float volume;
     public static Settings settings;

    private void Awake()
    {
        if (settings != null) Destroy(this);
        else DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        sound.Play();
    }
    public void volume(float volume)
    {
        sound.volume = volume;
    }

    override public void Exit()
    {
        sound.Stop();
    }
}
