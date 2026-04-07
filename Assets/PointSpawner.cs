using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    public GameObject pointPrefab;

    public int maxPoints = 3;

    public BoxCollider2D mapBounds;

    private int currentPoints = 0;

    private float minX, minY, maxX, maxY;

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