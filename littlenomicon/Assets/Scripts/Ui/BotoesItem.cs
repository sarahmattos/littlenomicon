using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotoesItem : MonoBehaviour
{
    private Button btn;
    public string textoInfo;
    // Start is called before the first frame update
    void Start()
    {
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(Clicou);
    }

    public void Clicou(){
        ButtonSelected.Instance.SetSelected(InstanciarBotoes.Instance.btnProximo[1]);
        ButtonSelected.Instance.BotaoApertado(btn);
        InstanciarBotoes.Instance.abrir(InstanciarBotoes.Instance.panelOpcoes);
        InstanciarBotoes.Instance.atualizaTexoInfo(textoInfo);
    }
}
