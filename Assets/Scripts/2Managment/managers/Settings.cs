using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    //[Range(0, 1)] public float volume;
    public MenuManger menuManger;
    public static Settings settings;
    public AudioSource currentSound;

    private void Awake()
    {
        if (settings != null) Destroy(this);
        else DontDestroyOnLoad(gameObject);
        menuManger = FindObjectOfType<MenuManger>();
    }
    private void Start()
    {
        currentSound = menuManger.sound;
        currentSound.Play();
    }
    public void volume(float volume)
    {
        currentSound.volume = volume;
    }

}
