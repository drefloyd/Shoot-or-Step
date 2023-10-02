using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Shooting;

public class CharacterMovement : MonoBehaviour
{
    public GameObject player;

    public ShootingDirection direction = ShootingDirection.East;    //BH This is the initial direction p1 is facing
    public Transform BulletSpawnPoint;
    public GameObject BulletPrefab;
    public float BulletSpeed = 10;

    private void Update()
    {
        if (EndTurn.p1Turn == true)     // p1 and p2 have their own directions because all of p1's z values are the flipped versions of p2's
        {
            if (DiceRoll.numMoves > 0)
            {
                // Flip the sprite based on input

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 180); // Face west
                    this.direction = ShootingDirection.West;
                    BulletSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, 180); // Face west
                    --DiceRoll.numMoves;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 0); // Face east
                    this.direction = ShootingDirection.East;
                    BulletSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, 0); // Face east
                    --DiceRoll.numMoves;
                }

                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 270); // Face south
                    this.direction = ShootingDirection.East;
                    BulletSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, 270); // Face south
                    --DiceRoll.numMoves;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 90); // Face north
                    this.direction = ShootingDirection.East;
                    BulletSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, 90); // Face north
                    --DiceRoll.numMoves;
                }
                //BH Space bar to shoot for now. Should make this a button later
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    var bullet = Instantiate(BulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
                    if (this.direction == ShootingDirection.West)
                    {
                        bullet.GetComponent<Rigidbody2D>().velocity = BulletSpawnPoint.right * BulletSpeed;
                    }
                    else if (this.direction == ShootingDirection.East)
                    {
                        bullet.GetComponent<Rigidbody2D>().velocity = BulletSpawnPoint.right * BulletSpeed;
                    }
                    else if (this.direction == ShootingDirection.North)
                    {
                        bullet.GetComponent<Rigidbody2D>().velocity = BulletSpawnPoint.right * BulletSpeed;
                    }
                    else if (this.direction == ShootingDirection.South)
                    {
                        bullet.GetComponent<Rigidbody2D>().velocity = BulletSpawnPoint.right * BulletSpeed;
                    }
                    --DiceRoll.numMoves;
                }
            }
        }
        else
        {
            if (DiceRoll.numMoves > 0)
            {
                // Flip the sprite based on input

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 0); // Face west
                    this.direction = ShootingDirection.West;
                    BulletSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, 0); // Face west
                    --DiceRoll.numMoves;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 180); // Face east
                    this.direction = ShootingDirection.East;
                    BulletSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, 180);
                    --DiceRoll.numMoves;
                }

                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 90); // Face south
                    this.direction = ShootingDirection.East;
                    BulletSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, 90); // Face south
                    --DiceRoll.numMoves;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 270); // Face north
                    this.direction = ShootingDirection.East;
                    BulletSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, 270); // Face north
                    --DiceRoll.numMoves;
                }
                //BH Space bar to shoot for now. Should make this a button later
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    var bullet = Instantiate(BulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
                    if (this.direction == ShootingDirection.West)
                    {
                        bullet.GetComponent<Rigidbody2D>().velocity = -BulletSpawnPoint.right * BulletSpeed;
                    }
                    else if (this.direction == ShootingDirection.East)
                    {
                        bullet.GetComponent<Rigidbody2D>().velocity = -BulletSpawnPoint.right * BulletSpeed;
                    }
                    else if (this.direction == ShootingDirection.North)
                    {
                        bullet.GetComponent<Rigidbody2D>().velocity = -BulletSpawnPoint.right * BulletSpeed;
                    }
                    else if (this.direction == ShootingDirection.South)
                    {
                        bullet.GetComponent<Rigidbody2D>().velocity = -BulletSpawnPoint.right * BulletSpeed;
                    }
                    --DiceRoll.numMoves;
                }
            }
        }
    }
}
