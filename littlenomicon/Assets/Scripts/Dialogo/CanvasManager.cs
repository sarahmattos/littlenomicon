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
    public bool personagem;
    public bool jaConversou;
    private int aux;
    
    private void Start()
    {
        Instance=this;
    }
    public void atualizarCanvasDialogo(Sprite _icon, string[] _texto, int _fontAssetId, bool _personagem, bool _jaConversou){
        jaConversou=_jaConversou;
        if(jaConversou==false){
            dialogoUi.SetActive(true);
            icon.sprite =_icon;
            texto.text=_texto[0];
            texto.font = fontTexto[_fontAssetId];
            personagem=_personagem;
            PlayerController.Instance.dialogoAberto=true;
        }
        
    }
    public void passarDialogo(string[] _texto){
        aux++;
        if(aux<_texto.Length){
             texto.text=_texto[aux];
        }else{
            aux=0;
            dialogoUi.SetActive(false);
            if(personagem==true){
                PlayerController.Instance.DisableObject();
            }
            PlayerController.Instance.dialogoAberto=false;
        }
       
    }
}