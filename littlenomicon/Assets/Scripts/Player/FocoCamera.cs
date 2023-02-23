using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocoCamera : MonoBehaviour
{
    public Transform targetGoblin;
    public Transform targetPivo;
    public Transform targetCabeça;
    public float smoothTime = 0.3f;
    //public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    public bool focar=false;

    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        transform.position=targetGoblin.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (focar)
        {
            CameraParada(targetPivo, targetCabeça);
        }
            else{ 
                CameraSolta();
            }
    }
    public void CameraParada(Transform _targetPivo,Transform _targetCabeça){
        Vector3 targetPosition = _targetPivo.position;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.LookAt(_targetCabeça);
    }
    public void CameraSolta(){
        Vector3 targetPosition = targetGoblin.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.LookAt(targetGoblin);
    }
}
