using UnityEngine;

public class UpgradeBench : MonoBehaviour
{

    public int healthUpgradeAmount = 25; // На сколько увеличиваем здоровье

    private void OnTriggerEnter(Collider other)
    {
        // 1. Проверяем, есть ли электроника в статическом инвентаре
        if (PlayerInventory.items.Contains("Электроника"))
        {
            // 2. Списываем лут
            PlayerInventory.items.Remove("Электроника");

            // 3. Прокачиваем статические параметры здоровья
            PlayerHealth.maxHealth += healthUpgradeAmount;
            PlayerHealth.currentHealth = PlayerHealth.maxHealth; // Полностью лечим при апгрейде

            Debug.Log("=========================================");
            Debug.Log(" Улучшение успешно выполнено!");
            Debug.Log($"[Инвентарь] 1 Электроника списана. Осталось: {PlayerInventory.items.Count}");
            Debug.Log($"[Прокачка] Максимальное HP увеличено! Теперь оно равно: {PlayerHealth.maxHealth}");
            Debug.Log("=========================================");
        }
        else
        {
            Debug.Log("У вас нет Электроники для улучшения!");
        }
    }
 }
