using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.UI;
 using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{
    private Button btn;
    private PropertyInfo _selectableStateInfo = null;
    void Start()
    {
         btn = this.GetComponent<Button>();
        
    }
    private void Awake()
    {
         _selectableStateInfo = typeof(Selectable).GetProperty("currentSelectionState", BindingFlags.NonPublic | BindingFlags.Instance);
    }
 
    private void Update()
    {
        if(_selectableStateInfo.GetValue(btn).ToString()== "Selected"){
            InstanciarBotoes.Instance.btnAtual=btn;
        }
    }

    
}
