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

    public Transform targetPivo;
    public Transform targetCabeça;

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
            if(it.onMission==true && it.onMissionComplete==false)InteracaoManager.Instance.dialogueObject= it.missaoDialogueObject;
            if(it.onMissionComplete==true)InteracaoManager.Instance.dialogueObject= it.missaoConcluidaDialogueObject;
            
        }
    }
    void OnTriggerStay(Collider target)
    {
        if (target.tag == "Interagivel")
        {   
            //jaConversou=it.jaConversou;
            if(it.jaConversou==true && onMission==false && onMissionComplete==false)InteracaoManager.Instance.dialogueObject= it.jaVisitouDialogueObject;
            if(it.onMission==true && onMissionComplete==false)InteracaoManager.Instance.dialogueObject= it.missaoDialogueObject;
            if(it.onMissionComplete==true)InteracaoManager.Instance.dialogueObject= it.missaoConcluidaDialogueObject; 
            entregouMissao();
        }
    }
    void OnTriggerExit(Collider target)
    {
        if (target.tag == "Interagivel")
        {
            interagir = false;
            //CanvasManager.Instance.dialogoUi.SetActive(false);
        }
    }
    public void entregouMissao(){
        if(it!= null && it.onMission){
             for(int i=0;i<Inventario.Instance.itens.Count;i++){
                for(int j=0;j<InteracaoManager.Instance.objetosDesejados.Count;j++){
                    if(Inventario.Instance.itens[i].name==InteracaoManager.Instance.objetosDesejados[j]){
                        it.onMissionComplete=true;
                        if(it.onMission){
                            InteracaoManager.Instance.dialogueObject= it.missaoConcluidaDialogueObject;
                            Debug.Log("chamar");
                            InteracaoManager.Instance.ChamarDialogoInicio();
                            it.onMission=false;
                        }
                        InteracaoManager.Instance.objetosDesejados.Remove(InteracaoManager.Instance.objetosDesejados[j]);
                        Inventario.Instance.itens.Remove(Inventario.Instance.itens[i]);
                        
                    }
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
