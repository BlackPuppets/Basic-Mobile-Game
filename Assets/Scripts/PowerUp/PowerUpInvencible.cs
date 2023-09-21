using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvencible : GenericPowerUp
{

    protected override void StartPowerUp()
    {
        Invoke(nameof(EndPowerUp), duration);
        PlayerMovement.instance.PowerUpInvencible();
    }

    protected override void EndPowerUp()
    {
        PlayerMovement.instance.EndPowerUpInvencible();
    }

}
