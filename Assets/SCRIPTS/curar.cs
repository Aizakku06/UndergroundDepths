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
    private float doubleClickTimeThreshold = 0.5f; // Umbral de tiempo para el doble clic
    private float lastClickTime = 0;

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
            // Verificar si es un doble clic
            if (Time.time - lastClickTime < doubleClickTimeThreshold)
            {
                // Es un doble clic
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
            else
            {
                // Primer clic
                lastClickTime = Time.time;
            }
        }
    }

    private void CurarPlayer()
    {
        EnergySystem es = FindAnyObjectByType<EnergySystem>();
        bool usedCard = es.SpendEnergy(energyCost);

        if (usedCard)
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
    }

    private void Update()
    {
        // Verificar si la carta debe ser destruida después del doble clic
        if (isDestroyed)
        {
            if (Time.time - lastClickTime >= doubleClickTimeThreshold)
            {
                Destroy(gameObject); // Destruir la carta después de un tiempo
            }
        }
    }

    public override void Action()
    {
        base.Action();
        // CurarPlayer(); // Esta línea se puede activar si se desea curar al jugador en algún otro momento
    }
}
