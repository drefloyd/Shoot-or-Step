using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LandmineScript : MonoBehaviour
{
    private string outerWallsName = "OutofBoundsWalls";
    
    public GameObject explosionObject;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager=GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            GameObject player1 = GameObject.FindWithTag("Player1");
            GameObject audioObject = GameObject.Find(outerWallsName);
            audioManager.PlaySFX(audioManager.explosion);
            Instantiate(explosionObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
            player1.GetComponent<Health>().TakeDamage(25);
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            GameObject player2 = GameObject.FindWithTag("Player2");
            GameObject audioObject = GameObject.Find(outerWallsName);
            audioManager.PlaySFX(audioManager.explosion);
            Instantiate(explosionObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
            player2.GetComponent<Health>().TakeDamage(25);
            }
        }
    }
