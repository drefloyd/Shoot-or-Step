using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;

    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject topWall;
    public GameObject bottomWall;

    private void Awake()
    {
        Destroy(gameObject, life);  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //BH if the bullet hits a player, destroy the player and the bullet. Otherwise the bullet will bounce until its timer runs out
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        //else
        //{
        //    Destroy(collision.gameObject);
        //    //Destroy(gameObject);
        //}
    }
}
