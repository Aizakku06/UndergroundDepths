using UnityEngine;

public class Curar : Carta
{
    // Referencia al script PlayerHealth
    public PlayerHealth playerHealth;

    // Cantidad de salud que se curar� al jugador
    public int cantidadDeCura = 10;

    // M�todo para aumentar la salud en la cantidad especificada
    public void CurarPlayer()
    {
        // Verificamos que playerHealth no sea nulo
        if (playerHealth != null)
        {
            // Aumentamos la salud en la cantidad especificada
            playerHealth.Heal(cantidadDeCura);
        }
        else
        {
            Debug.LogError("El componente PlayerHealth no est� asignado.");
        }
    }

    public override void Action()
    {
        base.Action();
        CurarPlayer();
    }
}

