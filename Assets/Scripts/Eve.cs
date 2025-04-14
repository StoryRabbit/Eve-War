using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "Eve", menuName = "Scriptable Objects/Eve")]
public class Eve : ScriptableObject
{
    #region Base Variables
    [Header("Eve Stats")]
        public int eveHealth = 0; // Varies from 1 to 10
        public int eveSize = 0; // Varies
        public float eveSpeed = 0f; // Varies from 1 to 10
        public int eveStrength = 0; // Varies from 1 to 5

    [Header("Eve Points")]
        public int pointGeneration = 5;

    [Header("Base Core")]
        public int baseCore = 20;
    #endregion

    // Health
    public int baseHealth() => eveHealth * (1 * eveSize);

    // Size
    public float sizeModifier(int size)
    {
        switch (size)
        {
            case 1: return 1f;
            case 2: return 0.9f;
            case 3: return 0.8f;
            case 4: return 0.7f;
            case 5: return 0.6f;
            default: return 1f;
        }
    }

    // Speed
    public float baseSpeed() => eveSpeed;
    public float movementSpeed() => baseSpeed() * sizeModifier(eveSize);
    public float attackSpeed() => baseSpeed() * sizeModifier(eveSize);

    // Strength
    public int baseStrength() => eveStrength;
    public int attackDamage() => baseStrength() * eveSize;



}
