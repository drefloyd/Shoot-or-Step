using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
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
            bool respawnCollision = true;
            Tuple<int, int> gridXY = numberGenerator();
            while(CheckRespawnCollision(collision.gameObject, gridXY) == true)
            {
                gridXY = numberGenerator();
            }
            Respawn(collision.gameObject, gridXY);
        }
        //else
        //{
        //    Destroy(collision.gameObject);
        //    //Destroy(gameObject);
        //}
    }

    private bool CheckRespawnCollision(GameObject shotPlayer, Tuple<int, int> gridXY)
    {
        Vector3 shotPlayerRespawnPosition = new Vector3(gridXY.Item1, gridXY.Item2, 0);
        bool collision = false;
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            if (go.activeInHierarchy && (go.CompareTag("Player") || go.CompareTag("Wall")))
            {
                if (go.GetComponent<Collider2D>() != null)
                {
                    Bounds objectBoundary = go.GetComponent<Collider2D>().bounds;
                    float distance = Vector3.Distance(shotPlayerRespawnPosition, objectBoundary.center);
                    if (distance < 1)
                    {
                        collision = true;
                        break;
                    }
                }
            }
        }
        return collision;    


        //        Bounds bound = shotPlayer.GetComponent<Collider2D>().bounds;
        //var variable = shotPlayer.GetComponent<Collider2D>().
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
        
        //if (shotPlayer.collider.bounds.Contains(telePosition))//hittotest is the wall
        //{
        //    print("point is inside collider");
        //}


        shotPlayer.transform.position = new Vector3(gridXY.Item1, gridXY.Item2, 0);
    }
}
