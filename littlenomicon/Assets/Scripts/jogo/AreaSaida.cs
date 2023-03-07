using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSaida : MonoBehaviour
{
    [SerializeField] GameObject objetoDesejado;
    public bool podePassar;
    public static AreaSaida Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }
    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {   
            Debug.Log("1");
            for(int i=0;i<InstanciarBotoes.Instance.BotoesItensInventario.Count; i++){
                BotoesItem btnItem = InstanciarBotoes.Instance.BotoesItensInventario[i].GetComponent<BotoesItem>();
                if(btnItem.nomeItem==objetoDesejado.name){
                    Debug.Log("passou fase");
                    podePassar=true;
                }
            }
        }
    }
    void OnTriggerExit(Collider target)
    {
        if (target.tag == "Player")
            {   
                podePassar=false;
            }      
    }
}
