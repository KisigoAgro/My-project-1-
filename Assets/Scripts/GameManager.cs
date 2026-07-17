using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Ссылка на сам скрипт, чтобы к нему легко было обратиться из здоровья игрока
    public static GameManager Instance;

    [Header("Панели Интерфейса")]
    public GameObject losePanel;
    public GameObject winPanel;

    [Header("Условия Победы")]
    public int electronicsNeededToWin = 3; // Сколько нужно собрать для победы

    private bool isGameOver = false;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        // Если игра еще не закончилась, проверяем условие победы
        if (!isGameOver)
        {
            CheckWinCondition();
        }
    }

    void CheckWinCondition()
    {
        // Считаем электронику в статическом инвентаре
        int currentLoot = PlayerInventory.items.FindAll(x => x == "Электроника").Count;

        if (currentLoot >= electronicsNeededToWin)
        {
            WinGame();
        }
    }

    public void LoseGame()
    {
        isGameOver = true;
        losePanel.SetActive(true); // Показываем экран смерти
        Time.timeScale = 0f;       // Ставим игру на паузу (замораживаем зомби и игрока)
        DisablePlayerControls(); // Блокируем камеру и управление
        UnlockCursor();
    }

    void WinGame()
    {
        isGameOver = true;
        winPanel.SetActive(true); // Показываем экран победы
        Time.timeScale = 0f;       // Пауза
        DisablePlayerControls(); // Блокируем камеру и управление
        UnlockCursor();
    }

    // Метод для кнопки перезапуска
    public void RestartLevel()
    {
        Time.timeScale = 1f; // Снимаем паузу перед перезапуском!
        PlayerHealth.currentHealth = PlayerHealth.maxHealth; // Лечим игрока
        PlayerInventory.items.Clear(); // Очищаем карманы для честного перезапуска
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Метод для кнопки ухода в убежище
    public void GoToHideout()
    {
        Time.timeScale = 1f; // Снимаем паузу
        SceneManager.LoadScene("1. Shelter"); // Убедись, что имя сцены верное
    }

    void DisablePlayerControls()
    {
        // Находим игрока на сцене по тегу
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Находим компонент управления вводом (обычно StarterAssetsInputs или PlayerInput)
            // Самый надежный способ для официального ассета — отключить компонент PlayerInput
            var playerInput = player.GetComponent<UnityEngine.InputSystem.PlayerInput>();
            if (playerInput != null)
            {
                playerInput.enabled = false; // Отключаем ввод полностью
            }

            // На всякий случай также отключаем сам скрипт контроллера
            // В официальном ассете он называется FirstPersonController
            var controller = player.GetComponent<StarterAssets.FirstPersonController>();
            if (controller != null)
            {
                controller.enabled = false;
            }
        }
    }

        void UnlockCursor()
    {
        // Возвращаем курсор мыши на экран, так как контроллер игрока его прячет
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
