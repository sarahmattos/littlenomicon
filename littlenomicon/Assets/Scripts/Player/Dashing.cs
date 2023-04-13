using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dashing : MonoBehaviour
{
    public Transform orientation;
    public Transform playerCam;
    private Rigidbody rb;
    private PlayerController pc;

    public float dashForce;
    public float dashUpwardForce;
    public float dashDuration;

    public float dashCd;
    private float dashCdTimer;

    public bool useCameraForward =true;
    public bool allowAllDirections =true;
    public bool disableGravity =false;
    public bool reseteVel =true;

    [SerializeField] InputActionReference actionReference;
    void Start()
    {
        actionReference.action.started += context =>
        {
             if(PlayerController.Instance.dialogoAberto==false && Bau.Instance.aberto==false && InstanciarBotoes.Instance.abriuInventario==false && InstanciarBotoes.Instance.abriuJornal==false)
            {
                Dash();
            }
        };
        rb = GetComponent<Rigidbody>();
        pc = GetComponent<PlayerController>();
    }
    private void Dash(){
        if(dashCdTimer>0)return;
        else dashCdTimer = dashCd;
        pc.isDashing=true;
        Vector3 direction = GetDirection(orientation);
        Vector3 forceToApply = orientation.forward * dashForce + orientation.up * dashUpwardForce;
        delayedForceToApply =forceToApply;
        Invoke(nameof(DelayedDashForce), 0.025f);
        Invoke(nameof(ResetDash), dashDuration);
    }
    private void ResetDash(){
        pc.isDashing=false;
    }
    private Vector3 delayedForceToApply;
    private void DelayedDashForce(){
        rb.AddForce(delayedForceToApply,ForceMode.Impulse);
    }
    // Update is called once per frame
    void Update()
    {
        if(dashCdTimer >0)
            dashCdTimer -=Time.deltaTime;
    }
    private void OnEnable()
    {
        actionReference.action.Enable();
    }
    private void OnDisable()
    {
        actionReference.action.Disable();
    }
    private Vector3 GetDirection(Transform forwardT){

        Vector3 direction = new Vector3();
        direction = forwardT.forward * pc.moveInput.y + forwardT.right * pc.moveInput.x;
        if(pc.moveInput.x==0 && pc.moveInput.y==0){
            direction = forwardT.forward;
        }
        return direction.normalized;
    }
}
