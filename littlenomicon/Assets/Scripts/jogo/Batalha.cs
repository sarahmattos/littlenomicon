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
    BossModelo bossAtual;

    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void teste(){
        iniciarConfiguracoes(0,0);
    }
    public void iniciarConfiguracoes(int i,int itens){
        bossAtual = bosses[i].GetComponentInChildren<BonecoDeTreino_Boss>();
        player.position = spawPlayer.position;
        Instantiate(bosses[i],spawBoss.position,bosses[i].transform.rotation);
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
}
