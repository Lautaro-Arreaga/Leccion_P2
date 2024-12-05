using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefab;  // Prefabs de los objetos a instanciar
    public float minTime = 1f;       // Tiempo mínimo entre spawns
    public float maxTime = 2f;       // Tiempo máximo entre spawns
    public float spawnRangeX = 10f;  // Rango en el eje X donde generaremos los objetos
    public float spawnHeight = 0f;   // Altura donde los objetos aparecerán (puedes ajustar esto)

    private float nextSpawnTime = 0f; // Control del tiempo para el siguiente spawn

    // Start se llama una vez antes del primer frame
    void Start()
    {
        // Inicia la Coroutine para generar los objetos
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        // La Coroutine se repite indefinidamente, generando un item cada intervalo aleatorio
        while (true)
        {
            // Espera el tiempo aleatorio antes de generar el siguiente item
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));

            // Verifica si hay prefabs asignados en el arreglo itemPrefab
            if (itemPrefab.Length > 0)  // Asegura que el arreglo no esté vacío
            {
                // Generar una posición en el eje X dentro del rango especificado
                float spawnX = transform.position.x + Random.Range(0f, spawnRangeX);
                Vector2 spawnPosition = new Vector2(spawnX, spawnHeight);

                // Instancia un prefab aleatorio en la posición generada
                Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], spawnPosition, Quaternion.identity);
            }
            else
            {
                // Si el arreglo itemPrefab está vacío, muestra un mensaje de error
                Debug.LogError("itemPrefab is empty! Please assign prefabs to the itemPrefab array.");
            }
        }
    }

    // Update se llama en cada frame
    void Update()
    {
        // Aquí puedes agregar cualquier lógica adicional si es necesario
    }
}
