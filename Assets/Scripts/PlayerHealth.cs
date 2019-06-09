using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int totalHealth = 100;
    public int currentHealth;
    public bool isDead;
    public Player player;

    void OnEnable()
    {
        currentHealth = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {

        currentHealth -= amount;

        if(currentHealth <= 0 && !isDead)
        {
            isDead = true;
        }
    }
}
