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
    private Interagivel it;
    public InputActionReference actionReference;

    private void Start()
    {
        Instance=this;
        anim = gameObject.GetComponent<Animator>();
        actionReference.action.started += context =>
        {

            //InfosDialogo();
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
            jaConversou=it.jaConversou;
            if(jaConversou==false){
                InteracaoManager.Instance.dialogueObject= it.startDialogueObject;
                if(it.conversaUmaVez==true)it.jaConversou=true;
            }else{
                InteracaoManager.Instance.dialogueObject= it.jaVisitouDialogueObject;
            }
            interagir = true;
            
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
