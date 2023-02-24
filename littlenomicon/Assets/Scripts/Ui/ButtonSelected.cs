using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelected : MonoBehaviour
{
    [SerializeField] GameObject btnsOpcoes;
    // Start is called before the first frame update
    
    public void SetSelected(Button btn){
        btn.Select();
    }
    public void panelTrue(Button btn){
        btnsOpcoes.SetActive(true);
         btn.Select();
    }
    public void panelFalse(GameObject go){
        go.SetActive(false);
    }
}
