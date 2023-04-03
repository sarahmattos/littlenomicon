using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 20;
    public float dano = 3;
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
        
         Destroy(gameObject);
    }
}
