using UnityEngine;
using TMPro; // ќб€зательно дл€ работы с TextMeshPro

public class GameUI : MonoBehaviour
{
    [Header("—сылки на текстовые компоненты")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI lootText;

    void Update()
    {
        // 1. ќбновл€ем текст здоровь€, бер€ данные из статических переменных
        if (healthText != null)
        {
            healthText.text = $"[—»—“≈ћј ∆»«Ќ≈ќЅ≈—ѕ≈„≈Ќ»я]\nHP: {PlayerHealth.currentHealth} / {PlayerHealth.maxHealth}";
        }

        // 2. ќбновл€ем текст лута, счита€ количество элементов в статическом списке
        if (lootText != null)
        {
            // —читаем, сколько именно "Ёлектроники" сейчас в кармане
            int electronicsCount = PlayerInventory.items.FindAll(x => x == "Ёлектроника").Count;

            lootText.text = $"[ћќƒ”Ћ№ —Ѕќ–ј Ћ”“ј]\nЁлектроника: {electronicsCount} шт.";
        }
    }
}
