using UnityEngine;

public class EnemieMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] Transform player;
    [SerializeField] float NockBack = 25f;
    Rigidbody2D rb;
    Vector2 moveDir;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        moveDir = (player.position - transform.position).normalized;
        rb.linearVelocity = moveDir * speed;

/*
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10);
                transform.position -= (Vector3)(moveDir * NockBack);
            }
        }
    }
}