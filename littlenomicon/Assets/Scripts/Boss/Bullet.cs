using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 20;
    public float dano = 3;
    public bool aereo;
    void Awake()
    {
        Destroy(gameObject, life);
    }

    // Update is called once per frame
     private void OnCollisionEnter(Collision  other)
    {
        if(other.gameObject.tag =="Player"){
             Batalha.Instance.recebeDano(dano);
        }
        if(other.gameObject.tag =="Barril"){
            Obstaculo obstaculo = other.gameObject.GetComponent<Obstaculo>();
            obstaculo.vida-=dano;
        }
        if(other.gameObject.tag =="Coluna"){
            Obstaculo obstaculo = other.gameObject.GetComponent<Obstaculo>();
            obstaculo.vida-=dano;
        }
        
        if(aereo!=true)Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider  other)
    {
        if(aereo){
            if(other.tag =="Player"){
             Batalha.Instance.recebeDano(dano);
        }
        if(other.tag =="Barril"){
            Obstaculo obstaculo = other.GetComponent<Obstaculo>();
            obstaculo.vida-=dano;
        }
        if(other.tag =="Coluna"){
            Obstaculo obstaculo = other.GetComponent<Obstaculo>();
            obstaculo.vida-=dano;
        }
        
        if(aereo!=true)Destroy(gameObject);
        }
        
    }
    /*private void OnTriggerStay(Collision  other)
    {   if(aereo==true){
            if(other.gameObject.tag =="Player"){
             Batalha.Instance.recebeDano(dano);
        }
       
        
        }
         
    }*/
}
