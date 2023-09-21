using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperCoinCollectable : GenericCollectable
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.instance.AddSuperCoins();
    }
    
}
