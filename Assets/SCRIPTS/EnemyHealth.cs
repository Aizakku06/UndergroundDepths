using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Asegúrate de incluir esto para trabajar con escenas
using System.Collections; // Asegúrate de incluir esto para trabajar con IEnumerator

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int currentHealth;
    [SerializeField] UnityEvent onEnemyDeath;
    [SerializeField] Image healthBar;

    public Animator animator; // Asegúrate de asignar el Animator en el inspector
    public RoundSystem rondas; // Asumiendo que tienes una referencia a RoundSystem para avanzar rondas

    [SerializeField] private string sceneToLoad; // Nombre de la escena a cargar

    public void Start()
    {
        currentHealth = health;
        UpdateCurrentHealth();
    }

    public void Hurt(int damage)
    {
        currentHealth -= damage;
        UpdateCurrentHealth();
        if (currentHealth <= 0)
        {
            onEnemyDeath.Invoke();
            ChangeScene();
        }
    }

    public void Heal(int amount) // Cambiado el nombre del parámetro a 'amount' para mayor claridad
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, health);
        UpdateCurrentHealth();
    }

    void UpdateCurrentHealth()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (1.0f * currentHealth) / health;
        }
    }

    public void EnemyTurn()
    {
        StartCoroutine(PerformRandomAttack());
    }

    IEnumerator PerformRandomAttack()
    {
        yield return new WaitForSeconds(1);

        // Escoger un trigger aleatorio
        string[] attackTriggers = { "accion1", "accion2" }; // Ejemplo de nombres de triggers de ataque

        int randomIndex = Random.Range(0, attackTriggers.Length);
        string randomTrigger = attackTriggers[randomIndex];

        Debug.Log("Trigger Activado: " + randomTrigger);

        // Activar el trigger en el Animator
        if (animator != null)
        {
            animator.SetTrigger(randomTrigger);
        }

        yield return new WaitForSeconds(1);

        rondas.AdvanceRound(false); // Avanzar la ronda
    }

    void ChangeScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad)) // Verificar que el nombre de la escena no esté vacío
        {
            SceneManager.LoadScene(sceneToLoad); // Cargar la escena, reemplazando la actual
        }
        else
        {
            Debug.LogError("El nombre de la escena no está asignado.");
        }
    }
}

