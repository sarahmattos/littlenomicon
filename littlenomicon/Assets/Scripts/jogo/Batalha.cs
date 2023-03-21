using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batalha : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform spawPlayer;
    [SerializeField] Transform spawBoss;
    [SerializeField] GameObject[] bosses;
    [SerializeField] GameObject[] itensColissao;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void teste(){
        iniciarConfiguracoes(0,0);
    }
    public void iniciarConfiguracoes(int i,int itens){
        player.position = spawPlayer.position;
        GameObject _go = Instantiate(bosses[i],spawBoss.position,bosses[i].transform.rotation);
        itensColissao[i].SetActive(true);
    }
}
