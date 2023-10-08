using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public healthBar healthBar;
    // Start is called before the first frame update
    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth<=0)
        {
            SceneManager.LoadSceneAsync(2);
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
