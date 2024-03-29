using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField] private int maxHealth;

    [SerializeField] private bool damageImmune;

    public delegate void OnHealthChange(int amount);
    public OnHealthChange onHeal;
    public OnHealthChange onDamage;

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ApplyDamage(int damageAmount)
    {
        if (damageImmune)
        {
            return;
        }

        currentHealth -= damageAmount;

        onDamage(damageAmount);
    }

    public void ApplyHeal(int healAmount)
    {
        if ((currentHealth += healAmount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += healAmount;
        }

        onHeal(healAmount);
    }

}
