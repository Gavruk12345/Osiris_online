using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject prefab;       // Префаб об'єкта, який буде спавнений
    public float spawnInterval = 3f; // Інтервал між спавненням об'єктів (в секундах)

    private float spawnTimer = 0f;

    void Start()
    {
        // Здійснюємо перший спавн зразу
        SpawnObject();
    }

    void Update()
    {
        // Збільшуємо таймер
        spawnTimer += Time.deltaTime;

        // Якщо таймер перевищив інтервал спавнення
        if (spawnTimer >= spawnInterval)
        {
            // Спавнимо об'єкт
            SpawnObject();

            // Скидаємо таймер
            spawnTimer = 0f;
        }
    }

    void SpawnObject()
    {
        // Створюємо новий об'єкт з префабу
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}