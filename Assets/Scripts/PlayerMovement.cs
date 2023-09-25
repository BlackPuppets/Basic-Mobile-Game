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
    public bool dead = false;

    [SerializeField]private float originalHeight;

    public static PlayerMovement instance;
    private AnimationManager animationManager;

    private Vector3 tempPoisiton;

    private const string IDLE = "a_Idle";
    private const string RUNNING = "a_Running";
    private const string DEAD = "a_Dead";
    private const string FLYING = "a_Flying";

    private void Start()
    {
        originalHeight = transform.localPosition.y;

        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        animationManager = GetComponent<AnimationManager>();
        animationManager.Play(RUNNING);
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
        if(dead)
            animationManager.Play(DEAD);
        else
            animationManager.Play(IDLE);
        restartScreen.SetActive(true);
    }

    #region PowerUps

    public void PowerUpSpeed(float fasterSpeed)
    {
        currentSpeed = fasterSpeed;
        Invoke(nameof(EndPowerUpSpeed), 2);
        animationManager.Play(RUNNING, 2);
    }

    public void EndPowerUpSpeed()
    {
        currentSpeed = originalSpeed;
        animationManager.Play(RUNNING, 1);
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
        animationManager.Play(FLYING);
    }

    public void EndPowerUpFly()
    {
        ChangeHeight(originalHeight);
        animationManager.Play(RUNNING);
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
