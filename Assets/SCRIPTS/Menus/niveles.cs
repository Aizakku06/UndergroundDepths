using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class niveles : MonoBehaviour
{
    public void EmpezarNivel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void EmpezarNivelAditivo(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void EmpezarTuorial(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void EmpezarTutorialAditivo(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void IrAlMenu(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
    }

}
