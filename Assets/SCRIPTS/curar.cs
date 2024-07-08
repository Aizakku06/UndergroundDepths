using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BotonCura : Carta, IPointerClickHandler
{
    public PlayerHealth playerHealth; // Referencia al script PlayerHealth del jugador
    public EnergySystem energySystem; // Referencia al sistema de energía
    [SerializeField] int healAmount = 10;
    public CartaManager cartaManager;

    private bool isDestroyed = false;

    // Costo de energía para esta carta
    public int energyCost = 1;

    public void DescartarEstaCarta()
    {
        cartaManager.DescartarCarta(this.transform.parent.gameObject); // Pasar el GameObject de la carta actual
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Verificar si hay suficiente energía
            if (energySystem.SpendEnergy(energyCost))
            {
                CurarPlayer();
                isDestroyed = true; // Marcar la carta para destrucción después de curar

                // Desactivar visualmente el botón (opcional)
                GetComponent<Button>().interactable = false;
            }
            else
            {
                Debug.Log("No hay suficiente energía para jugar esta carta.");
                // Aquí podrías agregar lógica adicional si el jugador no tiene suficiente energía
            }
        }
    }

    private void CurarPlayer()
    {
        // Verifica si el jugador tiene el script PlayerHealth adjunto
        if (playerHealth != null)
        {
            // Llama al método Heal para aumentar la vida del jugador
            playerHealth.Heal(healAmount); // Cura al jugador
        }
        else
        {
            Debug.LogError("¡No se encontró el script PlayerHealth en el jugador!");
        }
        DescartarEstaCarta();
    }

    private void Update()
    {
        // Verificar si la carta debe ser destruida
        if (isDestroyed)
        {
            Destroy(gameObject); // Destruir la carta
        }
    }

    public override void Action()
    {
        base.Action();
        // Este método puede ser utilizado para otras acciones si es necesario
    }
}
