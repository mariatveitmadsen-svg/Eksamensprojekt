using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 2; //takes 2 hits

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
