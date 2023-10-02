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
        if (EndTurn.p1Turn == true)
        {
            if (DiceRoll.numMovesP1 > 0)
            {
                // Flip the sprite based on input

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 180); // Face west
                    --DiceRoll.numMovesP1;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 0); // Face east
                    --DiceRoll.numMovesP1;
                }

                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 270); // Face south
                    --DiceRoll.numMovesP1;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 90); // Face north
                    --DiceRoll.numMovesP1;
                }
            }
        }
        else
        {
            if (DiceRoll.numMovesP2 > 0)
            {
                // Flip the sprite based on input

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 180); // Face west
                    --DiceRoll.numMovesP2;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 0); // Face east
                    --DiceRoll.numMovesP2;
                }

                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 270); // Face south
                    --DiceRoll.numMovesP2;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 90); // Face north
                    --DiceRoll.numMovesP2;
                }
            }
        }
    }
}
