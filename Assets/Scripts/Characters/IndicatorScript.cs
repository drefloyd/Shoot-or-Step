using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorScript : MonoBehaviour
{
    public Transform player1;  
    public Image p1IndicatorImage;

    public Transform player2;
    public Image p2ImageToPosition;

    public float blinkInterval = 1f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        float yOffset = 22f;    

        if (player1 != null && transform != null && EndTurn.p1Turn == true)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(player1.transform.position);

            screenPosition.y += yOffset;

            p1IndicatorImage.rectTransform.position = screenPosition;

            if (timer >= blinkInterval)
            {
                p1IndicatorImage.enabled = !p1IndicatorImage.isActiveAndEnabled;

                timer = 0f;
            }
        }

        if (player2 != null && transform != null && EndTurn.p2Turn == true)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(player2.transform.position);

            screenPosition.y += yOffset;

            p2ImageToPosition.rectTransform.position = screenPosition;

            if (timer >= blinkInterval)
            {
                p2ImageToPosition.enabled = !p2ImageToPosition.isActiveAndEnabled;

                timer = 0f;
            }
        }
    }
}
