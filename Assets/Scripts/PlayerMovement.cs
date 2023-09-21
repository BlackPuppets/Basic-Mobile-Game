using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform targetLerp;
    [SerializeField] private float lerpSpeed = 1;
    [SerializeField] private float originalSpeed = 1;
    [SerializeField] private float currentSpeed = 1;


    [SerializeField] private bool canMove= true;
    [SerializeField] private GameObject restartScreen;

    [SerializeField] private GameObject invencibleText;
    public bool invencible;

    [SerializeField]private float originalHeight = 0;

    public static PlayerMovement instance;

    private Vector3 tempPoisiton;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (canMove)
        {
            tempPoisiton = targetLerp.position;
            tempPoisiton.y = transform.position.y;
            tempPoisiton.z = transform.position.z;

            transform.position = Vector3.Lerp(transform.position, tempPoisiton, lerpSpeed * Time.deltaTime);
            transform.Translate(transform.forward * currentSpeed * Time.deltaTime);
        }

    }

    public void EndGame()
    {
        canMove = false;
        restartScreen.SetActive(true);
    }

    #region PowerUps

    public void PowerUpSpeed(float fasterSpeed)
    {
        currentSpeed = fasterSpeed;
        Invoke(nameof(EndPowerUpSpeed), 2);
    }

    public void EndPowerUpSpeed()
    {
        currentSpeed = originalSpeed;
    }

    public void PowerUpInvencible()
    {
        invencible = true;
        invencibleText.SetActive(true);
    }

    public void EndPowerUpInvencible()
    {
        invencible = false;
        invencibleText.SetActive(false);
    }

    public void PowerUpFly(float heightAmount)
    {
        ChangeHeight(heightAmount);
    }

    public void EndPowerUpFly()
    {
        ChangeHeight(originalHeight);
    }

    #endregion

    void ChangeHeight(float heightAmount)    
    {
        var p = transform.position;
        p.y = heightAmount;
        transform.position = p;
        //transform.position += new Vector3(transform.position.x, heightAmount, transform.position.z);
    }

}
