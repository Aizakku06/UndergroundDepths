using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BotonCura : Carta, IPointerClickHandler
{
    public PlayerHealth playerHealth; // Referencia al script PlayerHealth del jugador
    public EnergySystem energySystem; // Referencia al sistema de energ�a
    [SerializeField] int healAmount = 10;
    public CartaManager cartaManager;

    private bool isDestroyed = false;
    private float doubleClickTimeThreshold = 0.5f; // Umbral de tiempo para el doble clic
    private float lastClickTime = 0;

    // Costo de energ�a para esta carta
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
                    isDestroyed = true; // Marcar la carta para destrucci�n despu�s de curar

                    // Desactivar visualmente el bot�n (opcional)
                    GetComponent<Button>().interactable = false;
                }
                else
                {
                    Debug.Log("No hay suficiente energ�a para jugar esta carta.");
                    // Aqu� podr�as agregar l�gica adicional si el jugador no tiene suficiente energ�a
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
                // Llama al m�todo Heal para aumentar la vida del jugador
                playerHealth.Heal(healAmount); // Cura al jugador
            }
            else
            {
                Debug.LogError("�No se encontr� el script PlayerHealth en el jugador!");
            }
            DescartarEstaCarta();
        }
    }

    private void Update()
    {
        // Verificar si la carta debe ser destruida despu�s del doble clic
        if (isDestroyed)
        {
            if (Time.time - lastClickTime >= doubleClickTimeThreshold)
            {
                Destroy(gameObject); // Destruir la carta despu�s de un tiempo
            }
        }
    }

    public override void Action()
    {
        base.Action();
        // CurarPlayer(); // Esta l�nea se puede activar si se desea curar al jugador en alg�n otro momento
    }
}
