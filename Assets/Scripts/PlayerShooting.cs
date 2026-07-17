using UnityEngine;
// Обязательно добавляем это пространство имен для новой системы ввода
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public Camera playerCamera;
    public int damage = 25;
    public float fireRange = 100f;

    // Ссылка на новое действие ввода
    private InputAction shootAction;

    void Awake()
    {
        // Создаем действие для левой кнопки мыши напрямую в коде
        shootAction = new InputAction(type: InputActionType.Button, binding: "<Mouse>/leftButton");
    }

    void OnEnable()
    {
        shootAction.Enable();
        // Подписываемся на событие нажатия (вызовется метод Shoot)
        shootAction.performed += ctx => Shoot();
    }

    void OnDisable()
    {
        shootAction.Disable();
        shootAction.performed -= ctx => Shoot();
    }

    void Shoot()
    {
        RaycastHit hit;
        // Пускаем луч из центра камеры вперед
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, fireRange))
        {
            // Ищем скрипт Enemy на объекте, в который попали
            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log($"Попадание! У врага осталось {enemy.health} HP.");
            }
            else
            {
                Debug.Log($"Попал в объект: {hit.transform.name}");
            }
        }
    }
}
