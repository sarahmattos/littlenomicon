using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] Transform targetPlayer;
    void Start()
    {
        GameObject player =  GameObject.Find("Player");
        targetPlayer = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPostition = new Vector3( targetPlayer.position.x,transform.position.y,  targetPlayer.transform.position.z ) ;
        transform.LookAt(targetPostition);
    }
    public void Ataque(int tipoAtaque)
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
