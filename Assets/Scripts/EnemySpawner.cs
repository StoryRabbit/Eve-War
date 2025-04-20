using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyEvePrefab;
    public Eve[] enemyTypes;               
    public Transform[] spawnPoints;       
    public float spawnDelay = 2f;

    private float timer = 0f;

    private void Update() {
        timer += Time.deltaTime;
        if (timer >= spawnDelay)
        {
            timer = 0f;
            SpawnEnemy();
        }
    }

    void SpawnEnemy() {
        int lane = Random.Range(0, spawnPoints.Length);
        Eve chosenEve = enemyTypes[Random.Range(0, enemyTypes.Length)];

        GameObject enemy = Instantiate(enemyEvePrefab, spawnPoints[lane].position, Quaternion.identity);
        EveBehavior behavior = enemy.GetComponent<EveBehavior>();

        if (behavior != null) {
            behavior.ApplyEveStats(chosenEve);
        }

        // Flip 
        EveMovement mover = enemy.GetComponent<EveMovement>();
        if (mover != null) {
            mover.Init(chosenEve.GetMovementSpeed(), true); // true = moveLeft
        }
    }
}
