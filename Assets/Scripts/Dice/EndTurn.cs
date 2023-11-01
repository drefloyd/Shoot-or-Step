using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTurn : MonoBehaviour
{
    [SerializeField] public static bool p1Turn;
    [SerializeField] public static bool p2Turn;

    public Button p1DiceButton;
    public Button p2DiceButton;

    public Text p1DiceText;
    public Text p2DiceText;

    public GameObject Player1;
    public GameObject Player2;

    public Button p1EndTurnButton;
    public Button p2EndTurnButton;

    private void Start()
    {
        System.Random rnd = new System.Random();

        int turnDecider = rnd.Next(1, 3); // return 1 == p1 turn, 2 == p2 turn to start

        CharacterMovement p1MovementScript = Player1.GetComponent<CharacterMovement>();
        CharacterMovement p2MovementScript = Player2.GetComponent<CharacterMovement>();

        if (turnDecider == 1)
        {
            p1Turn = true;
            p2Turn = false;

            p1DiceButton.interactable = true;
            p2DiceButton.interactable = false;

            p1MovementScript.enabled = true;
            p2MovementScript.enabled = false;

            p1EndTurnButton.interactable = true;
            p2EndTurnButton.interactable = false;

            Debug.Log("Player 1 goes first.");
        }
        else
        {
            p1Turn = false;
            p2Turn = true;

            p1DiceButton.interactable = false;
            p2DiceButton.interactable = true;

            p1MovementScript.enabled = false;
            p2MovementScript.enabled = true;

            p1EndTurnButton.interactable = false;
            p2EndTurnButton.interactable = true;

            Debug.Log("Player 2 goes first.");
        }

        if (Input.GetKeyDown("e"))
        { if (Time.timeScale == 1f)
            {
                if (p1Turn == true)
                {
                    p1EndTurnButton.onClick.Invoke();
                }
                else
                {
                    p2EndTurnButton.onClick.Invoke();
                }
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (Time.timeScale == 1f)
            {
                if (p1Turn == true)
                {
                    p1EndTurnButton.onClick.Invoke();
                }
                else
                {
                    p2EndTurnButton.onClick.Invoke();
                }
            }
        }
    }

    public void ChangePlayerTurn()
    {
        CharacterMovement p1MovementScript = Player1.GetComponent<CharacterMovement>();
        CharacterMovement p2MovementScript = Player2.GetComponent<CharacterMovement>();

        if (p1Turn == true)
        {
            Debug.Log("It is now Player 2's turn.");

            p1Turn = false;
            p2Turn = true;

            p1DiceButton.interactable = false;
            p2DiceButton.interactable = true;

            p1MovementScript.enabled = false;
            p2MovementScript.enabled = true;

            if (DiceRoll.hasRolled == true)
            {
                p1EndTurnButton.interactable = false;
                p2EndTurnButton.interactable = true;
                DiceRoll.hasRolled = false;
            }
            else if (DiceRoll.hasRolled == false)
            {
                p1EndTurnButton.interactable = false;
                p2EndTurnButton.interactable = true;
            }
            p1DiceText.text = "P1 Dice";
        }
        else
        {
            Debug.Log("It is now Player 1's turn.");

            p1Turn = true;
            p2Turn = false;

            p1DiceButton.interactable = true;
            p2DiceButton.interactable = false;

            p1MovementScript.enabled = true;
            p2MovementScript.enabled = false;

            if (DiceRoll.hasRolled == true)
            {
                p1EndTurnButton.interactable = true;
                p2EndTurnButton.interactable = false;
                DiceRoll.hasRolled = false;
            }
            else if(DiceRoll.hasRolled == false)
            {
                p1EndTurnButton.interactable = true;
                p2EndTurnButton.interactable = false;
            }
            p2DiceText.text = "P2 Dice";
        }
    }
}
