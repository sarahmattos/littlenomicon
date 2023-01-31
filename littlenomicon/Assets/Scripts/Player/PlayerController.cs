using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 move;
    private Animator anim;
    public Vector3 movement;
    public Vector3 lastPos;

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
        
    }
    public void movePlayer(){
        movement = new Vector3(move.x, 0f, move.y);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
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
}
