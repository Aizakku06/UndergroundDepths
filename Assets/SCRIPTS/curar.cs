using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class BotonCura : Carta, IPointerClickHandler
{
    public PlayerHealth playerHealth; // Referencia al script PlayerHealth del jugador
    public EnergySystem energySystem; // Referencia al sistema de energ�a
    [SerializeField] int healAmount = 10;
    public CartaManager cartaManager;
    [SerializeField] GameObject anim;
    [SerializeField] float timeToTurnOffAnimation = 1;
    private bool isDestroyed = false;

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
    }

    private void CurarPlayer()
    {
        anim.SetActive(true);
        DescartarEstaCarta();
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
}
