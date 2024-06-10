using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonAtaque : Carta
{
    public EnemyHealth enemyHealth; // Referencia al script EnemyHealth del enemigo
    [SerializeField] int dmg = 10;

    private void AtacarEnemigo()
    {
        // Verifica si el enemigo tiene el script EnemyHealth adjunto
        if (enemyHealth != null)
        {
            // Llama al m�todo Hurt para reducir la vida del enemigo
            enemyHealth.Hurt(dmg); // Cambia el valor de 10 por el da�o que desees infligir
        }
        else
        {
            Debug.LogError("�No se encontr� el script EnemyHealth en el enemigo!");
        }
    }

    public override void Action()
    {
        base.Action();
        AtacarEnemigo();
    }
}
