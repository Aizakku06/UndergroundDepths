using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BotonAtaque : Carta, IPointerClickHandler
{
    public EnemyHealth enemyHealth; // Referencia al script EnemyHealth del enemigo
    public EnergySystem energySystem; // Referencia al sistema de energ�a
    [SerializeField] int dmg = 10;
    public CartaManager cartaManager;
    [SerializeField] GameObject anim;
    [SerializeField] float timeToTurnOffAnimation = 1;
    private bool isDestroyed = false;

    [SerializeField] UnityEvent onUseCard;
    [SerializeField] Animator playerAnim;

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
            // Verificar si hay suficiente energ�a
            if (energySystem.SpendEnergy(energyCost))
            {
                onUseCard.Invoke();
                playerAnim.SetBool("ATK",true);
                AtacarEnemigo();
                isDestroyed = true; // Marcar la carta para destrucci�n despu�s del ataque
                DescartarEstaCarta();

                // Desactivar visualmente el bot�n (opcional)
                GetComponent<Button>().interactable = false;
            }
            else
            {
                Debug.Log("No hay suficiente energ�a para jugar esta carta.");
                // Aqu� podr�as agregar l�gica adicional si el jugador no tiene suficiente energ�a
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            // L�gica para clic derecho (activar animaci�n, por ejemplo)
            ActivarAnimacion();
        }
    }

    private void AtacarEnemigo()
    {
        DescartarEstaCarta();
        // Verifica si el enemigo tiene el script EnemyHealth adjunto
        if (enemyHealth != null)
        {
            // Llama al m�todo Hurt para reducir la vida del enemigo
            enemyHealth.Hurt(dmg); // Inflige el da�o al enemigo
            anim.SetActive(true); // Activar la animaci�n
            Invoke("TurnOffAnim", timeToTurnOffAnimation); // Desactivar la animaci�n despu�s de un tiempo
        }
        else
        {
            Debug.LogError("�No se encontr� el script EnemyHealth en el enemigo!");
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
        // Este m�todo puede ser utilizado para otras acciones si es necesario
    }

    private void ActivarAnimacion()
    {
        // Aqu� puedes activar la animaci�n deseada para el clic derecho
        // Por ejemplo:
        anim.SetActive(true);
        Invoke("TurnOffAnim", timeToTurnOffAnimation); // Desactivar la animaci�n despu�s de un tiempo
    }
}
