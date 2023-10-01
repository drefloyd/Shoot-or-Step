using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public Text p1DiceText;
    public Text p2DiceText;

    public GameObject player1;
    public GameObject player2;

    private void Update()
    {
        // gets arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (p1DiceText.text != "P1 Dice")   // meaning it's die was just rolled then p1 goes
        {
            // Flip the sprite based on input
            if (horizontalInput < 0)
            {
                player1.transform.rotation = Quaternion.Euler(0, 0, 180); // Face west
            }
            else if (horizontalInput > 0)
            {
                player1.transform.rotation = Quaternion.Euler(0, 0, 0); // Face east
            }

            if (verticalInput < 0)
            {
                player1.transform.rotation = Quaternion.Euler(0, 0, 270); // Face south
            }
            else if (verticalInput > 0)
            {
                player1.transform.rotation = Quaternion.Euler(0, 0, 90); // Face north
            }
        }

        if (p2DiceText.text != "P2 Dice")   // p2's die was just rolled then p2 goes
        {
            // Player 2 controls
            if (horizontalInput < 0)
            {
                player2.transform.rotation = Quaternion.Euler(0, 0, 0); // Face west
            }
            else if (horizontalInput > 0)
            {
                player2.transform.rotation = Quaternion.Euler(0, 0, 180); // Face east
            }

            if (verticalInput < 0)
            {
                    player2.transform.rotation = Quaternion.Euler(0, 0, 90); // Face south
            }
            else if (verticalInput > 0)
            {
                player2.transform.rotation = Quaternion.Euler(0, 0, 270); // Face north
            }
        }
    }
}
