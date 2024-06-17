using UnityEngine;
using UnityEngine.UI;

public class RoundSystem : MonoBehaviour
{
    public int currentRound = 1;
    public int maxRounds = 10;

    public Text roundText; // Ahora es pública para poder asignarla desde el Editor

    void Start()
    {
        UpdateRoundText();
    }

    public void AdvanceRound()
    {
        currentRound++;
        UpdateRoundText();

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
