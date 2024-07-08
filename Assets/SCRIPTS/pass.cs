using UnityEngine;

public class AdvanceRoundButton : MonoBehaviour
{
    private RoundSystem roundSystem;
    private CartaManager cartaManager;
    public float disableDuration = 2.0f; // Duraci�n en segundos para desactivar el bot�n

    void Start()
    {
        roundSystem = FindObjectOfType<RoundSystem>();
        cartaManager = FindObjectOfType<CartaManager>();

        if (roundSystem == null)
        {
            Debug.LogError("RoundSystem no encontrado en la escena.");
        }

        if (cartaManager == null)
        {
            Debug.LogError("CartaManager no encontrado en la escena.");
        }
    }

    public void OnClick()
    {
        // Verificar si el jugador tiene 5 cartas en su mano
        if (cartaManager.manoList.Count == 5)
        {
            // Avanzar la ronda
            roundSystem.AdvanceRound(true);

            // Desactivar el GameObject del bot�n
            gameObject.SetActive(false);

            // Reactivar el bot�n despu�s de disableDuration segundos
            Invoke("EnableButton", disableDuration);
        }
        else
        {
            Debug.Log("El jugador necesita tener 5 cartas en su mano para avanzar la ronda.");
        }
    }

    void EnableButton()
    {
        gameObject.SetActive(true);
    }
}
