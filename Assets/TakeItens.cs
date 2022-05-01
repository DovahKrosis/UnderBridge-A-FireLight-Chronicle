using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeItens : MonoBehaviour
{
    public PlayerMovimentation PlayerMovimentation;
    public Transform action;//texto da tela
    public Transform hand1; //pivot da mão do personagem direita


    public void OnCollisionEnter(Collision col)
    {
        action.GetComponent<Text>().text = "";

        while(col.gameObject.tag == "isColetavel")
        {
            action.GetComponent<Text>().text = "press E";
            if (Input.GetKeyDown(KeyCode.E))
            {
                col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                col.transform.position = hand1.position;
                col.transform.rotation = hand1.rotation;

                col.transform.SetParent(hand1);
                action.GetComponent<Text>().text = "";
            }
        }
        //if (col.gameObject.tag == "isColetavel")
        //{
        //}
        //else
        //{
        //    action.GetComponent<Text>().text = "";
        //}

    }
}


