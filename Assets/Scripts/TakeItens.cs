using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeItens : MonoBehaviour
{
    public PlayerMovimentation PlayerMovimentation;
    public Transform action;//texto da tela
    public Transform hand1; //pivot da m�o do personagem direita


    //TODO: l�gica para a pegar apenas um item 
    //TODO: l�gica para itens de duas m�os em caso de armas
    //TODO: incrementar invent�rio

    public void OnCollisionStay(Collision col)
    {
        action.GetComponent<Text>().text = "";

        if(col.gameObject.tag == "isColetavel" && Input.GetKey(KeyCode.E))
        {
            action.GetComponent<Text>().text = "press E";

                col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                col.transform.position = hand1.position;
                col.transform.rotation = hand1.rotation;

                col.transform.SetParent(hand1);
                action.GetComponent<Text>().text = "";
        }
    }
}


