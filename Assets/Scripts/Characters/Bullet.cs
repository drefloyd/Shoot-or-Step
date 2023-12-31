using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Xml.Linq;
using UnityEngine;
using Unity.VisualScripting;

public class Bullet : MonoBehaviour
{
    public float life = 5;

    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject topWall;
    public GameObject bottomWall;
    
    private string outerWallsName = "OutofBoundsWalls";

    AudioManager audioManager;

    private void Awake()
    {
        Destroy(gameObject, life);
        gameObject.layer = 7;
        audioManager=GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //BH if the bullet hits a player, destroy the player and the bullet. Otherwise the bullet will bounce until its timer runs out
        if (collision.gameObject.CompareTag("Player1"))
        {
            Destroy(gameObject);

            GameObject audioObject = GameObject.Find(outerWallsName);
            audioManager.PlaySFX(audioManager.takeDamage);

            Tuple<int, int> gridXY = numberGenerator();

            while(CheckRespawnCollision(gridXY) == true)
            {
                gridXY = numberGenerator();
            }

            GameObject player1 = GameObject.FindWithTag("Player1");
            player1.GetComponent<Health>().TakeDamage(25);
            
            Respawn(collision.gameObject, gridXY);
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            Destroy(gameObject);
           
            GameObject audioObject = GameObject.Find(outerWallsName);
            audioManager.PlaySFX(audioManager.takeDamage);


            Tuple<int, int> gridXY = numberGenerator();

            while (CheckRespawnCollision(gridXY) == true)
            {
                gridXY = numberGenerator();
            }

            GameObject player2 = GameObject.FindWithTag("Player2");
            player2.GetComponent<Health>().TakeDamage(25);
            
            Respawn(collision.gameObject, gridXY);
        }
        else
        {
            GameObject audioObject = GameObject.Find(outerWallsName);
            audioManager.PlaySFX(audioManager.bullet);
        }
    }

    //BH check to make sure that the randomly selected respawn location is not on top of a player or a wall
    private bool CheckRespawnCollision(Tuple<int, int> gridXY)
    {
        Vector3 shotPlayerRespawnPosition = new Vector3(gridXY.Item1, gridXY.Item2, 0);
        bool collision = false;
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        //BH loop through all game objects. This is probably inefficient but the game is simple enough it shouldn't matter. Ideally would keep a running list of collidable objects. Maybe you can return that with LINQ?
        foreach (GameObject go in allObjects)
        {
            if (go.activeInHierarchy && (go.CompareTag("Player1") || go.CompareTag("Player2") || go.CompareTag("Wall")))
            {
                //BH check to make sure the object has a collider
                if (go.GetComponent<Collider2D>() != null)
                {
                    //BH get the distance between the player's respawn point and any other player or wall object
                    Bounds objectBoundary = go.GetComponent<Collider2D>().bounds;
                    float distance = Vector3.Distance(shotPlayerRespawnPosition, objectBoundary.center);
                    if (distance < 2)
                    {
                        collision = true;
                        break;
                    }
                }
            }
        }
        return collision;    
    }

    //BH generate a random position on the grid board
    public Tuple<int, int> numberGenerator()
    {
        System.Random rnd = new System.Random();

        int numberRolldedX = rnd.Next(1, 12);
        int numberRolldedY = rnd.Next(1, 12);

        return new Tuple<int, int>(numberRolldedX, numberRolldedY);
    }

    //BH move the shot player to the determined position
    public void Respawn(GameObject shotPlayer, Tuple<int, int> gridXY)
    {

        shotPlayer.transform.position = new Vector3(gridXY.Item1, gridXY.Item2, 0);

    }
   
}
