using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int currentHealth; // Cambiado a público
    [SerializeField] UnityEvent onPlayerDeath;
    [SerializeField] Image healthBar;
    [SerializeField] Image HealAnimation;

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
            onPlayerDeath.Invoke();
            LoadGameOverScene();
        }
    }

    public void Heal(int healingAmount)
    {
        currentHealth += healingAmount;
        if (currentHealth > health)
        {
            currentHealth = health;
        }
        UpdateCurrentHealth();
    }

    void UpdateCurrentHealth()
    {
        healthBar.fillAmount = (1.0f * currentHealth) / health;
    }

    public void TurnOffHeal()
    {
        HealAnimation.gameObject.SetActive(false);
    }

    void LoadGameOverScene()
    {
        // Aquí cargamos la escena de Game Over
        SceneManager.LoadScene("GameOverScene"); // Asegúrate de poner el nombre correcto de tu escena de Game Over
    }
}
