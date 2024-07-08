using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
   public void EmpezarNivel(string Mike)
    {
        SceneManager.LoadScene(Mike);
    }
    
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Aqui se cierra el juego");
    }
}
