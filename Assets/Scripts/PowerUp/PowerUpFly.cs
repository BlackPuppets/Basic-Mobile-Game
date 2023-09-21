using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFly : GenericPowerUp
{
    [SerializeField] private float heightChangeAmount = 3;
    protected override void StartPowerUp()
    {
        Invoke(nameof(EndPowerUp), duration);
        PlayerMovement.instance.PowerUpFly(heightChangeAmount);
    }

    protected override void EndPowerUp()
    {
        PlayerMovement.instance.EndPowerUpFly();
    }

}
