using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    public Image icon;
    public TMP_Text texto;
    public TMP_FontAsset[] fontTexto;
    public GameObject dialogoUi;
    private int aux;
    
    private void Start()
    {
        Instance=this;
    }
    public void atualizarCanvasDialogo(Sprite _icon, string[] _texto, int _fontAssetId){
        icon.sprite =_icon;
        texto.text=_texto[0];
        texto.font = fontTexto[_fontAssetId];
    }
    public void passarDialogo(string[] _texto){
        aux++;
        if(aux<_texto.Length){
             texto.text=_texto[aux];
        }else{
            aux=0;
            dialogoUi.SetActive(false);
            PlayerController.Instance.dialogoAberto=false;
        }
       
    }
}
/*
        string[] textosDialogo = new string[_texto.Length];
        for(int i=0; i<_texto.Length; i++){
            textosDialogo[i]=_texto[i];
        }
        */