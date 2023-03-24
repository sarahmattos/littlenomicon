using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batalha : MonoBehaviour
{
    public static Batalha Instance;
    [SerializeField] Transform player;
    [SerializeField] Transform spawPlayer;
    [SerializeField] Transform spawBoss;
    [SerializeField] GameObject[] bosses;
    [SerializeField] GameObject[] itensColissao;
    //private GameObject bossAtual;
    public DialogueObject opcoesPlayer;
    public BossController BossControllerAtual;
     private IEnumerator coroutine;
    public bool batalhaOn;
    public BossModelo bossAtual;
    public int evento;

    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(bossAtual.vidaAtual);
    }
    public void teste(){
        iniciarConfiguracoes(0,0);
    }
    public void iniciarConfiguracoes(int i,int itens){
        
        player.position = spawPlayer.position;
        GameObject _go =Instantiate(bosses[i],spawBoss.position,bosses[i].transform.rotation);
        BonecoDeTreino_Boss bonecoDeTreino_Boss =_go.GetComponentInChildren<BonecoDeTreino_Boss>();
        bossAtual = bonecoDeTreino_Boss;
        itensColissao[i].SetActive(true);
        coroutine = WaitAndDo(2.0f);
        StartCoroutine(coroutine);
        //chamarAtaque(bosses[i]);
    }
    public void chamarDialogoBatalha(){
        batalhaOn=true;
        InteracaoManager.Instance.ChamarDialogoInicio();
    }
    public void chamarAtaque(){
        //BossControllerAtual = bossAtual.GetComponentInChildren<BossController>();
        int tipoAtaque = Random.Range(0,5);
        bossAtual.Ataque(tipoAtaque);
        coroutine = WaitAndOptions(3.0f);
        StartCoroutine(coroutine);
    }
    public void chamarEvento(){
        bossAtual.Fala(evento);
    }
    public void checarEstatiscticas(){
        if(bossAtual.vidaAtual<=bossAtual.vidaMaxima/2){
            evento=6;
            //uma vez
        }
        if(bossAtual.vidaAtual<=0){
            evento=5;
        }
        if(bossAtual.cansaço<=bossAtual.cansaçoInicial/2){
            evento=2;
        }
        if(bossAtual.cansaço<=0){
            evento=1;
        }
        if(bossAtual.raiva<=bossAtual.raivaInicial/2){
            evento=4;
        }
        if(bossAtual.raiva<=0){
            evento=3;
        }
    }
    IEnumerator WaitAndDo(float time)
    {
        yield return new WaitForSeconds(time);
        chamarDialogoBatalha();
    }
    IEnumerator WaitAndOptions(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("acabou ataque, chama opcoes pra jogador");
        InteracaoManager.Instance.dialogueObject = opcoesPlayer;
        InteracaoManager.Instance.ChamarDialogoInicio();
    }

    
    public void atacarBoss(){
        Debug.Log("ataca?");
        if(batalhaOn){
            bossAtual.vidaAtual = bossAtual.vidaAtual-3;
            Debug.Log("ataca");
        }
    }
}
