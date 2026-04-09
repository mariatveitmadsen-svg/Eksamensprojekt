using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    public GameObject pointPrefab;

    public int maxPoints = 3;

    public float maxX = 42.3f;
    public float minX = -32.1f;
    public float maxY = 24f;
    public float minY = -25.8f;

    private int currentPoints = 0;

    

    void Start()
    {
        for (int i = 0; i < maxPoints; i++)
        {
            SpawnPoint();
        }
    }

    public void SpawnPoint()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        Vector2 position = new Vector2(x, y);

        Instantiate(pointPrefab, position, Quaternion.identity);

        currentPoints++;
    }

    public void PointCollected()
    {
        currentPoints--;

        if (currentPoints < maxPoints)
        {
            SpawnPoint();
        }
    }
}