using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vendas : MonoBehaviour
{
    public static Vendas Instance;
    [SerializeField] GameObject uiComercio;
    [SerializeField] Button primeiroButton;
    void Start()
    {
        Instance= this;
    }

    
    void Update()
    {
        
    }
    public void abrirVendas(){
        InstanciarBotoes.Instance.abriuVendas = true;
        uiComercio.SetActive(true);
        ButtonSelected.Instance.SetSelected(primeiroButton);
    }
    public void fecharVendas(){
        InstanciarBotoes.Instance.abriuVendas = false;
        uiComercio.SetActive(false);
    }

}
