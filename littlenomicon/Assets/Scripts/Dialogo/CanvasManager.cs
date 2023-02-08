using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    public TMP_Text texto, texto2;
    private void Start()
    {
        Instance=this;
    }
    public void Update(){
        texto.text = "Status: "+PlayerController.Instance.Status.ToString();
        texto2.text = "Dinheiro: "+PlayerController.Instance.Dinheiro.ToString();
    }
    
}