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
                isDestroyed = true; // Marcar la carta para destrucci�n despu�s del ataque

                // Desactivar visualmente el bot�n (opcional)
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
            // Llama al m�todo Hurt para reducir la vida del enemigo
            enemyHealth.Hurt(dmg); // Inflige el da�o al enemigo
        }
        else
        {
            Debug.LogError("�No se encontr� el script EnemyHealth en el enemigo!");
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
}
