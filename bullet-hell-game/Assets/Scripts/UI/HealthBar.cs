using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 100f;
    public float currentHealth = 100f;

    void Update()
    {
        currentHealth -= 0.1f; // This is just for demonstration
        float healthRatio = currentHealth / maxHealth;
        healthBar.rectTransform.localScale = new Vector3(healthRatio, 1, 1);
    }
}
