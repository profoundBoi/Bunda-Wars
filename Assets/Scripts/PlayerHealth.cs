using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Slider healthBar;

    private SpawnManager initializer;

    void Start()
    {
        initializer = GetComponent<SpawnManager>();
        currentHealth = maxHealth;

        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void TakeDamage(int damage, string attackerTag)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        // Update immediately (THIS fixes your issue)
        healthBar.value = currentHealth;

        GetComponentInChildren<CameraShake>()?.Shake();

        if (currentHealth <= 0)
            StartCoroutine(DieAndRespawn(attackerTag));
    }

    IEnumerator DieAndRespawn(string attackerTag)
    {
        GameObject killer = GameObject.FindGameObjectWithTag(attackerTag);
        GameManager.Instance.RegisterKill(killer);

        // Optional: small delay so death is visible
        yield return new WaitForSeconds(0.5f);

        initializer.Respawn();

        currentHealth = maxHealth;
        healthBar.value = currentHealth;
    }
}
