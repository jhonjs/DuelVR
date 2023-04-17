using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillController : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] private TextMeshProUGUI amount;

    private void OnMouseDown()
    {
        gameManager.addPlayerSkill(name);
        Destroy(gameObject, 2);
    }
}
