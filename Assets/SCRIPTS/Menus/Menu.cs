using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void EscenaNivel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

   

    public void EmpezarTuorial(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void EmpezarTutorialAditivo(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Aqui se cierra el juego");
    }
}