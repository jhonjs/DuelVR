using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManger : GameManager
{
    [Header("Propiedades del Formulario")]
    private string _name;
    private int _age;
    public TMP_InputField txtName;
    public TMP_InputField txtAge;
    public Button btnPlay;
    public AudioSource mainSound;
    private void Start()
    {
        mainSound.Play();
    }
    private void Update()
    {
        formManager();
    }

    public void formManager()
    {
        if (txtName.text == "" || validateNumber(txtAge.text) == 0) btnPlay.interactable = false;
        else btnPlay.interactable = true;
    }

    private int validateNumber(string value)
    {
        bool isNumber = int.TryParse(value, out _age);
        if (isNumber) return _age;
        else {
            txtAge.text = "";
            return 0;
        }
    }
    public void Exit ()
    {
        mainSound.Stop();
        Application.Quit();
        print("Juego finalizado!!!!");
    }
}
