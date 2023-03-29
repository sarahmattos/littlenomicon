using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonecoDeTreino_Boss : BossModelo
{
    // Start is called before the first frame update
    public DialogueObject[] caseDialogue;
    void Start()
    {
        vidaMaxima=10;
        vidaAtual=10;
        cansaço=3;
        cansaçoInicial=3;
        raiva=3;
        raivaInicial=3;
        caseDialogue[7].endDialogue = caseDialogue[8];
    }
    //sequencia de ataques pre definida
    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Ataque(int tipoAtaque)
    {
        switch (tipoAtaque)
        {
        case 5:
            Debug.Log("Ataque 5");
            break;
        case 4:
            Debug.Log("Ataque 4");
            break;
        case 3:
            Debug.Log("Ataque 3");
            break;
        case 2:
            Debug.Log("Ataque 2");
            break;
        case 1:
            Debug.Log("Ataque 1");
            break;
        default:
            Debug.Log("Ataque default");
            break;
        }
    }
    public override void Fala(int tipoFala)
    {
        switch (tipoFala)
        {
        case 7:
            Debug.Log("Conversa calma");
            
            break;
        case 6:
            Debug.Log("Metade de dano");
            break;
        case 5:
            Debug.Log("Morreu de dano");
            //variavel de acabar batalha
            acabouBatalha=true;
            break;
        case 4:
            Debug.Log("Metade Calmo");
            //InteracaoManager.Instance.dialogueObject.endDialogue = PlayerController.Instance.it.missaoDialogueObject;
            break;
        case 3:
            Debug.Log("Totalmente calmo");
            //variavel de acabar batalha
            acabouBatalha=true;
            break;
        case 2:
            Debug.Log("metade cansado");
            break;
        case 1:
            Debug.Log("totalmente cansado");
            //variavel de acabar batalha
            acabouBatalha=true;
            break;
        default:
            Debug.Log("Nao tem evento");
            Batalha.Instance.chamarAtaque();
            break;
        }
        if(tipoFala!=0 && tipoFala!=4 && tipoFala!=3){
            Debug.Log("entrou"+tipoFala);
            Batalha.Instance.evento=0;
            InteracaoManager.Instance.dialogueObject = caseDialogue[tipoFala];
            InteracaoManager.Instance.ChamarDialogoInicio();
        }else{
            if(tipoFala==4||tipoFala==3){
            Batalha.Instance.evento=0;
            InteracaoManager.Instance.dialogueObject = caseDialogue[7];
            InteracaoManager.Instance.dialogueObject.endDialogue = caseDialogue[tipoFala];
            InteracaoManager.Instance.ChamarDialogoInicio();
            }
        }
            
    }
}
