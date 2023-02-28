using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ButtonSelected : MonoBehaviour
{
    [SerializeField] GameObject btnsOpcoes;
    public static ButtonSelected Instance;
   
    // Start is called before the first frame update
    public void Start()
    {
        Instance = this;
        
    }
    public void SetSelected(Button btn){
        btn.Select();
    }
    
    public void BotaoApertado(Button btn){
        InstanciarBotoes.Instance.AbrirPanel(btn);
    }
    
}
