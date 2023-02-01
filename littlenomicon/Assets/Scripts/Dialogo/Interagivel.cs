using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ObjetoInteragivel", menuName = "Interagivel/Novo")]
public class Interagivel : ScriptableObject
{
    public Sprite icon;
    public string[] texto;
    public Font fontTexto;
}

