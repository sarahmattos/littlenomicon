using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstanciarBotoes : MonoBehaviour
{
    // Start is called before the first frame update
    public Button botaoItens;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void instanciar(){
        Button _go = Instantiate(botaoItens,botaoItens.transform.position,botaoItens.transform.rotation);
        _go.transform.SetParent(this.transform, false);
    }
}
