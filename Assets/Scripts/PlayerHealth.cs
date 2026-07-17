using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Статические переменные хранят данные между сценами
    public static int maxHealth = 100;
    public static int currentHealth = 100;

    // Свойство для безопасного изменения здоровья (защита от багов)
    public int CurrentHealth
    {
        get { return currentHealth; }
        private set
        {
            // Clamp гарантирует, что здоровье не уйдет ниже 0 и выше текущего максимума
            currentHealth = Mathf.Clamp(value, 0, maxHealth);
        }
    }

    void Start()
    {
        // При старте сцены обновляем текущее здоровье до актуального статического значения
        Debug.Log($"[Здоровье] Игрок появился. HP: {currentHealth}/{maxHealth}");
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        Debug.Log($"[Здоровье] Получен урон! Осталось: {currentHealth}/{maxHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("[Здоровье] Игрок погиб!");
        if (GameManager.Instance != null)
        {
            GameManager.Instance.LoseGame(); // Вызываем проигрыш
        }
    }
}
