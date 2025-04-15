using UnityEngine;

public static class EveGenerator {
    public static Eve CreateRandomEve(int totalPoints = 5) {
        Eve newEve = ScriptableObject.CreateInstance<Eve>();

        newEve.pointGeneration = totalPoints;

        // Size
        newEve.eveSize = Random.Range(1, 4);
        int remaining = totalPoints - newEve.eveSize;

        // Strength
        int maxStrength = Mathf.Min(5, newEve.eveSize * 2);
        newEve.eveStrength = Random.Range(0, Mathf.Min(maxStrength, remaining + 1));
        remaining -= newEve.eveStrength;

        // Speed
        newEve.eveSpeed = Random.Range(1f, Mathf.Min(10f, remaining + 1f));
        remaining -= Mathf.FloorToInt(newEve.eveSpeed);

        // Health
        newEve.eveHealth = remaining;
        remaining -= newEve.eveHealth;

        return newEve;
    }
}
