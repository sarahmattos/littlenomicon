using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 move;
    private Animator anim;
    public Vector3 movement;
    public Vector3 lastPos;
    public bool interagir=false;
    private GameObject targetObjeto;
     private Interagivel it;

     public string test;

     public TMP_FontAsset fontTexto;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context){
        move = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        AnimatorManager();
        if(interagir==true){
            if(Input.GetKeyDown(KeyCode.E)){
                 //
            }
        }
        
    }
    public void movePlayer(){
        movement = new Vector3(move.x, 0f, move.y);
        if (movement != Vector3.zero) {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }
        //transform.rotation = Quaternion.Euler(0, movement, 0);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
    public void AnimatorManager(){
        
        if(transform.position != lastPos){
            anim.SetBool("walk",true);
        }
        else{
            anim.SetBool("walk",false);
        }
        lastPos = transform.position;
    }
    void OnTriggerEnter(Collider target)
    {
        if(target.tag == "Interagivel")
        {
            interagir=true;
            targetObjeto=target.gameObject;
            InfosDialogo();
        }
    }
    void OnTriggerExit(Collider target)
    {
        if(target.tag == "Interagivel")
        {
            interagir=false;
        }
    }
    public void InfosDialogo(){
        it =targetObjeto.GetComponent<Interagivel>();
        CanvasManager.Instance.dialogoUi.SetActive(true);
        CanvasManager.Instance.atualizarCanvasDialogo(it.icon, it.texto, it.fontAssetId);
    }
}
