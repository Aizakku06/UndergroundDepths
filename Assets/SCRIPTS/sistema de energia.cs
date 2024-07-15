using UnityEngine;
using TMPro; // Aseg�rate de importar TMPro
using System.Collections; // Necesario para utilizar corutinas

public class EnergySystem : MonoBehaviour
{
    public int maxEnergy = 3; // Energ�a m�xima que puede tener el jugador
    public int currentEnergy = 3; // Energ�a actual del jugador
    public TMP_Text energyText; // Referencia al objeto TextMeshPro que mostrar� la energ�a actual

    public float cooldownTime = 2.0f; // Tiempo de cooldown despu�s de jugar una carta (en segundos)
    private bool isOnCooldown = false; // Variable que indica si estamos en cooldown

    void Start()
    {
        UpdateEnergyUI();
    }

    // Funci�n para actualizar el texto que muestra la energ�a actual
    void UpdateEnergyUI()
    {
        energyText.text = "" + currentEnergy;
    }

    // Funci�n para restar energ�a al jugar una carta con un costo espec�fico
    public bool SpendEnergy(int energyCost)
    {
        if (currentEnergy >= energyCost && !isOnCooldown)
        {
            currentEnergy -= energyCost;
            UpdateEnergyUI();
            StartCoroutine(CardCooldown());
            return true; // Se pudo gastar la energ�a
        }
        else
        {
            return false; // No hay suficiente energ�a para jugar la carta o estamos en cooldown
        }
    }

    IEnumerator CardCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;
    }

    // Funci�n para recargar la energ�a al m�ximo
    public void RechargeEnergy()
    {
        currentEnergy = maxEnergy;
        UpdateEnergyUI();
    }

    // Funci�n para resetear la energ�a al inicio de una nueva ronda
    public void ResetEnergy()
    {
        RechargeEnergy(); // Recarga la energ�a al m�ximo al inicio de la ronda
        // Aqu� podr�as agregar cualquier otra l�gica adicional que necesites al inicio de una nueva ronda
    }
}
