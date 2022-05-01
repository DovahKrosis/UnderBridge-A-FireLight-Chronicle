using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeItens : MonoBehaviour
{
    public PlayerMovimentation PlayerMovimentation;
    public Transform action;//texto da tela
    public Transform hand1; //pivot da mão do personagem direita


    //TODO: lógica para a pegar apenas um item 
    //TODO: lógica para itens de duas mãos em caso de armas
    //TODO: incrementar inventário

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


