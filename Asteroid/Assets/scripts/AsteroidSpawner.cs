using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnInterval = 0.25f; 
    public float spawnDistance = 10.0f; 
    public float minSpeed = 10.0f; 
    public float maxSpeed = 20.0f; 

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnAsteroid();
            timer = 0;
        }
    }

    void SpawnAsteroid()
    {
        Vector2 spawnPosition = GetRandomEdgePosition();
        GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

        // Configurar la dirección y velocidad del asteroide hacia el jugador
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Vector2 direction = ((Vector2)player.transform.position - spawnPosition).normalized;
            Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();
            rb.velocity = direction * Random.Range(minSpeed, maxSpeed);
        }
    }

    Vector2 GetRandomEdgePosition()
    {
        // Obtener los límites de la cámara
        Camera mainCamera = Camera.main;
        float minX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float maxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        float minY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        float maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        // Elegir un borde al azar
        int side = Random.Range(0, 4);
        Vector2 spawnPosition = Vector2.zero;

        switch (side)
        {
            case 0: // Arriba
                spawnPosition = new Vector2(Random.Range(minX, maxX), maxY);
                break;
            case 1: // Abajo
                spawnPosition = new Vector2(Random.Range(minX, maxX), minY);
                break;
            case 2: // Izquierda
                spawnPosition = new Vector2(minX, Random.Range(minY, maxY));
                break;
            case 3: // Derecha
                spawnPosition = new Vector2(maxX, Random.Range(minY, maxY));
                break;
        }

        return spawnPosition;
    }
}
