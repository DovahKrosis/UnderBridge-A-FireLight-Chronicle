using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class PlayerMovimentation : MonoBehaviour
{

    public WeaponController wc;
    public AudioClip WalkingDungeon;

    #region variables

    public CharacterController controller;
    public float speed = 12f;
    public float speedMax = 12f;
    public float jumpHeight = 2.5f;

    //hunger variables
    private int hungerMax = 100;
    private float hungerCurrent;
    private Coroutine hungerProgress;
    bool iscooldown = false;

    //stamina variables
    private int staminaMax = 100;
    public float staminaCurrent;
    private bool isRunning = false;
    private Coroutine staminaRegen;
    

    //ground variables
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    bool isGrounded;
    

    public Slider hungerBar;
    public Slider staminaBar;
    public Transform staminaValue;
    
    public Transform groundcheck;
    
    public LayerMask groundMask;

    Vector3 velocity;

    #endregion 

    void Start()
    {
        staminaCurrent = staminaMax;
        staminaBar.maxValue = staminaMax;
        hungerBar.maxValue = hungerMax;
    }

    // Update is called once per frame
    void Update()
    {
        staminaValue.GetComponent<Text>().text = staminaCurrent.ToString();
        staminaBar.value = staminaCurrent;
        hungerBar.value = hungerCurrent;

        
        staminaRegen = StartCoroutine(RegenStamina());
        hungerProgress = StartCoroutine(HungerProgress());

 #region Movement

        //is in the ground?
        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);
        

        //is falling?
        if(isGrounded && velocity.y < 0)        
            velocity.y = -2f;
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        //gravity
        velocity.y += gravity * Time.deltaTime;

        //Velocity control
        controller.Move(velocity * Time.deltaTime);

        //jump
        if (Input.GetButtonDown("Jump") && isGrounded && staminaCurrent > 20)
        {           
            velocity.y = Mathf.Sqrt(jumpHeight * -1.8f * gravity);
            staminaCurrent -= 20;
            isGrounded = false;
        }
        else
        {
            speed = speedMax;
        }
        //sprint
        if(staminaCurrent > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {             
                iscooldown = true;
                UseStamina(2f);
            }
            else
            {
                iscooldown = false;
            }
        }
 #endregion

        
    }
    public void UseStamina(float amount)
    {
        if(staminaCurrent - amount >= 0)
        {
            speed = 24f;

            staminaCurrent -= amount;
            
            if(staminaRegen != null)
            {
                StopCoroutine(RegenStamina());
            }            
        }
    }
    public IEnumerator RegenStamina()
    {
        //if (iscooldown == true)
        //{
        //    yield return staminaRegen;           
        //}
        //else
        //{
            yield return new WaitForSeconds(3);
            while (staminaCurrent < staminaMax)
            {
                staminaCurrent += staminaMax / 100;
                yield return staminaRegen;
            }
       // }        
    }

    public IEnumerator HungerProgress()
    {
        
        yield return new WaitForSeconds(3);
        while (hungerCurrent < hungerMax)
        {
          hungerCurrent += hungerMax / 100;
        yield return new WaitForSeconds(10);
          
          
        }
    }
}



/*
        //timer global caso precise de um

    private float executionTimer = 0.0f;
    public Transform execTime;

        executionTimer += Time.deltaTime;
        execTime.GetComponent<Text>().text = executionTimer.ToString("F0");
*/