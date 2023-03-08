using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bau : MonoBehaviour
{
    public static Bau Instance;
    public void Start()
    {
        Instance=this;
    }
     public List<GameObject> BotoesItensBau;
     public void adicionarItemBau( string nome){
        for(int i=0;i<InteracaoManager.Instance.ObjetosInventario.Length;i++){
             if(InteracaoManager.Instance.ObjetosInventario[i].name==nome) {
                 InstanciarBotoes.Instance.instanciarBau(InteracaoManager.Instance.ObjetosInventario[i]);
            }
        }
     }
}
