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


    [SerializeField] private bool canMove= false;
    [SerializeField] private GameObject restartScreen;

    [SerializeField] private GameObject invencibleText;
    public bool invencible;
    public bool dead = false;

    [SerializeField] private float originalHeight;

    [Header("Coroutine Variables")]
    [SerializeField] private Transform scaler;
    [SerializeField] private Vector3 initialScale;
    [SerializeField] private Vector3 collectScale;
    private float elapsedTime = 0;

    public static PlayerMovement instance;
    private AnimationManager animationManager;

    private Vector3 tempPoisiton;

    private const string IDLE = "a_Idle";
    private const string RUNNING = "a_Running";
    private const string DEAD = "a_Dead";
    private const string FLYING = "a_Flying";
    private const string FINISHED = "a_Finished";
    private const string START = "a_Start";

    public void StartGame()
    {
        originalHeight = scaler.transform.localPosition.y;

        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        animationManager = GetComponent<AnimationManager>();
        animationManager.Play(RUNNING);
        canMove = true;
    }

    private void Update()
    {
        if (canMove)
        {
            tempPoisiton = targetLerp.position;
            tempPoisiton.y = scaler.transform.position.y;
            tempPoisiton.z = scaler.transform.position.z;

            scaler.transform.position = Vector3.Lerp(scaler.transform.position, tempPoisiton, lerpSpeed * Time.deltaTime);
            scaler.transform.Translate(transform.forward * currentSpeed * Time.deltaTime);
        }

    }

    public void EndGame()
    {
        canMove = false;
        if(dead)
            animationManager.Play(DEAD);
        else
            animationManager.Play(FINISHED);
        restartScreen.SetActive(true);
    }

    #region PowerUps

    public void CollectedPowerUp()
    {
        StartCoroutine(CollectStart());
    }

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
        var p = scaler.transform.position;
        p.y = heightAmount;
        scaler.transform.position = p;
        //transform.position += new Vector3(transform.position.x, heightAmount, transform.position.z);
    }

    IEnumerator CollectStart()
    {
        elapsedTime = 0;
        while (elapsedTime <= 1)
        {
            scaler.transform.localScale = Vector3.Lerp(initialScale, collectScale, elapsedTime);
            elapsedTime += Time.deltaTime*4;
            yield return new WaitForSeconds(0);
        }
        StartCoroutine(CollectEnd());
        yield return null;
    }

    IEnumerator CollectEnd()
    {
        elapsedTime = 1;
        while (elapsedTime >= 0)
        {
            scaler.transform.localScale = Vector3.Lerp(initialScale, collectScale, elapsedTime);
            elapsedTime -= Time.deltaTime*4;
            yield return new WaitForSeconds(0);
        }

        yield return null;
    }

}
