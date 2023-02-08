using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    public TMP_Text texto;
    private void Start()
    {
        Instance=this;
    }
    public void Update(){
        texto.text = PlayerController.Instance.Status.ToString();
    }
    
}