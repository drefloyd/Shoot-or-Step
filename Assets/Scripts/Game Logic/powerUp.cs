using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerUp : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public healthBar healthBar;
    public Button Power;
    // Start is called before the first frame update
    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        Button btn=Power.GetComponent<Button>();
        btn.onClick.AddListener(Update);
    }
    public void OnButttonClick()
    {
        TakeDamage(20);
    }
    // Update is called once per frame
    public void Update()
    {
       
         TakeDamage(20);
        
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
