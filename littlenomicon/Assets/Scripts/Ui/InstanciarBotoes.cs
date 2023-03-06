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
    public GameObject panelPrincipal;
    public int faseId=0;
    public Button[] btnEscolhidoVolta;
    public Button[] btnProximo;
    bool abriuInventario=false;
    public Transform Item;
    GameObject lastselect;
    public Button btnAtual;
    public List<GameObject> BotoesItensInventario;
    public int maxItem;
     
    void Start()
    {
        NavegacaoItem();
        lastselect = new GameObject();
        Instance= this;
        actionReferenceEscape.action.started += context =>
        {
            if(abriuInventario!=true){
                QuandoAbreInventario();
            }else{
                 VoltarPanel();
            }
              
               
           
        };
        actionReferenceP.action.started += context =>
        {
            int rng = Random.Range(0,InteracaoManager.Instance.ObjetosInventario.Length);
            instanciar(InteracaoManager.Instance.ObjetosInventario[rng]);
           
        };
         actionReferenceI.action.started += context =>
        {
          // QuandoAbreInventario();
           //faseId=1;
           //abrir(panelPrincipal);
        };
        
    }
    
    public void instanciar(GameObject go){
        if(BotoesItensInventario.Count<maxItem){
        GameObject _go = Instantiate(go,go.transform.position,go.transform.rotation);
        _go.transform.SetParent(Item, false);
        BotoesItensInventario.Add(_go);
        NavegacaoItem();
    }
    }
    public void VoltarPanel(){
        if(faseId==0){
            QuandoFechaInventario();
        }else{
            if(faseId==1)fechar(panelPrincipal);
            if(faseId>1){
                fechar(panelOpcoes);
                fechar(panelsInfo);
            }
            ButtonSelected.Instance.SetSelected(btnEscolhidoVolta[faseId-1]);
            faseId--;
        }
        
        
    }
    public void abriuPanelPrincipal(GameObject _go){
        panelPrincipal=_go;
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
    public void NavegacaoItem(){
        if(BotoesItensInventario.Count>1){
        Button _btnUltimo = BotoesItensInventario[BotoesItensInventario.Count-1].GetComponent<Button>();
        Button _btnPrimeiro = BotoesItensInventario[0].GetComponent<Button>();
        Button _btnPenultimo = BotoesItensInventario[BotoesItensInventario.Count-2].GetComponent<Button>();
        SetNavegacao(_btnUltimo,_btnPrimeiro,_btnPenultimo);
        }
    }
    public void SetNavegacao(Button _ult,Button _pri ,Button _pen){
        Navigation navigation = _ult.navigation;
        navigation.mode = Navigation.Mode.Explicit;
        navigation.selectOnDown = _pri;
        if(BotoesItensInventario.Count>2) navigation.selectOnUp = _pen;
        _ult.navigation = navigation;
        for(int i=0;i<BotoesItensInventario.Count-1;i++){
            Button _btns = BotoesItensInventario[i].GetComponent<Button>();
            Navigation navigation2 = _btns.navigation;
            navigation2.mode = Navigation.Mode.Vertical;
            _btns.navigation=navigation2;
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
