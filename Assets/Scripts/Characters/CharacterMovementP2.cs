using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CharacterMovementP2 : MonoBehaviour
{

    public Text p2DiceText;

    public GameObject player2;
    // Update is called once per frame
    void Update()
    {
        if (p2DiceText.text != "P2 Dice")   // meaning it's die was just rolled then p1 goes
        {
            if (DiceRoll.numMovesP2 > 0)
            {
                // Flip the sprite based on input

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    player2.transform.rotation = Quaternion.Euler(0, 0, 0); // Face west
                    --DiceRoll.numMovesP2;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    player2.transform.rotation = Quaternion.Euler(0, 0, 180); // Face east
                    --DiceRoll.numMovesP2;
                }

                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    player2.transform.rotation = Quaternion.Euler(0, 0, 90); // Face south
                    --DiceRoll.numMovesP2;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    player2.transform.rotation = Quaternion.Euler(0, 0, 270); // Face north
                    --DiceRoll.numMovesP2;
                }
            }
        }
    }
}
