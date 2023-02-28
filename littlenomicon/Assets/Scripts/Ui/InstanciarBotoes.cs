using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class InstanciarBotoes : MonoBehaviour
{
    // Start is called before the first frame update
    public static InstanciarBotoes Instance;
    public InputActionReference actionReferenceEscape;
     public InputActionReference actionReferenceI;
    public Button botaoItens;
    public GameObject panelInventory;
    public GameObject panelOpcoes;
    public int faseId=0;
    public Button[] btnEscolhidoVolta;
    public Button btnItem;
    bool abriuInventario=false;
    void Start()
    {
        Instance= this;
        actionReferenceEscape.action.started += context =>
        {
            if(faseId!=0){
                VoltarPanel();
            }
           
        };
         actionReferenceI.action.started += context =>
        {
           QuandoAbreInventario();
        };
        
    }

    // Update is called once per frame
    
    public void instanciar(){
        Button _go = Instantiate(botaoItens,botaoItens.transform.position,botaoItens.transform.rotation);
        _go.transform.SetParent(this.transform, false);
    }
    public void VoltarPanel(){
        fechar(panelOpcoes);
        ButtonSelected.Instance.SetSelected(btnEscolhidoVolta[faseId-1]);
        faseId--;
    }
    public void AbrirPanel(Button btn){
        btnEscolhidoVolta[faseId]=btn;
         faseId++;
    }
    public void abrir(GameObject go){
        go.SetActive(true);
    }
    public void fechar(GameObject go){
         go.SetActive(false);
    }
    public void QuandoFechaInventario(){
        abriuInventario=false;
    }
    public void QuandoAbreInventario(){
        if(abriuInventario==false){
            ButtonSelected.Instance.SetSelected(btnItem);
            abrir(panelInventory);
            abriuInventario=true;
        }
    }

}
