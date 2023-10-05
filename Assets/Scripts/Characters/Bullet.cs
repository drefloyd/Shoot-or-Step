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
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
