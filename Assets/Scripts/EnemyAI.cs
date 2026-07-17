using UnityEngine;
using UnityEngine.AI; // Обязательно для работы с NavMesh

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransform;

    [Header("Настройки ИИ")]
    public float attackDistance = 1.5f; // Дистанция удара
    public int damageAmount = 10;       // Сколько урона наносит зомби
    public float attackCooldown = 1.5f; // Перезарядка удара в секундах

    private float nextAttackTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Автоматически находим игрока на сцене по его тегу
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        if (playerTransform == null) return;

        // Приказываем навигатору бежать к координатам игрока
        agent.SetDestination(playerTransform.position);

        // Считаем дистанцию до игрока
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // Если подошли вплотную и время перезарядки прошло — бьем
        if (distanceToPlayer <= attackDistance && Time.time >= nextAttackTime)
        {
            AttackPlayer();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    void AttackPlayer()
    {
        // Ищем у игрока наш ранее написанный скрипт здоровья
        PlayerHealth playerHealth = playerTransform.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
            Debug.Log("Зомби укусил игрока!");
        }
    }
}
