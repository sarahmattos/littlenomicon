using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossModelo : MonoBehaviour
{
        public int vidaAtual{get;set;}//diminui com ataque - visual interface
        public int vidaMaxima{get;set;}
        public int cansaço{get;set;}// diminui com acoes- visual falas
        public int cansaçoInicial{get;set;}// diminui com acoes- visual falas
        public int raiva{get;set;}// diminui com falas do jogador- visual falas
        public int raivaInicial{get;set;}// diminui com falas do jogador- visual falas
        public bool acabouBatalha{get;set;}
    // Update is called once per frame
    public abstract void Ataque(int tipoAtaque);
    public abstract void Fala(int tipoFala);
    public abstract void checaMorte();
    
}
