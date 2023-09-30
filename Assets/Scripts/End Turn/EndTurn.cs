using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurn : MonoBehaviour
{
    [SerializeField] public bool p1Turn;
    [SerializeField] public bool p2Turn;

    public Button p1DiceButton;
    public Button p2DiceButton;

    public Text p1DiceText;
    public Text p2DiceText;

    private void Start()
    {
        System.Random rnd = new System.Random();

        int turnDecider = rnd.Next(1, 3); // return 1 == p1 turn, 2 == p2 turn to start

        if(turnDecider == 1)
        {
            p1Turn = true;
            p2Turn = false;
        }
        else
        {
            p1Turn = false;
            p2Turn = true;
        }
    }

    public void ChangePlayerTurn()
    {
        if(p1Turn == true)
        {
            p1Turn = false;
            p2Turn = true;

            p1DiceButton.interactable = false;
            p2DiceButton.interactable = true;

            p1DiceText.text = "P1 Dice";
        }
        else
        {
            p1Turn = true;
            p2Turn = false;

            p1DiceButton.interactable = true;
            p2DiceButton.interactable = false;

            p2DiceText.text = "P2 Dice";
        }
    }
}
