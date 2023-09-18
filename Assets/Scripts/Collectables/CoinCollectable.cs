using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectable : GenericCollectable
{

    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.instance.AddCoins();
    }

    protected override void PlayEffect()
    {
        base.PlayEffect();
        //Instantiate(particleEffect, transform.position, Quaternion.identity);
    }
}
