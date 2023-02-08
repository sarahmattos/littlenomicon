using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
public class InteracaoManager : MonoBehaviour
{
    public static InteracaoManager Instance;
    public DialogueObject dialogueObject;
    [SerializeField] GameObject Dialoguecanvas;
    public GameObject DialogueChoices;
    [SerializeField] GameObject[] ChoicesBtn;
    [SerializeField] TMP_Text texto;
    [SerializeField] Image icon;
    [SerializeField] TMP_FontAsset[] fontTexto;
    public InputActionReference actionReference;
    public int recompensa, valorCompra;
    public int indice=0;
    public bool onMission, onCompra;
    public string nomeCompra;
    [SerializeField] GameObject[] ObjetosInventario;
    
    bool optionselected = false;
    void Start()
    {
        Instance =this;
        actionReference.action.started += context =>
        {
            if(PlayerController.Instance.interagir==true){
                ChamarDialogoInicio();
            }else{
                indice++;
                DisplayDialogue();
            }
        };
    }
    private void OnEnable()
    {
        actionReference.action.Enable();
    }
    private void OnDisable()
    {
        actionReference.action.Disable();
    }
    public void ChamarDialogoInicio(){
        indice=0;
        Dialoguecanvas.SetActive(true);
        DisplayDialogue();
    }
    public void optionSelected(DialogueObject selectedOption){
        dialogueObject=selectedOption;
        ChamarDialogoInicio();
    }
    
    public void DisplayDialogue(){
        PlayerController.Instance.dialogoAberto=true;
        PlayerController.Instance.interagir=false;
        
        if(indice<dialogueObject.dialogueSegments.Count){
            texto.text=dialogueObject.dialogueSegments[indice].dialogueText;
            icon.sprite =dialogueObject.dialogueSegments[indice].icon;
            texto.font = fontTexto[dialogueObject.dialogueSegments[indice].fontAssetId];

            if(dialogueObject.dialogueSegments[indice].dialogueChoices.Count>0){
                    DialogueChoices.SetActive(true);
                    for(int i=0;i<dialogueObject.dialogueSegments[indice].dialogueChoices.Count;i++){
                        ChoicesBtn[i].GetComponent<UiDialogueInteract>().SetUp(this, dialogueObject.dialogueSegments[indice].dialogueChoices[i].followOnDialogue, dialogueObject.dialogueSegments[indice].dialogueChoices[i].dialogueChoice,dialogueObject.dialogueSegments[indice].dialogueChoices[i].AlteraStatus, dialogueObject.dialogueSegments[indice].dialogueChoices[i].Compra);
                    }
            }
            if(dialogueObject.dialogueSegments[indice].missoes.Count>0){
                    recompensa=0;
                    onMission=true;
                    for(int i=0;i<dialogueObject.dialogueSegments[indice].missoes.Count;i++){
                        recompensa += dialogueObject.dialogueSegments[indice].missoes[i].recompensa;
                    }
                    
            }
        }else{
            
            if(dialogueObject.endDialogue!=null){
                 dialogueObject=dialogueObject.endDialogue;
                ChamarDialogoInicio();
            }else{
                PlayerController.Instance.interagir=true;
                Dialoguecanvas.SetActive(false);
                PlayerController.Instance.dialogoAberto=false;
                if(PlayerController.Instance.it.conversaUmaVez==true)PlayerController.Instance.it.jaConversou=true;
                DialogueChoices.SetActive(false);
                if(onMission)PlayerController.Instance.it.onMission=true;
                if(onCompra){
                    PlayerController.Instance.Dinheiro-=valorCompra;
                    for(int i=0;i<ObjetosInventario.Length;i++){
                        if(ObjetosInventario[i].name==nomeCompra){
                            Inventario.Instance.itens.Add(ObjetosInventario[i]);
                        }
                    }
                    
                    
                    onCompra=false;
                }
                
            }
            if(PlayerController.Instance.it.onMissionComplete==true){
                InteracaoManager.Instance.dialogueObject= PlayerController.Instance.it.missaoConcluidaDialogueObject;
                PlayerController.Instance.Dinheiro+=recompensa;
                PlayerController.Instance.it.onMissionComplete=false;
            }
            
        }
        
    }
    
    
    
    /*
    IEnumerator DisplayDialogue(DialogueObject _dialogueObject){
        yield return null;
        Dialoguecanvas.SetActive(true);
        foreach(var dialogue in _dialogueObject.dialogueSegments){
            texto.text=dialogue.dialogueText;
            icon.sprite =dialogue.icon;
            texto.font = fontTexto[dialogue.fontAssetId];
            if(dialogue.dialogueChoices.Count==0){
                yield return new WaitForSeconds(dialogue.dialogueDisplayTime);
            }else{
            //options
            DialogueChoices.SetActive(true);
            for(int i=0;i<dialogue.dialogueChoices.Count;i++){
                 ChoicesBtn[i].GetComponent<UiDialogueInteract>().SetUp(this, dialogue.dialogueChoices[i].followOnDialogue, dialogue.dialogueChoices[i].dialogueChoice);
            }
            while(!optionselected){
                yield return null;
            }
            break;
        }
        
    }
        Dialoguecanvas.SetActive(false);
         DialogueChoices.SetActive(false);
         optionselected=false;
         PlayerController.Instance.dialogoAberto=false;
}
*/
}
