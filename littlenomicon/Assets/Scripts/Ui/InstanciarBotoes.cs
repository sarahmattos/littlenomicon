using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
 using UnityEngine.EventSystems;
using TMPro;
public class InstanciarBotoes : MonoBehaviour
{
   
    public static InstanciarBotoes Instance;

    [Header("ReferenciasCena")]
    public InputActionReference actionReferenceEscape;
    public InputActionReference actionReferenceJ;
    public InputActionReference actionReferenceI;
    public InputActionReference actionReferenceP;
    public GameObject panelOpcoes;
    [SerializeField] GameObject panelInventory;
    [SerializeField] GameObject panelJornal;
    [SerializeField] GameObject panelsInfo;
    [SerializeField] public GameObject panelsLerPagina;
    [SerializeField] TMP_Text textoInfo;
    [SerializeField] TMP_Text textoInfo2;
    [SerializeField] TMP_Text  botaoEquipar;
    [SerializeField] Sprite Image1, Image2;
    public Transform Item, ItemBau, Paginas;
    public Button[] btnProximo;
    public Button[] btnProximo2;
    

    [HideInInspector]
    [SerializeField] Button[] btnEscolhidoVolta;
    [HideInInspector]
    [SerializeField] Button[] btnEscolhidoVolta2;


    [Header("VariaveisScript")]
    public int maxItem;
    public List<GameObject> BotoesItensInventario;
    public List<GameObject> BotoesItensJornal;
    private bool usavel;
    public int faseId=0;
    private BotoesItem itemClicadoAtual;
    private GameObject panelPrincipal;
    private Transform pai;
    

    [HideInInspector]
    public Button btnAtual;

    [HideInInspector]
    public bool abriuInventario=false;
    public bool abriuJornal=false;
    
    
    void Start()
    {
        btnEscolhidoVolta2 = new Button[2];
        Cursor.visible = false;
        NavegacaoItem(BotoesItensInventario);
        NavegacaoItem(BotoesItensJornal);
        
        Instance= this;
        actionReferenceEscape.action.started += context =>
        {
            if(abriuJornal!=true){
                if(Bau.Instance.aberto==false){
                        if(abriuInventario!=true){
                        QuandoAbreInventario();
                            }else{
                                VoltarPanel();
                    }
                }else{
                    Bau.Instance.fecharBau();
                }
            }else{
                VoltarPanel2();
            }
            
           
        };
        actionReferenceJ.action.started += context =>
        {
            QuandoAbreJornal();
        };
        actionReferenceP.action.started += context =>
        {
            if(abriuInventario){
                int rng = Random.Range(0,InteracaoManager.Instance.ObjetosInventario.Length);
                instanciar(InteracaoManager.Instance.ObjetosInventario[rng], BotoesItensInventario, Item);
            }
            if(abriuJornal){
                instanciar(InteracaoManager.Instance.ObjetosInventario[3], BotoesItensJornal, Paginas);
            }
            
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
        if(usavel){
            itemClicadoAtual.textoEquipar = "Usar";
        }else{
            if(itemClicadoAtual.equipado){
                itemClicadoAtual.textoEquipar="Desequipar";
                
            }else{
                itemClicadoAtual.textoEquipar = "Equipar";
            }
            
        }
        botaoEquipar.text =itemClicadoAtual.textoEquipar;
    }
     public void atualizaInfos2( BotoesItem _btnItem){
        textoInfo2.text=_btnItem.textoInfo;
     }
    public void usaOuEquipa(){
        if(usavel){
            Debug.Log("Item usado");
            int i=itemClicadoAtual.id;
            Destroy(BotoesItensInventario[i]);
            BotoesItensInventario.Remove(BotoesItensInventario[i]);
            resetaIdsNavegacao(BotoesItensInventario);
            FecharInterfaceInteira();
        }else{
            if(itemClicadoAtual.equipado){
                itemClicadoAtual.btn.GetComponent<Image>().sprite = Image2;
                 Debug.Log("Item desequipado");
                 itemClicadoAtual.textoEquipar="Equipar";
                botaoEquipar.text =itemClicadoAtual.textoEquipar;
                itemClicadoAtual.equipado=false;
            }else{
                 Debug.Log("Item equipado");
                itemClicadoAtual.btn.GetComponent<Image>().sprite = Image1;
                itemClicadoAtual.textoEquipar="Desequipar";
                botaoEquipar.text =itemClicadoAtual.textoEquipar;
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
    public void VoltarPanel2(){
        if(faseId==0){
            QuandoFechaJornal();
        }else{
                fechar(panelsLerPagina);
            //ver isso
            ButtonSelected.Instance.SetSelected(btnEscolhidoVolta2[faseId-1]);
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
        if(abriuInventario)btnEscolhidoVolta[faseId]=btn;
        if(abriuJornal)btnEscolhidoVolta2[faseId]=btn;
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
        //Cursor.visible = true;

        fechar(panelInventory);
        abriuInventario=false;
    }
     public void QuandoFechaJornal(){
        Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;

        fechar(panelJornal);
        abriuJornal=false;
    }
    public void QuandoAbreInventario(){
        if(abriuInventario==false){
           Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
            
            ButtonSelected.Instance.SetSelected(btnProximo[0]);
            abrir(panelInventory);
            abriuInventario=true;
        }
    }
    
    public void QuandoAbreJornal(){
        if(abriuJornal==false){
           Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
            
            ButtonSelected.Instance.SetSelected(btnProximo2[0]);
            abrir(panelJornal);
            abriuJornal=true;
        }
    }
    public void NavegacaoItem(List<GameObject> _go){
        if(_go.Count>1){
        Button _btnUltimo = _go[_go.Count-1].GetComponent<Button>();
        Button _btnPrimeiro = _go[0].GetComponent<Button>();
        Button _btnPenultimo = _go[_go.Count-2].GetComponent<Button>();
        SetNavegacao(_btnUltimo,_btnPrimeiro,_btnPenultimo,  _go);
        }else if(_go.Count==1){
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
                       // Cursor.visible = false;
                    }

            }        
     }

}
