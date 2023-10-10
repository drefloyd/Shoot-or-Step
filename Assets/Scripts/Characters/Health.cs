using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public healthBar healthBar;
    public string playerTag;

    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth<=0 && playerTag == "Player1")
        {
            SceneManager.LoadSceneAsync(2);     // load "Player 1 wins screen"
        }
        else if (currentHealth <= 0 && playerTag == "Player2")
        {
            SceneManager.LoadSceneAsync(2);     // load "Player 2 wins screen"
        }
    }
    public void AddHealth(int damage)
    {
        currentHealth += damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth>maxHealth)
        {
            currentHealth=maxHealth;
        }
    }
}
