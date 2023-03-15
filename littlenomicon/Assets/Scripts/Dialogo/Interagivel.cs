using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//[CreateAssetMenu(fileName = "ObjetoInteragivel", menuName = "Interagivel/Novo")]
public class Interagivel : MonoBehaviour
{  
     [Header("ScriptablesDialogo")]
    public DialogueObject startDialogueObject;
    public DialogueObject jaVisitouDialogueObject;
    public DialogueObject missaoDialogueObject;
    public DialogueObject missaoConcluidaDialogueObject;

    [Header("ReferenciasCena")]
    public Transform targetPivo;
    public Transform targetCabeça;

    [Header("Variaveis")]
    public bool conversaUmaVez;
    public bool NPC;
    public List<string> objetosDesejados;

    public int tipoRecompensa;
    [HideInInspector]
    public bool jaConversou;
    [HideInInspector]
    public bool onMissionComplete;
    [HideInInspector]
    public bool onMission;
    [HideInInspector]
    public bool temItem=false;
    [HideInInspector]
    public int recompensa;
     [HideInInspector]
     public int i;
     [HideInInspector]
     public int j;
    

public void recompensaFuncao()
    {
        switch (tipoRecompensa)
        {
        case 5:
            PlayerController.Instance.Dinheiro+=PlayerController.Instance.it.recompensa;
            break;
        case 4:
            AreaSaida.Instance.box.enabled=false;
            break;
        case 3:
            print ("Whadya want?");
            break;
        case 2:
            print ("Grog SMASH!");
            break;
        case 1:
            print ("Ulg, glib, Pblblblblb");
            break;
        default:
            print ("Incorrect intelligence level.");
            break;
        }
    }
    
    //public Sprite icon;
}

