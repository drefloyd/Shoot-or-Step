using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoll : MonoBehaviour
{
    [SerializeField] private int numberRollded;

    public Text p1DiceText;
    public Text p2DiceText;

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
    }

    public void ChangeDice2Text()
    {
        int diceValue = numberGenerator();

        p2DiceText.text = diceValue.ToString();
    }
}
