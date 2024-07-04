using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BotonAtaque : MonoBehaviour, IPointerClickHandler
{
    public EnemyHealth enemyHealth; // Referencia al script EnemyHealth del enemigo
    [SerializeField] int dmg = 10;
    public CartaManager cartaManager;

    private bool isDestroyed = false;
    private float doubleClickTimeThreshold = 0.5f; // Umbral de tiempo para el doble clic
    private float lastClickTime = 0;
   
    
    public void DescartarEstaCarta()
    {
        cartaManager.DescartarCarta(gameObject); // Pasar el GameObject de la carta actual
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Verificar si es un doble clic
            if (Time.time - lastClickTime < doubleClickTimeThreshold)
            {
                // Es un doble clic
                AtacarEnemigo();
                isDestroyed = true; // Marcar la carta para destrucción después del ataque

                // Desactivar visualmente el botón (opcional)
                GetComponent<Button>().interactable = false;
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
        // Verifica si el enemigo tiene el script EnemyHealth adjunto
        if (enemyHealth != null)
        {
            // Llama al método Hurt para reducir la vida del enemigo
            enemyHealth.Hurt(dmg); // Inflige el daño al enemigo
        }
        else
        {
            Debug.LogError("¡No se encontró el script EnemyHealth en el enemigo!");
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
}
