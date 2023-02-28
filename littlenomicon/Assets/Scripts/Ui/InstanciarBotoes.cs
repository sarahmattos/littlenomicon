using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class InstanciarBotoes : MonoBehaviour
{
    // Start is called before the first frame update
    public static InstanciarBotoes Instance;
    public InputActionReference actionReferenceEscape;
     public InputActionReference actionReferenceI;
    public Button botaoItens;
    public GameObject[] panelInventory;
    public int faseId=0;
    public Button btnEscolhidoVolta;
    void Start()
    {
        Instance= this;
        actionReferenceEscape.action.started += context =>
        {
           VoltarPanel();
        };
         actionReferenceI.action.started += context =>
        {
           AbrirIventario();
        };
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void instanciar(){
        Button _go = Instantiate(botaoItens,botaoItens.transform.position,botaoItens.transform.rotation);
        _go.transform.SetParent(this.transform, false);
    }
    public void VoltarPanel(){
        ButtonSelected.Instance.SetSelected(btnEscolhidoVolta);
        panelInventory[faseId].SetActive(false);
        faseId--;
        
    }
    public void AbrirPanel(Button btn){
        panelInventory[faseId].SetActive(true);
        if(faseId<panelInventory.Length-1){
            faseId++;
        }
        btnEscolhidoVolta=btn;
        
    }
    public void AbrirIventario(){
         panelInventory[0].SetActive(true);
         faseId++;
    }

}
