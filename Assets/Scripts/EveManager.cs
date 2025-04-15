using UnityEngine;

public class EveManager : MonoBehaviour {
    public Eve currentEve;
    public int pointPool = 0;
    public int cloneCost = 5;

    public void GenerateNewEve(int points = 5) {
        currentEve = EveGenerator.CreateRandomEve(points);
    }

    public int TotalUsedPoints() {
        return currentEve.eveSize + currentEve.eveHealth + 
            Mathf.FloorToInt(currentEve.eveSpeed) + currentEve.eveStrength;
    }

    public int GetRemainingPoints() {
        return currentEve.pointGeneration - TotalUsedPoints();
    }

    public bool CanSpend(int cost = 1) {
        return GetRemainingPoints() >= cost;
    }

    // Spend Points Methods

    public void SpendPointsOnSize() {
        if (CanSpend() && currentEve.eveSize < 5)
            currentEve.eveSize += 1;
    }
    
    public void SpendPointOnSpeed() {
        if (CanSpend())
            currentEve.eveSpeed += 1f;
    }

    public void SpendPointOnStrength() {
        int maxStrength = Mathf.Min(5, currentEve.eveSize * 2);
        if (CanSpend() && currentEve.eveStrength < maxStrength)
            currentEve.eveStrength += 1;
    }

    public void SpendPointOnHealth() {
        if (CanSpend())
            currentEve.eveHealth += 1;
    }

    // Clone Eve Methods

    public Eve CloneEve() {
        if (pointPool < cloneCost) {
            return null;
        }

        pointPool -= cloneCost;
        var newEve = EveGenerator.CreateRandomEve(cloneCost);
        return newEve;
    }

}
