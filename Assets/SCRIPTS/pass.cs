using UnityEngine;

public class AdvanceRoundButton : MonoBehaviour
{
    private RoundSystem roundSystem;
    private CartaManager cartaManager;
    public float disableDuration = 2.0f; // Duración en segundos para desactivar el botón

    // Referencia al Animator del enemigo
    [SerializeField] Animator enemyAnim;

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

        if (enemyAnim == null)
        {
            Debug.LogError("Enemy Animator no encontrado en la escena.");
        }
    }

    public void OnClick()
    {
        // Verificar si el jugador tiene 5 cartas en su mano
        if (cartaManager.manoList.Count == 5)
        {
            // Llamar la animación de ataque del enemigo
            enemyAnim.SetTrigger("atk");

            // Avanzar la ronda
            roundSystem.AdvanceRound(true);

            // Desactivar el GameObject del botón
            gameObject.SetActive(false);

            // Reactivar el botón después de disableDuration segundos
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
