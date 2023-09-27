using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvencible : GenericPowerUp
{

    protected override void StartPowerUp()
    {
        Invoke(nameof(EndPowerUp), duration);
        PlayerMovement.instance.PowerUpInvencible();
        base.StartPowerUp();
    }

    protected override void EndPowerUp()
    {
        PlayerMovement.instance.EndPowerUpInvencible();
    }

}
