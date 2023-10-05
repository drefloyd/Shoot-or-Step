using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoll : MonoBehaviour
{
    [SerializeField] private int numberRollded;     // serialized for testing purposes if someone wants to give the die a specific value

    public Text p1DiceText;
    public Text p2DiceText;

    public Button p1DiceButton;
    public Button p2DiceButton;

    public static int numMoves;

    public static bool hasRolled = false;

    public int numberGenerator()
    {
        System.Random rnd = new System.Random();

        numberRollded = rnd.Next(0, 7); // Can return a 0, 1, 2, 3, 4, 5, 6

        return numberRollded;
    }

    public void ChangeDiceText()
    {
        int diceValue = numberGenerator();

        if (EndTurn.p1Turn == true)
        {
            p1DiceText.text = diceValue.ToString();

            numMoves = diceValue;

            p1DiceButton.interactable = false;      // locks it so there are no longer infinite rolls

            hasRolled = true;
        }
        else
        {
            p2DiceText.text = diceValue.ToString();

            numMoves = diceValue;

            p2DiceButton.interactable = false;

            hasRolled = true;
        }
    }
}