using UnityEngine;

public class PlayerController
{
    private readonly float maxHealth = 100;
    private float currentHealth;

    private readonly float maxArmor = 100;
    private float currentArmor;


    private float damageModifier;

    private bool isPlayerDead;

    public void InitializePlayer()
    {
        currentHealth = maxHealth;
        isPlayerDead = false;
    }

    public void KillPlayer()
    {
        if (!isPlayerDead && currentHealth <= 0)
        {
            isPlayerDead = true;
            currentHealth = 0;
        }
    }

    public bool IsPlayerDead()
    {
        return isPlayerDead;
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public float GetArmor()
    {
        return currentArmor;
    }

    public void HealPlayer(float healAmount)
    {
        if(!isPlayerDead && healAmount > 0 && currentHealth < maxHealth)
        {
            float calculatedHealth = currentHealth + healAmount;

            if (calculatedHealth <= maxHealth)
            {
                currentHealth = calculatedHealth;
            }
            else
            {
                currentHealth = maxHealth;
            }
        }
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
    }
}
