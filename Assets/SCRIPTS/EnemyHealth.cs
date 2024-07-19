using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int currentHealth;
    [SerializeField] UnityEvent onEnemyDeath;
    [SerializeField] Image healthBar;

    public Animator animator; // Asegúrate de asignar el Animator en el inspector

    public RoundSystem rondas; // Asumiendo que tienes una referencia a RoundSystem para avanzar rondas

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
        }
    }

    public void Heal(int damage)
    {
        currentHealth += damage;
        currentHealth = Mathf.Clamp(currentHealth,0,health);
        UpdateCurrentHealth();
    }

    void UpdateCurrentHealth()
    {
        healthBar.fillAmount = (1.0f * currentHealth) / health;
    }

    public void EnemyTurn()
    {
        StartCoroutine(PerformRandomAttack());
    }

    IEnumerator PerformRandomAttack()
    {
        yield return new WaitForSeconds(1);

        // Escoger un trigger aleatorio
        string[] attackTriggers = { "accion1", "accion2", }; // Ejemplo de nombres de triggers de ataque

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
}
