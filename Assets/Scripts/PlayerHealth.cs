using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private SpawnManager initializer;

    void Awake()
    {
        currentHealth = maxHealth;
        initializer = GetComponent<SpawnManager>();
    }

    public void TakeDamage(int damage, string attackerTag)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die(attackerTag);
        }
    }

    void Die(string attackerTag)
    {
        GameManager.Instance.PlayerScored(attackerTag);

        currentHealth = maxHealth;

        if (initializer != null)
            initializer.Respawn();
    }
}
