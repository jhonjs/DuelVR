using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManger : GameManager
{
    public override void Exit()
    {
        base.Exit();
        sound.Stop();
    }
}
