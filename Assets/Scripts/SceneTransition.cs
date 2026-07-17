using UnityEngine;
using UnityEngine.SceneManagement; // Обязательно для работы со сценами

public class SceneTransition : MonoBehaviour
{   
    [SerializeField] private string sceneName; // Имя сцены, куда идем

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Загружаем сцену Убежища
            SceneManager.LoadScene(sceneName);
        }
    }
}
