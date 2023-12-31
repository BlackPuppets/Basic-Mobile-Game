using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericCollectable : MonoBehaviour
{
    [SerializeField] protected ParticleSystem particleEffect;
    [SerializeField] protected Transform particlePlaneCollision;

    //[Header("Sounds")]
    //[SerializeField] protected AudioSource audioSource;
    [SerializeField] protected float deactivatedTime;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        OnCollect();
        gameObject.SetActive(false);
        Destroy(gameObject, deactivatedTime);
    }


    protected virtual void OnCollect() {
        PlayEffect();
    }
    
    protected virtual void PlayEffect() {
        if(particleEffect != null)
        {
            var instantiatedParticle = Instantiate(particleEffect, transform.position, Quaternion.identity);
            instantiatedParticle.collision.AddPlane(particlePlaneCollision);
        }
    }
}
