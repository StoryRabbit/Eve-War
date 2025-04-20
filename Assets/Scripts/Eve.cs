using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "Eve", menuName = "Scriptable Objects/Eve")]
public class Eve : ScriptableObject {

    [Header("Eve Stats")]
    public int eveHealth;
    public int eveSize;
    public float eveSpeed;
    public int evePower;


    [Header("Others")]
    public int manaCost;
    public int upgradeCost;
    public int deathPoints;

    // Health
    public int GetBaseHealth() => eveHealth * eveSize;

    // Size
    public float GetSizeModifier() {
        switch (eveSize)
        {
            case 1: return 1f;
            case 2: return 0.8f;
            case 3: return 0.6f;
            case 4: return 0.4f;
            default: return 1f;
        }
    }

    // Speed
    public float GetBaseSpeed() => eveSpeed;
    public float GetMovementSpeed() {
        float modifier = GetSizeModifier();
        return GetBaseSpeed() * modifier;
    }
    public float GetAttackSpeed() {
        float modifier = GetSizeModifier();
        return GetBaseSpeed() * modifier;
    }

    // Power
    public int GetBasePower() => evePower;
    public int GetAttackDamage() => GetBasePower() * eveSize;
}
