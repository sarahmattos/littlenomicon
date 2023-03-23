using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] Transform targetPlayer;
    void Start()
    {
        GameObject player =  GameObject.Find("Player");
        targetPlayer = player.GetComponent<Transform>();

        //estatisticas
        int vidaAtual;//diminui com ataque - visual interface
        int vidaMaxima;
        int cansaço;// diminui com acoes- visual falas
        int raiva;// diminui com falas do jogador- visual falas
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPostition = new Vector3( targetPlayer.position.x,transform.position.y,  targetPlayer.transform.position.z ) ;
        transform.LookAt(targetPostition);
    }
    
}
