using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Final : MonoBehaviour
{
    public void IrAlMenu(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Aqui se cierra el juego");
    }
}
