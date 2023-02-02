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
    
    private void Start()
    {
        Instance=this;
    }
    public void atualizarCanvasDialogo(Sprite _icon, string[] _texto, int _fontAssetId){
        icon.sprite =_icon;
        texto.text=_texto[0];
        texto.font = fontTexto[_fontAssetId];
        string[] textosDialogo = new string[_texto.Length];
        for(int i=0; i<_texto.Length; i++){
            textosDialogo[i]=_texto[i];
        }
    }
}
