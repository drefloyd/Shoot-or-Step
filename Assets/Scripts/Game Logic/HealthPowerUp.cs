using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthPowerUp : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            GameObject player1 = GameObject.FindWithTag("Player1");
            if (player1.GetComponent<Health>().currentHealth < 100)
            {
                Destroy(gameObject);
                player1.GetComponent<Health>().AddHealth(20);
            }
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            GameObject player2 = GameObject.FindWithTag("Player2");

            if (player2.GetComponent<Health>().currentHealth < 100)
            {
                Destroy(gameObject);
                player2.GetComponent<Health>().AddHealth(20);
            }
        }
    }
}
