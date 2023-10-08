using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerUp : MonoBehaviour
{
    public PowerupEffect powerupEffect;
    private void onTriggerEnter2D(Collider2D collision)
    {

        Destroy(gameObject);
        powerupEffect.Apply(collision.gameObject);
    }
}
