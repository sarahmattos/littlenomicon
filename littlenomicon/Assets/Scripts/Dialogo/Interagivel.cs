using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//[CreateAssetMenu(fileName = "ObjetoInteragivel", menuName = "Interagivel/Novo")]
public class Interagivel : MonoBehaviour
{   
    public DialogueObject startDialogueObject;
    public DialogueObject jaVisitouDialogueObject;
    public DialogueObject missaoDialogueObject;
    public DialogueObject missaoConcluidaDialogueObject;

    public Transform targetPivo, targetCabeça;
    //public bool personagem;
    public bool conversaUmaVez;
    [HideInInspector]
    public bool jaConversou;
    [HideInInspector]
    public bool onMissionComplete;
    [HideInInspector]
    public bool onMission;

    public bool NPC;
    [HideInInspector]
    public bool temItem=false;

    [HideInInspector]
    public int recompensa;

    public List<string> objetosDesejados;

     [HideInInspector]
     public int i;
     [HideInInspector]
     public int j;
     public int tipoRecompensa;

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
    //public string[] texto;
    //public int fontAssetId;
   // public TMP_FontAsset fontTexto;
}

