using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
 using UnityEngine.EventSystems;

public class InstanciarBotoes : MonoBehaviour
{
    // Start is called before the first frame update
    public static InstanciarBotoes Instance;
    public InputActionReference actionReferenceEscape;
     public InputActionReference actionReferenceI;
     public InputActionReference actionReferenceP;
    public GameObject botaoItens;
    public GameObject panelInventory;
    public GameObject panelOpcoes;
    public GameObject panelsInfo;
    public int faseId=0;
    public Button[] btnEscolhidoVolta;
    public Button[] btnProximo;
    bool abriuInventario=false;
    public Transform Item;
    GameObject lastselect;
    public Button btnAtual;
    public List<GameObject> BotoesItensInventario;
     
    void Start()
    {
        lastselect = new GameObject();
        Instance= this;
        actionReferenceEscape.action.started += context =>
        {
            if(faseId!=0){
                VoltarPanel();
            }else{
                fechar(panelInventory);
                QuandoFechaInventario();
            }
           
        };
        actionReferenceP.action.started += context =>
        {
            instanciar(botaoItens);
           
        };
         actionReferenceI.action.started += context =>
        {
           QuandoAbreInventario();
        };
        
    }
    
    public void instanciar(GameObject go){
        GameObject _go = Instantiate(go,go.transform.position,go.transform.rotation);
        _go.transform.SetParent(Item, false);
        BotoesItensInventario.Add(_go);
    }
    public void VoltarPanel(){
        //if(faseId>= 2&& faseId<=3)fechar(panelsFechar[faseId]);
        fechar(panelOpcoes);
        fechar(panelsInfo);
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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        fechar(panelInventory);
        abriuInventario=false;
    }
    public void QuandoAbreInventario(){
        if(abriuInventario==false){
           Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
            ButtonSelected.Instance.SetSelected(btnProximo[0]);
            abrir(panelInventory);
            abriuInventario=true;
        }
    }
     void Update () {         
       if( abriuInventario==true)
            {
                if (EventSystem.current.currentSelectedGameObject == null)
                    {
                        btnAtual.Select();
                        Cursor.lockState = CursorLockMode.Locked;
                        Cursor.visible = false;
                    }

            }        
     }

}
