using UnityEditor.Overlays;
using UnityEngine;

public class EveBehavior : MonoBehaviour {
    [Header("Runtime Stats")]
    public Eve eveData;

    private int currentHealth;
    private float moveSpeed;
    private float attackSpeed;
    private int damage;

    public void ApplyEveStats(Eve data) {
        eveData = data;

        // INITIALIZE
        currentHealth = data.GetBaseHealth();
        moveSpeed = data.GetMovementSpeed();
        attackSpeed = data.GetAttackSpeed();
        damage = data.GetAttackDamage();


        transform.localScale = new Vector3(data.eveSize, data.eveSize, 1f);


        EveMovement mover = GetComponent<EveMovement>();
        if (mover != null) {
            mover.Init(moveSpeed);
        }

        // DEBUG
        Debug.Log($"{name} Initialized → HP: {currentHealth}, Move: {moveSpeed}, AtkSpd: {attackSpeed}, Dmg: {damage}");
    }

  
    public float GetMoveSpeed() => moveSpeed;
    public float GetAttackSpeed() => attackSpeed;
    public int GetDamage() => damage;
    public int GetCurrentHealth() => currentHealth;

    public void TakeDamage(int amount) {
        currentHealth -= amount;
        if (currentHealth <= 0) {
            Die();
        }
    }

    private void Die() {
        Collider2D[] nearby = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        foreach (var col in nearby) {
            EveCombat combat = col.GetComponent<EveCombat>();
            combat?.ResumeMovementIfEnemyDead(this);
        }

        Destroy(gameObject);
    }
}
