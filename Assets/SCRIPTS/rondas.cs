using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundSystem : MonoBehaviour
{
    public int currentRound = 1;
    public int maxRounds = 10;

    public TextMeshProUGUI roundText; // Ahora es pública para poder asignarla desde el Editor
    public PlayerHealth ph;
    public EnemyHealth eh;

    public bool playerTurn = true;


    void Start()
    {
        UpdateRoundText();
    }

    public void AdvanceRound(bool id)
    {
        //if(id != playerTurn) return;

        currentRound++;
        UpdateRoundText();


        playerTurn = !playerTurn;

        if (currentRound > maxRounds)
        {
            Debug.Log("¡El juego ha terminado!");
            // Aquí podrías agregar lógica adicional para manejar la finalización del juego.
        }
        else
        {
            Debug.Log($"Comenzando la ronda {currentRound}");
            // Aquí podrías iniciar la siguiente ronda, por ejemplo, cargar nuevos enemigos o reiniciar los valores necesarios.
        }

        /*
        if(playerTurn == false)
        {
            eh.EnemyTurn();
        }
        */
    }

    public void UpdateRoundText()
    {
        if (roundText != null)
        {
            roundText.text = $"Ronda {currentRound}/{maxRounds}";
        }
        else
        {
            Debug.LogWarning("El componente Text no ha sido asignado al script RoundSystem.");
        }
    }
}
