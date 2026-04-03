using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats (ปรับค่าได้ใน Inspector)")]
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public int damagePerClick = 40;

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnMouseDown()
    {
        TakeDamage(damagePerClick);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
