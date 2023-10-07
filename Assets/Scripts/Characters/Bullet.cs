using System;
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
            //Destroy(collision.gameObject);
            Tuple<int, int> gridXY = numberGenerator();
            Respawn(collision.gameObject, gridXY);
        }
        //else
        //{
        //    Destroy(collision.gameObject);
        //    //Destroy(gameObject);
        //}
    }

    public Tuple<int, int> numberGenerator()
    {
        System.Random rnd = new System.Random();

        int numberRolldedX = rnd.Next(1, 12);
        int numberRolldedY = rnd.Next(1, 12);

        return new Tuple<int, int>(numberRolldedX, numberRolldedY);
    }

    public void Respawn(GameObject shotPlayer, Tuple<int, int> gridXY)
    {
        shotPlayer.transform.position = new Vector3(gridXY.Item1, gridXY.Item2, 0);
    }
}
