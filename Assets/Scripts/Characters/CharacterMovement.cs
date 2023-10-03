using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
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
                    if (player.transform.rotation.z != 180)
                    {
                        player.transform.rotation = Quaternion.Euler(0, 0, 180); // Face west
                    }
                    else
                    {
                        Vector3 currentPos = player.transform.position;
                        player.transform.position = new Vector3(currentPos.x - 1, currentPos.y, currentPos.z);
                    }
                    this.direction = ShootingDirection.West;
                    BulletSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, 180); // Face west
                    --DiceRoll.numMoves;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (player.transform.rotation.z != 0)
                    {
                        player.transform.rotation = Quaternion.Euler(0, 0, 0); // Face east
                    }
                    else{
                        Vector3 currentPos = player.transform.position;
                        player.transform.position = new Vector3(currentPos.x + 1, currentPos.y, currentPos.z);
                    }
                    this.direction = ShootingDirection.East;
                    BulletSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, 0); // Face east
                    --DiceRoll.numMoves;
                }

                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (player.transform.rotation.z != 270)
                    {
                        player.transform.rotation = Quaternion.Euler(0, 0, 270); // Face south
                    }
                    else
                    {
                        Vector3 currentPos = player.transform.position;
                        player.transform.position = new Vector3(currentPos.x, currentPos.y - 1, currentPos.z);
                    }
                    this.direction = ShootingDirection.East;
                    BulletSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, 270); // Face south
                    --DiceRoll.numMoves;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (player.transform.rotation.z != 90)
                    {
                        player.transform.rotation = Quaternion.Euler(0, 0, 90); // Face north
                    }
                    else
                    {
                        Vector3 currentPos = player.transform.position;
                        player.transform.position = new Vector3(currentPos.x, currentPos.y + 1, currentPos.z);
                    }
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
                    if (player.transform.rotation.z != 0)
                    {
                        player.transform.rotation = Quaternion.Euler(0, 0, 0); // Face west
                    }
                    else
                    {
                        Vector3 currentPos = player.transform.position;
                        player.transform.position = new Vector3(currentPos.x - 1, currentPos.y, currentPos.z);
                    }
                    this.direction = ShootingDirection.West;
                    BulletSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, 0); // Face west
                    --DiceRoll.numMoves;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (player.transform.rotation.z != 180)
                    {
                        player.transform.rotation = Quaternion.Euler(0, 0, 180); // Face east
                    }
                    else
                    {
                        Vector3 currentPos = player.transform.position;
                        player.transform.position = new Vector3(currentPos.x + 1, currentPos.y, currentPos.z);
                    }
                    this.direction = ShootingDirection.East;
                    BulletSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, 180);
                    --DiceRoll.numMoves;
                }

                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (player.transform.rotation.z != 90)
                    {
                        player.transform.rotation = Quaternion.Euler(0, 0, 90); // Face south
                    }
                    else
                    {
                        Vector3 currentPos = player.transform.position;
                        player.transform.position = new Vector3(currentPos.x, currentPos.y - 1, currentPos.z);
                    }
                    this.direction = ShootingDirection.East;
                    BulletSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, 90); // Face south
                    --DiceRoll.numMoves;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (player.transform.rotation.z != 270)
                    {
                        player.transform.rotation = Quaternion.Euler(0, 0, 270); // Face north
                    }
                    else
                    {
                        Vector3 currentPos = player.transform.position;
                        player.transform.position = new Vector3(currentPos.x, currentPos.y + 1, currentPos.z);
                    }
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
