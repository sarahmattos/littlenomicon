using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
 using UnityEngine.EventSystems;
using TMPro;
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
    [SerializeField] TMP_Text textoInfo;
    public int faseId=0;
    public BotoesItem itemClicadoAtual;
    public Button[] btnEscolhidoVolta;
    public Button[] btnProximo;
    bool abriuInventario=false;
    public Transform Item, ItemBau;
    GameObject lastselect;
    public Button btnAtual;
    public List<GameObject> BotoesItensInventario;
    public int maxItem;
    bool usavel;
     public Sprite Image1, Image2;
    void Start()
    {
        NavegacaoItem(BotoesItensInventario);
        lastselect = new GameObject();
        Instance= this;
        actionReferenceEscape.action.started += context =>
        {
            if(Bau.Instance.aberto==false){
                    if(abriuInventario!=true){
                    QuandoAbreInventario();
                        }else{
                            VoltarPanel();
                }
            }else{
                Bau.Instance.fecharBau();
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
    public void atualizaInfos( BotoesItem _btnItem){
        textoInfo.text=_btnItem.textoInfo;
        usavel = _btnItem.usavel;
        itemClicadoAtual = _btnItem;
    }
    public void usaOuEquipa(){
        if(usavel){
            //chamar funcao de usar
            Debug.Log("Item usado");
            //Inventario.Instance.itens.Remove(Inventario.Instance.itens[itemClicadoAtual.id]);
            int i=itemClicadoAtual.id;
            Destroy(InstanciarBotoes.Instance.BotoesItensInventario[i]);
            InstanciarBotoes.Instance.BotoesItensInventario.Remove(InstanciarBotoes.Instance.BotoesItensInventario[i]);
            NavegacaoItem(BotoesItensInventario);
        }else{
            //chamar funcao de equipar
            if(itemClicadoAtual.equipado){
                itemClicadoAtual.equipado=false;
                itemClicadoAtual.btn.GetComponent<Image>().sprite = Image2;
                 Debug.Log("Item desequipado");
            }else{
                 Debug.Log("Item equipado");
                itemClicadoAtual.btn.GetComponent<Image>().sprite = Image1;
                itemClicadoAtual.equipado=true;

            }
            
            //mudar nome do botao para desequipar
        }
        fechar(panelInventory);
        fechar(panelOpcoes);
        fechar(panelPrincipal);
        fechar(panelsInfo);
        faseId=0;
        QuandoFechaInventario();
    }
    public void largar(){
        int i=itemClicadoAtual.id;
        Destroy(InstanciarBotoes.Instance.BotoesItensInventario[i]);
        InstanciarBotoes.Instance.BotoesItensInventario.Remove(InstanciarBotoes.Instance.BotoesItensInventario[i]);
        Bau.Instance.adicionarItemBau(itemClicadoAtual.nomeItem);
        NavegacaoItem(BotoesItensInventario);
        NavegacaoItem(Bau.Instance.BotoesItensBau);
        fechar(panelInventory);
        fechar(panelOpcoes);
        fechar(panelPrincipal);
        fechar(panelsInfo);
        faseId=0;
        QuandoFechaInventario();
        
       
    }
    public void pegar(){
        int i=itemClicadoAtual.id;
        Destroy(Bau.Instance.BotoesItensBau[i]);
        Bau.Instance.BotoesItensBau.Remove(Bau.Instance.BotoesItensBau[i]);
        Bau.Instance.removerItemBau(itemClicadoAtual.nomeItem);
        NavegacaoItem(Bau.Instance.BotoesItensBau);
        NavegacaoItem(BotoesItensInventario);
        faseId=0;
        Bau.Instance.fecharBau();
        
       
    }
    public void instanciar(GameObject go){
        if(BotoesItensInventario.Count<maxItem){
        GameObject _go = Instantiate(go,go.transform.position,go.transform.rotation);
        _go.transform.SetParent(Item, false);
        BotoesItensInventario.Add(_go);
        NavegacaoItem(BotoesItensInventario);
        NavegacaoItem(Bau.Instance.BotoesItensBau);
        BotoesItem _go_Botao =_go.GetComponent<BotoesItem>();
        _go_Botao.id = BotoesItensInventario.Count-1;
            }
    }
    public void instanciarBau(GameObject go){
        if(Bau.Instance.BotoesItensBau.Count<maxItem){
        GameObject _go = Instantiate(go,go.transform.position,go.transform.rotation);
        _go.transform.SetParent(ItemBau, false);
        Bau.Instance.BotoesItensBau.Add(_go);
        NavegacaoItem(Bau.Instance.BotoesItensBau);
        NavegacaoItem(BotoesItensInventario);
        BotoesItem _go_Botao =_go.GetComponent<BotoesItem>();
        _go_Botao.id = Bau.Instance.BotoesItensBau.Count-1;
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
    public void NavegacaoItem(List<GameObject> _go){
        if(_go.Count>1){
        Button _btnUltimo = _go[_go.Count-1].GetComponent<Button>();
        Button _btnPrimeiro = _go[0].GetComponent<Button>();
        Button _btnPenultimo = _go[_go.Count-2].GetComponent<Button>();
        SetNavegacao(_btnUltimo,_btnPrimeiro,_btnPenultimo,  _go);
        }
    }
    public void SetNavegacao(Button _ult,Button _pri ,Button _pen, List<GameObject> _go){
        Navigation navigation = _ult.navigation;
        navigation.mode = Navigation.Mode.Explicit;
        navigation.selectOnDown = _pri;
        navigation.selectOnUp = _pen;
        _ult.navigation = navigation;
        for(int i=0;i<_go.Count-1;i++){
            Button _btns = _go[i].GetComponent<Button>();
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
