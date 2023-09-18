using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform targetLerp;
    [SerializeField] private float lerpSpeed = 1;
    [SerializeField] private float speed = 1;
    
    [SerializeField] private bool canMove= true;
    [SerializeField] private GameObject restartScreen;

    private Vector3 tempPoisiton;

    private void Update()
    {
        if (canMove)
        {
            tempPoisiton = targetLerp.position;
            tempPoisiton.y = transform.position.y;
            tempPoisiton.z = transform.position.z;

            transform.position = Vector3.Lerp(transform.position, tempPoisiton, lerpSpeed * Time.deltaTime);
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }

    }

    public void EndGame()
    {
        canMove = false;
        restartScreen.SetActive(true);
    }

}
