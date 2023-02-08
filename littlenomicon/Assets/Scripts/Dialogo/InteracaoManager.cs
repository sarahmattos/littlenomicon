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
    public int indice=0;
    
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
                        ChoicesBtn[i].GetComponent<UiDialogueInteract>().SetUp(this, dialogueObject.dialogueSegments[indice].dialogueChoices[i].followOnDialogue, dialogueObject.dialogueSegments[indice].dialogueChoices[i].dialogueChoice,dialogueObject.dialogueSegments[indice].dialogueChoices[i].AlteraStatus);
                    }
            }
        }else{
            Dialoguecanvas.SetActive(false);
            PlayerController.Instance.dialogoAberto=false;
            if(PlayerController.Instance.it.conversaUmaVez==true)PlayerController.Instance.it.jaConversou=true;
            PlayerController.Instance.interagir=true;
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
