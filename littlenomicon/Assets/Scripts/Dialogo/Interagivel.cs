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
    //public Sprite icon;
    //public string[] texto;
    //public int fontAssetId;
   // public TMP_FontAsset fontTexto;
}

