using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonecoDeTreino_Boss : BossModelo
{
    // Start is called before the first frame update
    void Start()
    {
        vidaMaxima=10;
        cansaço=3;
        raiva=3;
    }
    //sequencia de ataques pre definida
    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Ataque(int tipoAtaque)
    {
        switch (tipoAtaque)
        {
        case 5:
            Debug.Log("Ataque 5");
            break;
        case 4:
            Debug.Log("Ataque 4");
            break;
        case 3:
            Debug.Log("Ataque 3");
            break;
        case 2:
            Debug.Log("Ataque 2");
            break;
        case 1:
            Debug.Log("Ataque 1");
            break;
        default:
            Debug.Log("Ataque default");
            break;
        }
    }
}
