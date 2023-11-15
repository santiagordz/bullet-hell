using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthBar;
    public GameObject explosionPrefab;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth != 0)
        {

            healthBar.rectTransform.localScale = new Vector3(currentHealth / maxHealth, 1, 1);
        }
        else
        {
            Explode();
        }
    }

    private void Explode()
    {
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(explosion, 1f);
    }
}
