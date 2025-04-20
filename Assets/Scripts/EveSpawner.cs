using UnityEngine;
using UnityEngine.UI;

public class EveSpawner : MonoBehaviour {
    [Header("References")]
    public GameObject evePrefab;
    public Transform[] spawnPoints;

    public ManaUI manaUI;

    public void SpawnEve(Eve eveData, int laneIndex) {
        if (laneIndex < 0 || laneIndex >= spawnPoints.Length) {
            Debug.LogWarning("Invalid lane index.");
            return;
        }


        if (!manaUI.SpendMana(eveData.manaCost)) {
            Debug.Log("Not enough mana to deploy Eve!");
            return;
        }

        // Spawn Eve
        GameObject spawned = Instantiate(evePrefab, spawnPoints[laneIndex].position, Quaternion.identity);


        // Apply Eve stats
        EveBehavior eveBehavior = spawned.GetComponent<EveBehavior>();
        if (eveBehavior != null) {
            eveBehavior.ApplyEveStats(eveData);
        }
    }
}
