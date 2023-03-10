using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bau : MonoBehaviour
{
    public static Bau Instance;
    public bool interagirBau, aberto;
    [SerializeField]public GameObject bauUi;
    [SerializeField]public GameObject opcao;
    public void Start()
    {
        Instance=this;
    }
     public List<GameObject> BotoesItensBau;
     
     void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            interagirBau = true;
        }
    }
     void OnTriggerExit(Collider target)
    {
        if (target.tag == "Player")
        {
            interagirBau = false;
        }
    }
    public void abrirBau(){
        bauUi.SetActive(true);
        if(BotoesItensBau.Count>0){
            Button btn =BotoesItensBau[0].GetComponent<Button>();
            ButtonSelected.Instance.SetSelected(btn);
        }
        
        aberto=true;
    }
    public void fecharBau(){
        bauUi.SetActive(false);
        opcao.SetActive(false);
        aberto=false;
    }
}
