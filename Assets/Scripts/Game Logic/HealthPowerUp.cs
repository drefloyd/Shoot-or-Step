using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthPowerUp : MonoBehaviour
{
    private string outerWallsName = "OutofBoundsWalls";

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            GameObject player1 = GameObject.FindWithTag("Player1");
            if (player1.GetComponent<Health>().currentHealth < 100)
            {
                GameObject audioObject = GameObject.Find(outerWallsName);
                AudioSource audiosource = audioObject.GetComponent<AudioSource>();
                AudioClip clip = Resources.Load<AudioClip>("powerupPickupSound");
                audiosource.PlayOneShot(clip, 25);
                Destroy(gameObject);
                player1.GetComponent<Health>().AddHealth(25);
            }
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            GameObject player2 = GameObject.FindWithTag("Player2");

            if (player2.GetComponent<Health>().currentHealth < 100)
            {
                GameObject audioObject = GameObject.Find(outerWallsName);
                AudioSource audiosource = audioObject.GetComponent<AudioSource>();
                AudioClip clip = Resources.Load<AudioClip>("powerupPickupSound");
                audiosource.PlayOneShot(clip, 25);
                Destroy(gameObject);
                player2.GetComponent<Health>().AddHealth(25);
            }
        }
    }
}
