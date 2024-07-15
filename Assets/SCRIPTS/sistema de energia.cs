using UnityEngine;
using TMPro; // Asegúrate de importar TMPro
using System.Collections; // Necesario para utilizar corutinas

public class EnergySystem : MonoBehaviour
{
    public int maxEnergy = 3; // Energía máxima que puede tener el jugador
    public int currentEnergy = 3; // Energía actual del jugador
    public TMP_Text energyText; // Referencia al objeto TextMeshPro que mostrará la energía actual

    public float cooldownTime = 2.0f; // Tiempo de cooldown después de jugar una carta (en segundos)
    private bool isOnCooldown = false; // Variable que indica si estamos en cooldown

    void Start()
    {
        UpdateEnergyUI();
    }

    // Función para actualizar el texto que muestra la energía actual
    void UpdateEnergyUI()
    {
        energyText.text = "" + currentEnergy;
    }

    // Función para restar energía al jugar una carta con un costo específico
    public bool SpendEnergy(int energyCost)
    {
        if (currentEnergy >= energyCost && !isOnCooldown)
        {
            currentEnergy -= energyCost;
            UpdateEnergyUI();
            StartCoroutine(CardCooldown());
            return true; // Se pudo gastar la energía
        }
        else
        {
            return false; // No hay suficiente energía para jugar la carta o estamos en cooldown
        }
    }

    IEnumerator CardCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;
    }

    // Función para recargar la energía al máximo
    public void RechargeEnergy()
    {
        currentEnergy = maxEnergy;
        UpdateEnergyUI();
    }

    // Función para resetear la energía al inicio de una nueva ronda
    public void ResetEnergy()
    {
        RechargeEnergy(); // Recarga la energía al máximo al inicio de la ronda
        // Aquí podrías agregar cualquier otra lógica adicional que necesites al inicio de una nueva ronda
    }
}
