using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Powerups/HealthDamage")]
public class HealthPowerUp : PowerupEffect
{
    public int amount;
    // Start is called before the first frame update
    public override void Apply(GameObject target)
    {
        target.GetComponent<Health>().currentHealth+=amount;
    }
}
