using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocoCamera : MonoBehaviour
{
    public static FocoCamera Instance;
    public Transform targetGoblin;
    public Transform targetPivo;
    public Transform targetCabeça;
    public float smoothTime = 0.3f;
    //public Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    public bool focar=false;
    public Vector3 offset;
    
    public float sensibilidade = 2.0f;

	private float mouseX = 0.0f, mouseY = 0.0f;
    float aux;
    // Start is called before the first frame update
    void Start()
    {
        aux=smoothTime+1f;;
        Instance =this;
        transform.position=targetGoblin.position+ new Vector3(0,4,-5);
        CameraSolta();
    }

    void Update()
    {
        //rotate();
        if (focar)
        {
            CameraParada();
        }
            else{ 
                CameraSolta();
            }
    }
    public void rotate(){
         mouseX += Input.GetAxis("Mouse X") * sensibilidade; // Incrementa o valor do eixo X e multiplica pela sensibilidade
		mouseY -= Input.GetAxis("Mouse Y") * sensibilidade; // Incrementa o valor do eixo Y e multiplica pela sensibilidade. (Obs. usamos o - para inverter os valores)

		transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }
    public void CameraParada(){
//        Vector3 targetPosition = targetPivo.position;
   //     transform.position = Vector3.SmoothDamp(transform.position +new Vector3(mouseY, mouseX, 0), targetPosition, ref velocity, smoothTime);
   //     transform.LookAt(targetCabeça);
    }
    public void CameraSolta(){
        Vector3 targetPosition = targetGoblin.position + offset;
        if(aux>0){
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            aux-=Time.deltaTime;
        }else{
                transform.position=targetPosition;
        }
        transform.LookAt(targetGoblin);
        
    }
    public void recebeTargets(Transform _targetPivo,Transform _targetCabeça){
        targetPivo=_targetPivo;
        targetCabeça=_targetCabeça;
    }
}
