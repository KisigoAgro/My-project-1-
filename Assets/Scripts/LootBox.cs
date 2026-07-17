using UnityEngine;

public class LootBox : MonoBehaviour
{
    public string itemName = "Электроника"; // Название лута
    public int amount = 1;                  // Количество

    // Этот метод вызовется, когда игрок подойдет вплотную
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что к ящику подошел именно Игрок
        if (other.CompareTag("Player"))
        {
            // Пытаемся найти компонент PlayerInventory на объекте, который наступил на триггер
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();

            if (inventory != null)
            {
                // Передаем название нашего предмета в инвентарь игрока
                inventory.AddItem(itemName);

                // Удаляем ящик со сцены
                Destroy(transform.parent.gameObject);

                // Сообщаем в консоль, что лут собран
                Debug.Log($"Подобрано: {itemName} x{amount}!");
            }           
        }
    }
}
