using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public GameObject player;  

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
                    --DiceRoll.numMoves;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 0); // Face east
                    --DiceRoll.numMoves;
                }

                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 270); // Face south
                    --DiceRoll.numMoves;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 90); // Face north
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
                    --DiceRoll.numMoves;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 180); // Face east
                    --DiceRoll.numMoves;
                }

                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 90); // Face south
                    --DiceRoll.numMoves;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 270); // Face north
                    --DiceRoll.numMoves;
                }
            }
        }
    }
}
