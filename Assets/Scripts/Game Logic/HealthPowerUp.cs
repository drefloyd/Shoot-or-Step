using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Powerups/HealthDamage")]
public class HealthPowerUp : PowerupEffect
{
    public int amount;

    public override void Apply(GameObject target)
    {
        target.GetComponent<Health>().currentHealth+=amount;
    }
}
