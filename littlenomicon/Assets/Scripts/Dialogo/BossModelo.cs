using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossModelo : MonoBehaviour
{
        public int vidaAtual;//diminui com ataque - visual interface
        public int vidaMaxima;
        public int cansaço;// diminui com acoes- visual falas
        public int raiva;// diminui com falas do jogador- visual falas
    // Update is called once per frame
    public abstract void Ataque(int tipoAtaque);
    
}
