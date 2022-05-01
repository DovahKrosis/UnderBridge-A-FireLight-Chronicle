using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeItem : MonoBehaviour
{
    public PlayerMovimentation PlayerMovimentation;
    public Transform handCheck;
    public LayerMask graspable;
    public Transform action;
    bool isHandable;
    public Collision objCol;


    //public void OnCollisionStay(Collision col)
    //{
    //    PlayerMovimentation.staminaCurrent -= 100f;
        
    //}

    void Update()
    {
        action.GetComponent<Text>().text = "";
        isHandable = Physics.CheckSphere(handCheck.position, PlayerMovimentation.groundDistance, graspable);
        //verifica se tem algo no alcance da mão do player
        if (isHandable)
        {
            action.GetComponent<Text>().text = "press E";

            if (Input.GetKey(KeyCode.E))
            {
                //PlayerMovimentation.staminaCurrent -= 10f;
                if (objCol.gameObject.tag == "isColetavel")
                {
                    PlayerMovimentation.staminaCurrent -= 100f;
                }
            }

        }
    }





}
