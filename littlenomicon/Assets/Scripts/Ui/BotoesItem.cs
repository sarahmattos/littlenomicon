using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotoesItem : MonoBehaviour
{
    public Button btn;
    public string textoInfo;
    public bool usavel;
    public bool equipado;
    public int id;
    public string nomeItem;
    // Start is called before the first frame update
    void Start()
    {
        btn = this.GetComponent<Button>();
        if(Bau.Instance.aberto){
            btn.onClick.AddListener(ClicouBau);
        }else{
            btn.onClick.AddListener(Clicou);
        }
        
    }

    public void Clicou(){
        ButtonSelected.Instance.SetSelected(InstanciarBotoes.Instance.btnProximo[1]);
        ButtonSelected.Instance.BotaoApertado(btn);
        InstanciarBotoes.Instance.abrir(InstanciarBotoes.Instance.panelOpcoes);
        InstanciarBotoes.Instance.atualizaInfos(this);
    }
    public void ClicouBau(){
        ButtonSelected.Instance.SetSelected(InstanciarBotoes.Instance.btnProximo[2]);
        InstanciarBotoes.Instance.abrir(Bau.Instance.opcao);
    }
}
