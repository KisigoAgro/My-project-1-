using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    public GameObject lootPrefab;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) Die();
    }

    private void Die()
    {
        // Если префаб лута назначен, создаем его на месте смерти врага
        if (lootPrefab != null)
        {
            Instantiate(lootPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}

