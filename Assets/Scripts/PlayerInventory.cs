using System.Collections.Generic; // Обязательно для работы со списками List
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // Наш список собранного лута. Мы используем встроенный тип данных string (строки)
    public static List<string> items = new List<string>();

    // Метод, который другие скрипты будут вызывать, чтобы положить вещь в карман
    public void AddItem(string itemName)
    {
        items.Add(itemName);
        Debug.Log($"[Инвентарь] Добавлено: {itemName}. Всего предметов в кармане: {items.Count}");
    }
}
