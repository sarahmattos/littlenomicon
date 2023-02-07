using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UiDialogueInteract : MonoBehaviour
{
    InteracaoManager interacaoManager;
    DialogueObject dialogueObject;
    
    [SerializeField] TMP_Text dialogueText;

    // Update is called once per frame
    public void SetUp(InteracaoManager _interacaoManager, DialogueObject _dialogueObject, string _dialogueText )
    {
        interacaoManager = _interacaoManager;
        dialogueObject = _dialogueObject;
        dialogueText.text = _dialogueText;
        
    }
    public void SelectOption(){
        InteracaoManager.Instance.DialogueChoices.SetActive(false);
        interacaoManager.optionSelected(dialogueObject);
    }
}
