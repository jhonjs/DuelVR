using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FormManager : MonoBehaviour
{
    private string _name;
    private int _age;
    public TMP_InputField txtName;
    public TMP_InputField txtAge;
    public Button btnPlay;

    private void Update()
    {
        onChange();
    }
    public void onChange()
    {
        if (txtName.text == "" || validateNumber(txtAge.text) == 0) btnPlay.interactable = false;
        else btnPlay.interactable = true;
    }
    private int validateNumber(string value)
    {
        bool isNumber = int.TryParse(value, out _age);
        if (isNumber) return _age;
        else
        {
            txtAge.text = "";
            return 0;
        }
    }
}
