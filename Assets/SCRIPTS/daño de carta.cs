using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BotonAtaque : Carta, IPointerClickHandler
{
    public EnemyHealth enemyHealth; // Referencia al script EnemyHealth del enemigo
    public EnergySystem energySystem; // Referencia al sistema de energía
    [SerializeField] int dmg = 10;
    public CartaManager cartaManager;
    [SerializeField] GameObject anim;
    [SerializeField] float timeToTurnOffAnimation = 1;
    private bool isDestroyed = false;

    [SerializeField] UnityEvent onUseCard;
    [SerializeField] Animator playerAnim;

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
                onUseCard.Invoke();
                playerAnim.SetBool("ATK",true);
                AtacarEnemigo();
                isDestroyed = true; // Marcar la carta para destrucción después del ataque
                DescartarEstaCarta();

                // Desactivar visualmente el botón (opcional)
                GetComponent<Button>().interactable = false;
            }
            else
            {
                Debug.Log("No hay suficiente energía para jugar esta carta.");
                // Aquí podrías agregar lógica adicional si el jugador no tiene suficiente energía
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            // Lógica para clic derecho (activar animación, por ejemplo)
            ActivarAnimacion();
        }
    }

    private void AtacarEnemigo()
    {
        DescartarEstaCarta();
        // Verifica si el enemigo tiene el script EnemyHealth adjunto
        if (enemyHealth != null)
        {
            // Llama al método Hurt para reducir la vida del enemigo
            enemyHealth.Hurt(dmg); // Inflige el daño al enemigo
            anim.SetActive(true); // Activar la animación
            Invoke("TurnOffAnim", timeToTurnOffAnimation); // Desactivar la animación después de un tiempo
        }
        else
        {
            Debug.LogError("¡No se encontró el script EnemyHealth en el enemigo!");
        }
        
    }

    public void TurnOffAnim()
    {
        anim.SetActive(false);
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

    private void ActivarAnimacion()
    {
        // Aquí puedes activar la animación deseada para el clic derecho
        // Por ejemplo:
        anim.SetActive(true);
        Invoke("TurnOffAnim", timeToTurnOffAnimation); // Desactivar la animación después de un tiempo
    }
}
