using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UiDialogueInteract : MonoBehaviour
{
    InteracaoManager interacaoManager;
    DialogueObject dialogueObject;
    bool alteraStatus, compra;

    public string compraNome;
    
    [SerializeField] TMP_Text dialogueText;

    // Update is called once per frame
    public void SetUp(InteracaoManager _interacaoManager, DialogueObject _dialogueObject, string _dialogueText ,bool _alteraStatus, bool _compra)
    {
        interacaoManager = _interacaoManager;
        dialogueObject = _dialogueObject;
        dialogueText.text = _dialogueText;
        alteraStatus= _alteraStatus;
        compraNome =_dialogueText;
        compra=_compra;
        
    }
    public void SelectOption(int valueStatus){
        InteracaoManager.Instance.DialogueChoices.SetActive(false);
        interacaoManager.optionSelected(dialogueObject);
        if(alteraStatus)PlayerController.Instance.Status+=valueStatus;
    }
    public void Compra(int value){
        if(compra){
            InteracaoManager.Instance.valorCompra=value;
            InteracaoManager.Instance.onCompra=true;
            InteracaoManager.Instance.nomeCompra=compraNome;
        }
    }
}
