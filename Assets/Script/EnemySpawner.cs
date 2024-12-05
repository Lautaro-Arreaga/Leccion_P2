using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array para almacenar diferentes tipos de enemigos
    public Transform[] spawnPoints;  // Puntos donde se generarán los enemigos
    public float spawnInterval = 3f; // Tiempo entre cada generación

    private void Start()
    {
        // Iniciar el ciclo de generación
        InvokeRepeating(nameof(SpawnEnemy), spawnInterval, spawnInterval);
    }

    private void SpawnEnemy()
    {
        // Elegir un punto de generación aleatorio
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Elegir un enemigo aleatorio del array de prefabs
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Generar el enemigo
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}