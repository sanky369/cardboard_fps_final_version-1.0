using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI score, health;
    public Player playerInfo;
    public PlayerHealth playerHealth;

    // Update is called once per frame
    void Update()
    {
        score.text = playerInfo.kills.ToString();
        health.text = playerHealth.currentHealth.ToString();
    }
}
