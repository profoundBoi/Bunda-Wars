using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Slider healthBar;

    private SpawnManager initializer;
    private bool isDead = false;

    void Start()
    {
        initializer = GetComponent<SpawnManager>();
        ResetHealth();
    }

    void ResetHealth()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        isDead = false;
    }

    public void TakeDamage(int damage, string attackerTag)
    {
        if (isDead) return;

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        healthBar.value = currentHealth;

        GetComponentInChildren<CameraShake>()?.Shake();

        if (currentHealth <= 0)
        {
            isDead = true;
            StartCoroutine(DieAndRespawn(attackerTag));
        }
    }

    IEnumerator DieAndRespawn(string attackerTag)
    {
        GameObject killer = GameObject.FindGameObjectWithTag(attackerTag);
        GameManager.Instance.RegisterKill(killer);

        yield return new WaitForSeconds(0.75f);

        initializer.Respawn();

        yield return null;

        ResetHealth();
    }
}
