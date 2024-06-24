using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundSystem : MonoBehaviour
{
    public int currentRound = 1;
    public int maxRounds = 10;

    public TextMeshProUGUI roundText; // Ahora es p�blica para poder asignarla desde el Editor
    public PlayerControl pc;
    public EnemyControl ec;


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
            Debug.Log("�El juego ha terminado!");
            // Aqu� podr�as agregar l�gica adicional para manejar la finalizaci�n del juego.
        }
        else
        {
            Debug.Log($"Comenzando la ronda {currentRound}");
            // Aqu� podr�as iniciar la siguiente ronda, por ejemplo, cargar nuevos enemigos o reiniciar los valores necesarios.
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
