using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public static Inventario Instance;
    public List<GameObject> itens;
    private void Start()
    {
        Instance=this;
    }
}
[System.Serializable]
public struct itens{
    public string Nome;
    
}
