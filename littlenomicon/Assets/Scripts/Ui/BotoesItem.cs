using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotoesItem : MonoBehaviour
{
    public Button btn;
    public string textoInfo;
    public bool usavel;
    public bool equipado=false;
    public int id;
    public string nomeItem;
    [HideInInspector]
     public string textoEquipar;
    // Start is called before the first frame update
    void Start()
    {
        btn = this.GetComponent<Button>();
        if(Bau.Instance.aberto){
            btn.onClick.AddListener(ClicouBau);
        }else{
            if(InstanciarBotoes.Instance.abriuInventario){
                btn.onClick.AddListener(Clicou);
            }
            if(InstanciarBotoes.Instance.abriuJornal){
                btn.onClick.AddListener(Clicou2);
            }
        }
        
    }

    public void Clicou(){
        ButtonSelected.Instance.SetSelected(InstanciarBotoes.Instance.btnProximo[1]);
        ButtonSelected.Instance.BotaoApertado(btn);
        InstanciarBotoes.Instance.abrir(InstanciarBotoes.Instance.panelOpcoes);
        InstanciarBotoes.Instance.atualizaInfos(this);
    }
    public void Clicou2(){
        ButtonSelected.Instance.SetSelected(InstanciarBotoes.Instance.btnProximo2[1]);
        InstanciarBotoes.Instance.abrir(InstanciarBotoes.Instance.panelsLerPagina);
        ButtonSelected.Instance.BotaoApertado(btn);
        InstanciarBotoes.Instance.atualizaInfos2(this);
    }
    public void ClicouBau(){
        ButtonSelected.Instance.SetSelected(InstanciarBotoes.Instance.btnProximo[2]);
        InstanciarBotoes.Instance.abrir(Bau.Instance.opcao);
        InstanciarBotoes.Instance.atualizaInfos(this);
    }
}
