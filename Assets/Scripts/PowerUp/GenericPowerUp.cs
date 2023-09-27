using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPowerUp : GenericCollectable
{
    //[SerializeField] protected Transform particleEffect;

    //[Header("Sounds")]
    //[SerializeField] protected AudioSource audioSource;

    [SerializeField] protected float duration;

    protected override void OnCollect()
    {
        base.OnCollect();
        StartPowerUp();
    }

    protected virtual void StartPowerUp()
    {
        Invoke(nameof(EndPowerUp), duration);
        PlayerMovement.instance.CollectedPowerUp();
    }

    protected virtual void EndPowerUp()
    {

    }

    //protected virtual void PlayEffect() { }
}
