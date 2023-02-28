using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.UI;
 using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{
    private Button btn;
    //public Selectable AnySelectable;
    private PropertyInfo _selectableStateInfo = null;
    // Start is called before the first frame update
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
        //Debug.Log(_selectableStateInfo.GetValue(btn));
        if(_selectableStateInfo.GetValue(btn).ToString()== "Selected"){
            InstanciarBotoes.Instance.btnAtual=btn;
        }
    }

    // Update is called once per frame
    
}
