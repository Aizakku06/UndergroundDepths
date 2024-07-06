using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BotonAtaque : Carta, IPointerClickHandler
{
    public EnemyHealth enemyHealth; // Referencia al script EnemyHealth del enemigo
    public EnergySystem energySystem; // Referencia al sistema de energ�a
    [SerializeField] int dmg = 10;
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
                    AtacarEnemigo();
                    isDestroyed = true; // Marcar la carta para destrucci�n despu�s del ataque

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

    private void AtacarEnemigo()
    {
        EnergySystem es = FindAnyObjectByType<EnergySystem>();
        bool usedCard = es.SpendEnergy(energyCost);

        if (usedCard) { 
        // Verifica si el enemigo tiene el script EnemyHealth adjunto
        if (enemyHealth != null)
        {
            // Llama al m�todo Hurt para reducir la vida del enemigo
            enemyHealth.Hurt(dmg); // Inflige el da�o al enemigo
        }
        else
        {
            Debug.LogError("�No se encontr� el script EnemyHealth en el enemigo!");
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
        // CurarPlayer();
    }
}
