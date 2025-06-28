using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider healthSlider;
    public Image fillImage;

    private int maxHealth;

    public void SetMaxHealth(int value)
    {
        maxHealth = value;
        healthSlider.maxValue = maxHealth;
    }

    public void SetHealth(int value)
    {
        healthSlider.value = value;
        UpdateColor(value);
    }

    private void UpdateColor(int currentHealth)
    {
        float healthPercent = (float)currentHealth / maxHealth;

        Color fullHealthColor = new Color(0.5f, 1f, 1f); // light blue
        Color lowHealthColor = Color.red;

        fillImage.color = Color.Lerp(lowHealthColor, fullHealthColor, healthPercent);
    }
}
