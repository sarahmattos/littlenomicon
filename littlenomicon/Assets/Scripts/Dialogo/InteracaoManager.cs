using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
public class InteracaoManager : MonoBehaviour
{
    [SerializeField] DialogueObject startDialogueObject;
    [SerializeField] GameObject Dialoguecanvas;
    [SerializeField] GameObject DialogueChoices;
    [SerializeField] GameObject[] ChoicesBtn;
    [SerializeField] TMP_Text texto;
    public InputActionReference actionReference;
    bool optionselected = false;
    void Start()
    {
        actionReference.action.started += context =>
        {
            if(PlayerController.Instance.interagir==true){
                StartDialogue(startDialogueObject);
                
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
    public void StartDialogue(DialogueObject _dialogueObject){
        PlayerController.Instance.dialogoAberto=true;
        StartCoroutine(DisplayDialogue(_dialogueObject));
    }
    public void optionSelected(DialogueObject selectedOption){
        optionselected=true;
         StartDialogue(selectedOption);
    }
    IEnumerator DisplayDialogue(DialogueObject _dialogueObject){
        yield return null;
        Dialoguecanvas.SetActive(true);
        foreach(var dialogue in _dialogueObject.dialogueSegments){
            texto.text=dialogue.dialogueText;
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
}
