using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class InteracaoManager : MonoBehaviour
{
    public static InteracaoManager Instance;
    [Header("ReferenciasCena")]
    [SerializeField] InputActionReference actionReference;
    public DialogueObject dialogueObject;
    [SerializeField] GameObject Dialoguecanvas;
    [SerializeField] GameObject[] ChoicesBtn;
    [SerializeField] TMP_Text texto;
    [SerializeField] Image icon;
    [SerializeField] TMP_FontAsset[] fontTexto;
    
    [HideInInspector]
    public GameObject DialogueChoices;
    
    [Header("Variaveis")]
    public List<string> objetosDesejados;
    public GameObject[] ObjetosInventario;
    private bool onMission;
    private bool começou=false;
    private bool botoesEscolhasOn;
    public int indice=0;
    
    [HideInInspector]
    public string nomeCompra;
    [HideInInspector]
    public int valorCompra;
    [HideInInspector]
    public bool onCompra;
    private IEnumerator coroutine;
    void Start()
    {
         
        Instance =this;
        actionReference.action.started += context =>
        {
            if(!botoesEscolhasOn){
                if(PlayerController.Instance.it!= null){
                    if(PlayerController.Instance.interagir==true ){
                        if(começou==false && !Batalha.Instance.batalhaOn){
                                ChamarDialogoInicio();
                        }else if( PlayerController.Instance.dialogoAberto){
                                indice++;
                                DisplayDialogue();     
                        }
                    }
                 }
                if(Bau.Instance.interagirBau){
                    Bau.Instance.abrirBau();
                }
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
        começou=true;
        
        
        if(indice<dialogueObject.dialogueSegments.Count){
            texto.text=dialogueObject.dialogueSegments[indice].dialogueText;
            icon.sprite =dialogueObject.dialogueSegments[indice].icon;
            texto.font = fontTexto[dialogueObject.dialogueSegments[indice].fontAssetId];
            botoesEscolhasOn=false;
             Cursor.visible = false;
            if(dialogueObject.dialogueSegments[indice].IsPlayer==true){
                FocoCamera.Instance.recebeTargets(PlayerController.Instance.targetPivo, PlayerController.Instance.targetCabeça);
                FocoCamera.Instance.focar=true;
            }else{
                FocoCamera.Instance.recebeTargets(PlayerController.Instance.it.targetPivo, PlayerController.Instance.it.targetCabeça);
                FocoCamera.Instance.focar=true;
            }
            if(dialogueObject.dialogueSegments[indice].dialogueChoices.Count>0){
                botoesEscolhasOn=true;
                 Cursor.visible = true;
                    DialogueChoices.SetActive(true);
                    for(int i=0;i<dialogueObject.dialogueSegments[indice].dialogueChoices.Count;i++){
                        ChoicesBtn[i].GetComponent<UiDialogueInteract>().SetUp(this, dialogueObject.dialogueSegments[indice].dialogueChoices[i].followOnDialogue, dialogueObject.dialogueSegments[indice].dialogueChoices[i].dialogueChoice,dialogueObject.dialogueSegments[indice].dialogueChoices[i].AlteraStatus, dialogueObject.dialogueSegments[indice].dialogueChoices[i].Compra);
                    }
            }
            if(dialogueObject.dialogueSegments[indice].missoes.Count>0){
                    onMission=true;
                    for(int i=0;i<dialogueObject.dialogueSegments[indice].missoes.Count;i++){
                        PlayerController.Instance.it.recompensa += dialogueObject.dialogueSegments[indice].missoes[i].recompensa;
                        objetosDesejados.Add(dialogueObject.dialogueSegments[indice].missoes[i].objetoDesejado);
                        PlayerController.Instance.it.objetosDesejados.Add(dialogueObject.dialogueSegments[indice].missoes[i].objetoDesejado);
                    }
                    
            }
        }else{
            
            if(dialogueObject.endDialogue!=null){
                 dialogueObject=dialogueObject.endDialogue;
                ChamarDialogoInicio();
            }else{
                começou=false;
                FocoCamera.Instance.focar=false;
                Dialoguecanvas.SetActive(false);
                PlayerController.Instance.dialogoAberto=false;
                if(PlayerController.Instance.it.conversaUmaVez==true)PlayerController.Instance.it.jaConversou=true;
                DialogueChoices.SetActive(false);
                if(onMission){
                    PlayerController.Instance.it.onMission=true;
                    onMission=false;
                }
                if(onCompra){
                    PlayerController.Instance.Dinheiro-=valorCompra;
                    for(int i=0;i<ObjetosInventario.Length;i++){
                        if(ObjetosInventario[i].name==nomeCompra) {
                            //adiciona no array de iventario e instancia botoes que tambem armazena
                            InstanciarBotoes.Instance.instanciar(ObjetosInventario[i],InstanciarBotoes.Instance.BotoesItensInventario,InstanciarBotoes.Instance.Item);
                            
                        }
                    }
                    onCompra=false;
                }
                if(PlayerController.Instance.it.temItem==true){
                PlayerController.Instance.entregou();
                PlayerController.Instance.it.recompensaFuncao();
                PlayerController.Instance.it.onMissionComplete=false;
                
                }
                if(Batalha.Instance.batalhaOn){
                    Debug.Log("chamou de novo");
                    // se n tiver evento chama ataque de novo
                     coroutine = Batalha.Instance.EsperarAtaqueComeça( Batalha.Instance.esperaTimeAtaque);
                    StartCoroutine(coroutine);
                    //Batalha.Instance.chamarEvento();
                    //verificar variavel de final batalha
                }
            }
        }
    }
}
