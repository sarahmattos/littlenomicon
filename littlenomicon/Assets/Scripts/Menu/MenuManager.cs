using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Sair(){
             Application.Quit();
        }
        public void PassarCena(string nomeCena){
            SceneManager.LoadScene(nomeCena);
        }
}
