using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class EnemyAction
{
    public List<float> dmg;
    public List<float> def;

}

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int def;
    [SerializeField] int currentHealth;
    [SerializeField] UnityEvent onEnemyDeath;
    [SerializeField] Image healthBar;

    [SerializeField] List<EnemyAction> actions;
    [SerializeField] int actionsToDo = 1;
    public RoundSystem rondas;

    public void Start()
    {
        currentHealth = health;
        UpdateCurrentHeath();
    }

    public void Hurt(int damage)
    {
        if(def > 0)
        {
            def -= damage;
            if(def < 0)
            {
                damage = def * -1;
            }
            else
            {
                damage = 0;
            }
        }
        currentHealth -= damage;
        UpdateCurrentHeath();
        if (currentHealth <= 0)
        {
            onEnemyDeath.Invoke();
        }
    }

    public void Heal(int damage)
    {
        UpdateCurrentHeath();
        currentHealth += damage;
    }

    void UpdateCurrentHeath()
    {
        healthBar.fillAmount = (1.0f * currentHealth)/health;
    }

    public void EnemyTurn()
    {
        StartCoroutine(MyTurn());
    }

    IEnumerator MyTurn()
    {
        yield return new WaitForSeconds(1);
        // ATK OR DEFENSE

        for (int i = 0; i < actionsToDo; i++)
        {
            int selected = Random.Range(0, actions.Count);
            EnemyAction currentAction = actions[selected];

            Debug.Log("Action ... "+ selected, this);

            // Do Action
            float dmg = currentAction.dmg[Random.Range(0, currentAction.dmg.Count)];
            float def = currentAction.def[Random.Range(0, currentAction.def.Count)];


            rondas.ph.Hurt((int)(dmg));
            def += def;
            yield return new WaitForSeconds(1);
        }

        
        rondas.AdvanceRound(false);
    }
}
