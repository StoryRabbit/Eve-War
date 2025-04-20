using UnityEngine;

public class EveCombat : MonoBehaviour
{
    public string enemyTag = "EnemyEve"; // Assign this per prefab
    private EveBehavior stats;
    private EveMovement movement;
    private float attackTimer = 0f;

    private void Awake()
    {
        stats = GetComponent<EveBehavior>();
        movement = GetComponent<EveMovement>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag(enemyTag)) return;

        // Pause both Eves
        movement?.PauseMovement(true);

        EveMovement otherMove = other.GetComponent<EveMovement>();
        otherMove?.PauseMovement(true);

        // Attack if cooldown is ready
        attackTimer += Time.deltaTime;
        if (attackTimer >= 1f / stats.GetAttackSpeed())
        {
            attackTimer = 0f;
            EveBehavior target = other.GetComponent<EveBehavior>();
            if (target != null)
            {
                target.TakeDamage(stats.GetDamage());
                Debug.Log($"{gameObject.name} hit {other.name} for {stats.GetDamage()} damage");
            }
        }
    }

    public void ResumeMovementIfEnemyDead(EveBehavior deadEve) {
        movement?.PauseMovement(false);
    }
}
