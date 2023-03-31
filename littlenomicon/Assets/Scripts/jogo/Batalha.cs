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
     bool[] jaExecutado;
     bool defesaOn;
    Vector3 posicaoAntesBatalha;
     GameObject _go;
    void Start()
    {
        Instance = this;
        
       jaExecutado = new bool[6];
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
        posicaoAntesBatalha = player.position;
        player.position = spawPlayer.position;
         _go =Instantiate(bosses[i],spawBoss.position,bosses[i].transform.rotation);
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
        if(!bossAtual.acabouBatalha){
            int tipoAtaque = Random.Range(0,5);
            bossAtual.Ataque(tipoAtaque);
            recebeDano(3);
            coroutine = WaitAndOptions(3.0f);
            StartCoroutine(coroutine);
        }else{
            resetarBatalha();
        }
        cansarBoss();
        
    }
    public void resetarBatalha(){
        Debug.Log("Acabou batalha");
        player.position = posicaoAntesBatalha;
        batalhaOn=false;
        jaExecutado = new bool[6];
        Destroy(_go);
    }
    public void chamarEvento(){
        if(evento==0)checarCansaço();
        //evento=2;
        
        bossAtual.Fala(evento);
        
    }
    public void checarEstatiscticas(){
        if(!jaExecutado[0] && bossAtual.vidaAtual<=bossAtual.vidaMaxima/2){
            evento=6;
            jaExecutado[0]=true;
            //uma vez
        }
        if(!jaExecutado[1] && bossAtual.vidaAtual<=0){
            evento=5;
            jaExecutado[1]=true;
        }
        /*if(!jaExecutado[2] && bossAtual.cansaço<=bossAtual.cansaçoInicial/2){
            evento=2;
            jaExecutado[2]=true;
        }*/
        if(!jaExecutado[3] && bossAtual.cansaço<=0){
            evento=1;
            jaExecutado[3]=true;
        }
        if(!jaExecutado[4] && bossAtual.raiva<=bossAtual.raivaInicial/2){
            evento=4;
            //InteracaoManager.Instance.dialogueObject.endDialogue = PlayerController.Instance.it.missaoDialogueObject;
            jaExecutado[4]=true;
        }
        if(!jaExecutado[5] && bossAtual.raiva<=0){
             evento=3;
            //InteracaoManager.Instance.dialogueObject.endDialogue = PlayerController.Instance.it.missaoConcluidaDialogueObject;
            //bossAtual.caseDialogue[3];
            jaExecutado[5]=true;
        }
    }
    public void checarCansaço(){
        Debug.Log("indices "+jaExecutado[2]+bossAtual.cansaço+bossAtual.cansaçoInicial/2);
       if(!jaExecutado[2] && bossAtual.cansaço<=bossAtual.cansaçoInicial/2){
            evento=2;
            jaExecutado[2]=true;
           // InteracaoManager.Instance.ChamarDialogoInicio();
           Debug.Log("checou cansaco2 "+Batalha.Instance.evento);
        }else{
            evento=0;
        }
        
       // evento=2;
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
        if(batalhaOn){
            bossAtual.vidaAtual = bossAtual.vidaAtual-3;
            Debug.Log("ataca");
        }
    }
    public void acalmarBoss(){
        if(batalhaOn){
            evento=7;
             bossAtual.raiva = bossAtual.raiva-1;
             Debug.Log("acalma");
        }
    }
    public void cansarBoss(){
        if(batalhaOn){
             bossAtual.cansaço = bossAtual.cansaço-1;
             Debug.Log("cansa");
        }
    }
    public void defender(){
        defesaOn=true;
    }
    public void recebeDano(float dano){
        if(defesaOn){
            float valor = dano*0.5f;
            Debug.Log("dano: "+dano);
            Debug.Log("desconto: "+valor);
            dano -=  valor;
             PlayerController.Instance.vidaAtual-=dano;
             defesaOn=false;
        }else{
             PlayerController.Instance.vidaAtual-=dano;
             Debug.Log("dano: "+dano);
        }
       
    }
}
