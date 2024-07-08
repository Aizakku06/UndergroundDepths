using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] string levelToLoad;
    [SerializeField] string levelToLoadSecundary;
    public void Reiniciar()
    {
        SceneManager.LoadScene(levelToLoad);
        SceneManager.LoadScene(levelToLoadSecundary,LoadSceneMode.Additive);
    }

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
