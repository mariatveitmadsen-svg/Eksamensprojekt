using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 1; //takes 1 hit

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
