using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject ObjectMenuPausa;
    public bool Stop = false;
    public GameObject MenuSalir;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Stop == false)
            {
                ObjectMenuPausa.SetActive(true);
                Stop = true;

                Time.timeScale = 0;
            }
            else if(Stop == true)
            {
                Resumir();
            }
        }
    }

    public void Resumir()
    {
        ObjectMenuPausa.SetActive(false);
        MenuSalir.SetActive(false);
        Stop = false;

        Time.timeScale = 1;
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
