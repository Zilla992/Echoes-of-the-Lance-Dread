using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public HealthManager healthUI;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHealth = maxHealth;
        healthUI.SetMaxHealth(maxHealth);
        healthUI.SetHealth(currentHealth);

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BatEnemy bat = collision.GetComponent<BatEnemy>();
        if (bat)
        {
            TakeDamage(bat.damage);
        }
    }

    private void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthUI.SetHealth(currentHealth);

        StartCoroutine(FlashRed());
        if (currentHealth <= 0)
        {
            //
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthUI.SetHealth(currentHealth);
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }

}
