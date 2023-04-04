using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    // Start is called before the first frame update
    public float vida;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vida<=0){
            Destroy(this.gameObject);
        }
    }
}
