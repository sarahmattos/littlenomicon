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
    //private GameObject bossAtual;
    public BossController BossControllerAtual;
     private IEnumerator coroutine;


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
        Instantiate(bosses[i],spawBoss.position,bosses[i].transform.rotation);
        itensColissao[i].SetActive(true);
        coroutine = WaitAndDo(2.0f);
        StartCoroutine(coroutine);
        //chamarAtaque(bosses[i]);
    }
    public void chamarAtaque(GameObject bossAtual){
        BossControllerAtual = bossAtual.GetComponentInChildren<BossController>();
        int tipoAtaque = Random.Range(0,5);
    }
    public void chamarDialogoBatalha(){
        InteracaoManager.Instance.ChamarDialogoInicio();
    }
    IEnumerator WaitAndDo(float time)
    {
        yield return new WaitForSeconds(time);
        chamarDialogoBatalha();
    }
}
