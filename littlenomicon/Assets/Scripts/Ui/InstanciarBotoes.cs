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
    public bool abriuInventario=false;
    public Transform Item, ItemBau;
    GameObject lastselect;
    public Button btnAtual;
    public List<GameObject> BotoesItensInventario;
    public int maxItem;
    bool usavel;
     public Sprite Image1, Image2;
     public Transform pai;
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
            instanciar(InteracaoManager.Instance.ObjetosInventario[rng], BotoesItensInventario, Item);
            
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
            int i=itemClicadoAtual.id;
            Destroy(BotoesItensInventario[i]);
            BotoesItensInventario.Remove(BotoesItensInventario[i]);
            resetaIdsNavegacao(BotoesItensInventario);
            FecharInterfaceInteira();
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
        
    }
    
    public void chamaFuncaoPegarLargar(int funcao){
        if(funcao==0) {
            pai = ItemBau;
            pegarOuLargar(Bau.Instance.BotoesItensBau,Instance.BotoesItensInventario);
        }
        if(funcao==1){
            pai = Item;
            pegarOuLargar(BotoesItensInventario,Bau.Instance.BotoesItensBau);
        }
    }
    public void pegarOuLargar(List<GameObject> _listaAdicionar,List<GameObject> _listaRemover){
        int i=itemClicadoAtual.id;
        Destroy(_listaRemover[i]);
        _listaRemover.Remove(_listaRemover[i]);
        for(int j=0;j<InteracaoManager.Instance.ObjetosInventario.Length;j++){
             if(InteracaoManager.Instance.ObjetosInventario[j].name==itemClicadoAtual.nomeItem) {
                  instanciar(InteracaoManager.Instance.ObjetosInventario[j],_listaAdicionar,pai);
            } 
        }
        resetaIdsNavegacao(_listaAdicionar);
        resetaIdsNavegacao(_listaRemover);
        FecharInterfaceInteira();
       
    }
    public void instanciar(GameObject go, List<GameObject> lista, Transform _pai){
        if(lista.Count<maxItem){
            GameObject _go = Instantiate(go,go.transform.position,go.transform.rotation);
            _go.transform.SetParent(_pai, false);
            lista.Add(_go);
            resetaIdsNavegacao(lista);
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
    public void FecharInterfaceInteira(){
        fechar(panelInventory);
        fechar(panelOpcoes);
        fechar(panelPrincipal);
        fechar(panelsInfo);
        faseId=0;
        QuandoFechaInventario();
        Bau.Instance.fecharBau();
    }
    public void resetaIdsNavegacao(List<GameObject> lista)
    {
        NavegacaoItem(lista);
        for(int i=0;i<lista.Count;i++){
            BotoesItem _go_Botao = lista[i].GetComponent<BotoesItem>();
            _go_Botao.id = i;
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
        }else{
             Button _btn = _go[0].GetComponent<Button>();
             Navigation navigation = _btn.navigation;
             navigation.mode = Navigation.Mode.None;
             _btn.navigation=navigation;
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
