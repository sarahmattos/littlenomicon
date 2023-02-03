using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
public class InteracaoManager : MonoBehaviour
{
    [SerializeField] DialogueObject dialogueObject;
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
                StartDialogue();
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
    public void StartDialogue(){
        StartCoroutine(DisplayDialogue());
    }
    public void optionSelected(DialogueObject selectedOption){
        optionselected=true;
        dialogueObject = selectedOption;
         StartDialogue();
    }
    IEnumerator DisplayDialogue(){
        yield return null;
        Dialoguecanvas.SetActive(true);
        foreach(var dialogue in dialogueObject.dialogueSegments){
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
        }
        
    }
        Dialoguecanvas.SetActive(false);
         DialogueChoices.SetActive(false);
}
}
