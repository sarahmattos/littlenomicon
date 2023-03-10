using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Sair(){
             Application.Quit();
        }
        public void PassarCena(string nomeCena){
            SceneManager.LoadScene(nomeCena);
        }
}
