using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionController : MonoBehaviour
{
    public GameManager gameManager;
    public void Login()
    {
        FormManager form = GetComponent<FormManager>();
        Player player = new Player(name: form.txtName.text, age: int.Parse(form.txtAge.text));
        PlayerPrefs.SetString("player", JsonUtility.ToJson(player));

        gameManager.ChangeScene("subMenu");
    }

    public void LogOut()
    {
        ///Enviar datos de estudio
    }
}
