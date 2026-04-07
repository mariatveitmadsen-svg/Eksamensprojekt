using UnityEngine;

public class Point : MonoBehaviour
{
    public int value = 1;

    private PointSpawner spawner;

    void Start()
    {
        spawner = FindObjectOfType<PointSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreManager.Instance.AddScore(value);

            spawner.PointCollected();

            Destroy(gameObject);
        }
    }
}