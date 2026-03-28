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
        Debug.Log($"{gameObject.name} เกิดแล้ว! เลือด: {currentHealth}");
    }

    void OnMouseDown()
    {
        TakeDamage(damagePerClick);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} โดนตี! รับดาเมจ: {damage}. เลือดเหลือ: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{gameObject.name} ตายแล้ว! กำลังทำลายตัวเอง.");
        Destroy(gameObject);
    }
}
