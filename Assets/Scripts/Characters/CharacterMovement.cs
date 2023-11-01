using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using static Shooting;

public class CharacterMovement : MonoBehaviour
{
    public GameObject player;
    public ShootingDirection direction = ShootingDirection.East;    //BH This is the initial direction p1 is facing
    public Transform BulletSpawnPoint;
    public GameObject BulletPrefab;
    [SerializeField] public float BulletSpeed = 10;
    public Text playerDiceText;
    public BoxCollider2D playerBody;



    AudioManager audioManager;
    private void Awake()
    {
        audioManager=GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    private void Update()
    {
        if (EndTurn.p1Turn == true)     // p1 and p2 have their own directions because all of p1's z values are the flipped versions of p2's
        {
            if (DiceRoll.numMoves > 0)
            {
                // Flip the sprite based on input               
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (this.direction!=ShootingDirection.West)
                    {
                        player.transform.rotation = Quaternion.Euler(0, 0, 180); // Face west
                        --DiceRoll.numMoves;
                        playerDiceText.text = DiceRoll.numMoves.ToString();
                    }
                    else
                    {
                        Vector3 currentPos = player.transform.position;
                        //make sure they are within bounds
                        RaycastHit2D[] results = new RaycastHit2D[1];
                        if (playerBody.Cast(Vector2.left, results, 1) == 0 || (results[0].collider.CompareTag("PowerUp")))
                        {
                            player.transform.position = new Vector3(currentPos.x - 1, currentPos.y, currentPos.z);
                            --DiceRoll.numMoves;
                            playerDiceText.text = DiceRoll.numMoves.ToString();
                            audioManager.PlaySFX(audioManager.moveSound);

                        }
                    }
                    this.direction = ShootingDirection.West;
                    BulletSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, 180); // Face west

                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (this.direction != ShootingDirection.East)
                    {
                        player.transform.rotation = Quaternion.Euler(0, 0, 0); // Face east
                        --DiceRoll.numMoves;
                        playerDiceText.text = DiceRoll.numMoves.ToString();
                    }
                    else
                    {
                        Vector3 currentPos = player.transform.position;
                        RaycastHit2D[] results = new RaycastHit2D[1];
                        if (playerBody.Cast(Vector2.right, results, 1) == 0 || (results[0].collider.CompareTag("PowerUp")))
                        {
                            player.transform.position = new Vector3(currentPos.x + 1, currentPos.y, currentPos.z);
                            --DiceRoll.numMoves;
                            playerDiceText.text = DiceRoll.numMoves.ToString();
                            audioManager.PlaySFX(audioManager.moveSound);
                        }
                    }
                    this.direction = ShootingDirection.East;
                    BulletSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, 0); // Face east

                }

                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (this.direction != ShootingDirection.South)
                    {
                        player.transform.rotation = Quaternion.Euler(0, 0, 270); // Face south
                        --DiceRoll.numMoves;
                        playerDiceText.text = DiceRoll.numMoves.ToString();
                    }
                    else
                    {
                        Vector3 currentPos = player.transform.position;
                        RaycastHit2D[] results = new RaycastHit2D[1];
                        if (playerBody.Cast(Vector2.down, results, 1) == 0 || (results[0].collider.CompareTag("PowerUp")))
                        {
                            player.transform.position = new Vector3(currentPos.x, currentPos.y - 1, currentPos.z);
                            --DiceRoll.numMoves;
                            playerDiceText.text = DiceRoll.numMoves.ToString();
                            audioManager.PlaySFX(audioManager.moveSound);
                        }
                    }
                    this.direction = ShootingDirection.South;
                    BulletSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, 270); // Face south

                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (this.direction != ShootingDirection.North)
                    {
                        player.transform.rotation = Quaternion.Euler(0, 0, 90); // Face north
                        --DiceRoll.numMoves;
                        playerDiceText.text = DiceRoll.numMoves.ToString();
                    }
                    else
                    {
                        Vector3 currentPos = player.transform.position;
                        RaycastHit2D[] results = new RaycastHit2D[1];
                        if (playerBody.Cast(Vector2.up, results, 1) == 0 || (results[0].collider.CompareTag("PowerUp")))
                        {
                            player.transform.position = new Vector3(currentPos.x, currentPos.y + 1, currentPos.z);
                            --DiceRoll.numMoves;
                            playerDiceText.text = DiceRoll.numMoves.ToString();
                            audioManager.PlaySFX(audioManager.moveSound);
                        }
                    }
                    this.direction = ShootingDirection.North;
                    BulletSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, 90); // Face north

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
                    playerDiceText.text = DiceRoll.numMoves.ToString();
                    audioManager.PlaySFX(audioManager.gunshotSound);


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
                    if (this.direction != ShootingDirection.West)
                    {
                        player.transform.rotation = Quaternion.Euler(0, 0, 0); // Face west
                        --DiceRoll.numMoves;
                        playerDiceText.text = DiceRoll.numMoves.ToString();
                    }
                    else
                    {
                        Vector3 currentPos = player.transform.position;
                        RaycastHit2D[] results = new RaycastHit2D[1];
                        if (playerBody.Cast(Vector2.left, results, 1) == 0 || (results[0].collider.CompareTag("PowerUp")))
                        {
                            player.transform.position = new Vector3(currentPos.x - 1, currentPos.y, currentPos.z);
                            --DiceRoll.numMoves;
                            playerDiceText.text = DiceRoll.numMoves.ToString();
                            audioManager.PlaySFX(audioManager.moveSound);
                        }
                    }
                    this.direction = ShootingDirection.West;
                    BulletSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, 0); // Face west

                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (this.direction != ShootingDirection.East)
                    {
                        player.transform.rotation = Quaternion.Euler(0, 0, 180); // Face east
                        --DiceRoll.numMoves;
                        playerDiceText.text = DiceRoll.numMoves.ToString();
                    }
                    else
                    {
                        Vector3 currentPos = player.transform.position;
                        RaycastHit2D[] results = new RaycastHit2D[1];
                        if (playerBody.Cast(Vector2.right, results, 1) == 0 || (results[0].collider.CompareTag("PowerUp")))
                        {
                            player.transform.position = new Vector3(currentPos.x + 1, currentPos.y, currentPos.z);
                            --DiceRoll.numMoves;
                            playerDiceText.text = DiceRoll.numMoves.ToString();
                            audioManager.PlaySFX(audioManager.moveSound);
                        }
                    }
                    this.direction = ShootingDirection.East;
                    BulletSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, 180);

                }

                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (this.direction != ShootingDirection.South)
                    {
                        player.transform.rotation = Quaternion.Euler(0, 0, 90); // Face south
                        --DiceRoll.numMoves;
                        playerDiceText.text = DiceRoll.numMoves.ToString();
                    }
                    else
                    {
                        Vector3 currentPos = player.transform.position;
                        RaycastHit2D[] results = new RaycastHit2D[1];
                        if (playerBody.Cast(Vector2.down, results, 1) == 0 || (results[0].collider.CompareTag("PowerUp")))
                        {
                            player.transform.position = new Vector3(currentPos.x, currentPos.y - 1, currentPos.z);
                            --DiceRoll.numMoves;
                            playerDiceText.text = DiceRoll.numMoves.ToString();
                            audioManager.PlaySFX(audioManager.moveSound);
                        }
                    }
                    this.direction = ShootingDirection.South;
                    BulletSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, 90); // Face south

                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (this.direction != ShootingDirection.North)
                    {
                        player.transform.rotation = Quaternion.Euler(0, 0, 270); // Face north
                        --DiceRoll.numMoves;
                        playerDiceText.text = DiceRoll.numMoves.ToString();
                    }
                    else
                    {
                        Vector3 currentPos = player.transform.position;
                        RaycastHit2D[] results = new RaycastHit2D[1];
                        if (playerBody.Cast(Vector2.up, results, 1) == 0 || (results[0].collider.CompareTag("PowerUp")))
                        {
                            player.transform.position = new Vector3(currentPos.x, currentPos.y + 1, currentPos.z);
                            --DiceRoll.numMoves;
                            playerDiceText.text = DiceRoll.numMoves.ToString();
                            audioManager.PlaySFX(audioManager.moveSound);
                        }
                    }
                    this.direction = ShootingDirection.North;
                    BulletSpawnPoint.transform.rotation = Quaternion.Euler(0, 0, 270); // Face north

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
                    playerDiceText.text = DiceRoll.numMoves.ToString();
                    audioManager.PlaySFX(audioManager.gunshotSound);
                }

            }
        }

    }
}

