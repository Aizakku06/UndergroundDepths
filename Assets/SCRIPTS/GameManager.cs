using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int hpPlayer;
    public int hpEnemigo;

    public Animator animatorPlayer;
    public Animator animatorEnemigo;

    public void Atacar()
    {
        //ejecutar la animacion de ataque del player
        animatorPlayer.Play("ataquePlayer");
        
    }

    public void EnemigoDaño()
    {
        // ejecutar la animacion de daño del enemigo
        animatorEnemigo.Play("enemigoDaño");
        // quitar vida a enemigo
    }


}
