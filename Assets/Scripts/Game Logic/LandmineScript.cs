using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmineScript : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            GameObject player1 = GameObject.FindWithTag("Player1");
            Destroy(gameObject);
            player1.GetComponent<Health>().TakeDamage(20);
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            GameObject player2 = GameObject.FindWithTag("Player2");
                Destroy(gameObject);
                player2.GetComponent<Health>().TakeDamage(20);
            }
        }
    }
