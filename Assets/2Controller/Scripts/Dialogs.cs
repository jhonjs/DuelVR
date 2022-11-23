using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogs : MonoBehaviour
{
    public string[] messages;

    public TextMeshProUGUI tmp;
    private int pos = 0;

    public GameObject panelResp;

    public GameObject pnlWin;
    public GameObject pnlLose;

    public GameManagerVR gmVR;
    public GameObject useHabilitiesBox;

    private void Start()
    {
        tmp.text = messages[pos];
        panelResp.transform.localScale = new Vector3(0, 0, 0);
    }
    private void FixedUpdate()
    {
        if(pnlLose.activeSelf || pnlWin.activeSelf)
            transform.localScale = new Vector3(0, 0, 0);

        if(gmVR.state == GameManagerVR.StateGame.kinemat)
        {
            useHabilitiesBox.SetActive(false);
        }else if (gmVR.state == GameManagerVR.StateGame.play)
        {
            useHabilitiesBox.SetActive(true);
        }
    }
    public void NextMessage()
    {
        pos++;
        if (pos >= messages.Length)
        {
            panelResp.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (pos == messages.Length)
        {
            panelResp.transform.localScale = new Vector3(0, 0, 0);
        }
        else tmp.text = messages[pos];

    }
    public void RespuestaBuena()
    {
        print("Esta bien, amigo mio ");
        //pnlWin.SetActive(true);
        gmVR.state = GameManagerVR.StateGame.play;
        panelResp.SetActive(false);
    }
    public void RespuestaMala()
    {
        print("OK, me retiro, no me arriesgare");
        pnlLose.SetActive(true);
    }
}
