using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : GenericPowerUp
{
    [Header("PowerUpSpeed")]
    [SerializeField] private float fasterSpeed;

    protected override void StartPowerUp()
    {
        PlayerMovement.instance.PowerUpSpeed(fasterSpeed);
        base.StartPowerUp();
        Debug.Log("a");
    }

    protected override void EndPowerUp()
    {
        PlayerMovement.instance.EndPowerUpSpeed();
        Debug.Log("b");
    }
}
