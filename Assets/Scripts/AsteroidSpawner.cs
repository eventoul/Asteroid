using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidPrefabs;
    [SerializeField] private float secondsBetweenAsteroidsSpawn = 1.5f;
    [SerializeField] private Vector2 forceRange;

    private float timer;
    private Camera mainCamre;

    private void Start()
    {
        mainCamre = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnAsteroid();
            timer += secondsBetweenAsteroidsSpawn;
        }
    }

    private void SpawnAsteroid()
    {
        int side = Random.Range(0, 4);
        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;

        switch (side)
        {
            case 0:
                // left
                spawnPoint.x = 0;
                spawnPoint.y = Random.value;
                direction = new Vector2(1f, Random.Range(-1f, 1f));
                break;
            case 1:
                // right
                spawnPoint.x = 1;
                spawnPoint.y = Random.value;
                direction = new Vector2(-1f, Random.Range(-1f, 1f));
                break;
            case 2:
                // bottom
                spawnPoint.x = Random.value;
                spawnPoint.y = 0;
                direction = new Vector2(Random.Range(-1f, 1f), 1f);
                break;
            case 3:
                // top 
                spawnPoint.x = Random.value;
                spawnPoint.y = 1;
                direction = new Vector2(Random.Range(-1f, 1f), -1f);
                break;
        }

        Vector3 worldSpawnPoint = mainCamre.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 0;
        GameObject selectedAsteroid = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];
        
        GameObject asteroidInstance = Instantiate(selectedAsteroid, worldSpawnPoint, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));

        Rigidbody rb = asteroidInstance.GetComponent<Rigidbody>();

        rb.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);
    }
}
