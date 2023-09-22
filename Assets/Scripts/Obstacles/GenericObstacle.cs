using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!collision.GetComponent<PlayerMovement>().invencible)
            {
                collision.GetComponent<PlayerMovement>().dead = true;
                collision.GetComponent<PlayerMovement>().EndGame();
            }
        }
    }
}
