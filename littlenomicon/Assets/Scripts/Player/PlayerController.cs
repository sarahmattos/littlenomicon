using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public float speed;
    private Vector2 move;
    private Animator anim;
    public Vector3 movement;
    public Vector3 lastPos;
    public bool interagir = false;
    public bool dialogoAberto=false;
    private GameObject targetObjeto;
    private bool jaConversou;
    public Interagivel it;
    public InputActionReference actionReference;
    public int Status;
    public int Dinheiro;
    public bool onMission;
    public bool onMissionComplete;
    bool temItem;

    public Transform targetPivo;
    public Transform targetCabeça;

    int i,j;

    private void Start()
    {
        Instance=this;
        anim = gameObject.GetComponent<Animator>();
        Dinheiro=5;
    }
    private void OnEnable()
    {
        actionReference.action.Enable();
    }
    private void OnDisable()
    {
        actionReference.action.Disable();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    void Update()
    {
        if(dialogoAberto==false){
            movePlayer();
        }
           
        AnimatorManager();
         if(it!= null && it.onMission){
            checaItemInventario();
         }
    }
    public void movePlayer()
    {
        movement = new Vector3(move.x, 0f, move.y);
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
    public void AnimatorManager()
    {

        if (transform.position != lastPos)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
        lastPos = transform.position;
    }
    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Interagivel")
        {   
            targetObjeto = target.gameObject;
            it = targetObjeto.GetComponent<Interagivel>();
            interagir = true;
            
            //jaConversou=it.jaConversou;
            if(it.jaConversou==false && it.onMission==false && it.onMissionComplete==false) InteracaoManager.Instance.dialogueObject= it.startDialogueObject;
            if(it.jaConversou==true && it.onMission==false && it.onMissionComplete==false)InteracaoManager.Instance.dialogueObject= it.jaVisitouDialogueObject;
            if(it.onMission==true && it.onMissionComplete==false && temItem==false)InteracaoManager.Instance.dialogueObject= it.missaoDialogueObject;
            
            if(it.onMission==true && it.onMissionComplete==false && temItem==true) {
                InteracaoManager.Instance.dialogueObject= it.missaoConcluidaDialogueObject;
                it.onMissionComplete=true;
            }
        }
    }
    void OnTriggerStay(Collider target)
    {
        if (target.tag == "Interagivel")
        {   
            if(it.NPC){
                Vector3 targetPostition = new Vector3( targetCabeça.position.x,targetObjeto.transform.position.y,  targetCabeça.transform.position.z ) ;
                targetObjeto.transform.LookAt(targetPostition);
            }
            
            if(dialogoAberto==true){
                 Vector3 targetPostition2 = new Vector3( targetObjeto.transform.position.x,transform.position.y, targetObjeto.transform.position.z ) ;
                transform.LookAt(targetPostition2);
            }
            if(it.jaConversou==true && it.onMission==false && it.onMissionComplete==false)InteracaoManager.Instance.dialogueObject= it.jaVisitouDialogueObject;
            if(it.onMission==true && it.onMissionComplete==false && temItem==false)InteracaoManager.Instance.dialogueObject= it.missaoDialogueObject;
            if(it.onMission==true && it.onMissionComplete==false && temItem==true) {
                InteracaoManager.Instance.dialogueObject= it.missaoConcluidaDialogueObject;
                it.onMissionComplete=true;
            }
        }
    }
    public void entregou(){
        AreaSaida.Instance.box.enabled=false;
        it.onMission=false;
        temItem=false;
        InteracaoManager.Instance.objetosDesejados.Remove(InteracaoManager.Instance.objetosDesejados[j]);
        //Inventario.Instance.itens.Remove(Inventario.Instance.itens[i]);
        Destroy(InstanciarBotoes.Instance.BotoesItensInventario[i]);
        InstanciarBotoes.Instance.BotoesItensInventario.Remove(InstanciarBotoes.Instance.BotoesItensInventario[i]);
        InstanciarBotoes.Instance.NavegacaoItem(InstanciarBotoes.Instance.BotoesItensInventario);
        
    }
    void OnTriggerExit(Collider target)
    {
        if (target.tag == "Interagivel")
        {
            interagir = false;
        }
    }
    public void checaItemInventario(){
             for(int _i=0;_i<InstanciarBotoes.Instance.BotoesItensInventario.Count;_i++){
                for(int _j=0;_j<InteracaoManager.Instance.objetosDesejados.Count;_j++){
                    BotoesItem btnItem = InstanciarBotoes.Instance.BotoesItensInventario[_i].GetComponent<BotoesItem>();
                    if(btnItem.nomeItem==InteracaoManager.Instance.objetosDesejados[_j]){
                            temItem=true;
                            i=_i;
                            j=_j;
                    }
                }
                    
            
        }
        
       
    }
    /*
    public void InfosDialogo()
    {
        if (interagir == true)
        {   
            if(dialogoAberto==false){
                it = targetObjeto.GetComponent<Interagivel>();
                CanvasManager.Instance.atualizarCanvasDialogo(it.icon, it.texto, it.fontAssetId, it.personagem, it.jaConversou);
            }else{
                CanvasManager.Instance.passarDialogo(it.texto);
            }
        }
    }
    public void DisableObject(){
        it.jaConversou=true;
    }
    */
}
