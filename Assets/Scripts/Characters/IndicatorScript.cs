using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorScript : MonoBehaviour
{
    public Transform player1;  
    public Image p1IndicatorImage;

    public Transform player2;
    public Image p2IndicatorImage;

    void Update()
    {

        if (player1 != null && transform != null && EndTurn.p1Turn == true)
        {
            Vector3 offset = new Vector3(-.08f, .75f, 0f);

            p1IndicatorImage.enabled = true;
            p2IndicatorImage.enabled = false;

            p1IndicatorImage.transform.position = Camera.main.WorldToScreenPoint(player1.position + offset);
        }

        if (player2 != null && transform != null && EndTurn.p2Turn == true)
        {
            Vector3 offset = new Vector3(.09f, .75f, 0f);

            p1IndicatorImage.enabled = false;
            p2IndicatorImage.enabled = true;

            p2IndicatorImage.transform.position = Camera.main.WorldToScreenPoint(player2.position + offset);
        }
    }
}
