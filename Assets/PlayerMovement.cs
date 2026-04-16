using UnityEngine; //Importerer unity funktioner

public class PlayerMovement : MonoBehaviour //MonoBehavior betyder at scriptet kan sidde på et gameobject
{
    [SerializeField] private float speed = 5f; //sætter spillerens hastighed, SerializeField betyder at værdien kan ændres i inspector

    //Gun variables
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint; //spawningpoint for bullet
    [Range(0.1f, 2f)] //maksimum og minimum for firerate
    [SerializeField] private float fireRate = 0.5f; //laver en slider i inspector

    //movement variabler
    private Rigidbody2D rb;
    private float mx;
    private float my;

    private float fireTimer; //angiver hvornår man må skyde igen

    private Vector2 mousePos; //angiver musens position

    private void Start() //kører en gang når spillet starter
    {
        rb = GetComponent<Rigidbody2D>(); //finder spillerens rigidbody og gennemer den
    }

    private void Update() //kører hver frame
    {
        //læser tastaturets input
        mx = Input.GetAxisRaw("Horizontal"); 
        my = Input.GetAxisRaw("Vertical");

        //tager musens position på skærmen og konveterer til spillets verden
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Beregner vinkel mod skærmen
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        transform.localRotation = Quaternion.Euler(0, 0, angle); //roterer spilleren mod musen

        if (Input.GetMouseButton(0) && fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRate;
        }
        else
        {
            fireTimer -= Time.deltaTime;
        }
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(mx, my).normalized * speed;
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    }
}
