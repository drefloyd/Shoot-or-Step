using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public Text p1DiceText;

    public GameObject player1;

    private void Update()
    {
        if (p1DiceText.text != "P1 Dice")   // meaning it's die was just rolled then p1 goes
        {
            if (DiceRoll.numMovesP1 > 0)
            {
                // Flip the sprite based on input

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    player1.transform.rotation = Quaternion.Euler(0, 0, 180); // Face west
                    --DiceRoll.numMovesP1;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    player1.transform.rotation = Quaternion.Euler(0, 0, 0); // Face east
                    --DiceRoll.numMovesP1;
                }

                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    player1.transform.rotation = Quaternion.Euler(0, 0, 270); // Face south
                    --DiceRoll.numMovesP1;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    player1.transform.rotation = Quaternion.Euler(0, 0, 90); // Face north
                    --DiceRoll.numMovesP1;
                }

            }
        }
       
    }
}
