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

    public static int numMovesP1;
    public static int numMovesP2;

    public int numberGenerator()
    {
        System.Random rnd = new System.Random();

        numberRollded = rnd.Next(0, 7); // Can return a 0, 1, 2, 3, 4, 5, 6

        return numberRollded;
    }

    public void ChangeDice1Text()
    {
        int diceValue = numberGenerator();

        p1DiceText.text = diceValue.ToString();

        numMovesP1 = diceValue;
        p1DiceButton.interactable = false;      // locks it so there are no longer infinite rolls
    }

    public void ChangeDice2Text()
    {
        int diceValue = numberGenerator();

        p2DiceText.text = diceValue.ToString();
        numMovesP2 = diceValue;

        p2DiceButton.interactable = false;
    }
}
