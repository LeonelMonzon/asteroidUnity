using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float speed = 15.0f;
    private Vector2 direction;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * speed;
    }
    void Update()
    {
        Move();
        ConstrainToCameraBounds();
    }
    void Move()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }
    void ConstrainToCameraBounds()
    {
        Vector3 position = transform.position;

        if (position.x <= CameraBounds.instance.minX || position.x >= CameraBounds.instance.maxX)
        {
            direction.x = -direction.x;
        }
        if (position.y <= CameraBounds.instance.minY || position.y >= CameraBounds.instance.maxY)
        {
            direction.y = -direction.y;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("asteroide"))
        {
            // Cambia la dirección al chocar con otro asteroide
            direction = Vector2.Reflect(direction, collision.contacts[0].normal);
        }
    }
    public void SetDirectionTowardsPlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
            direction = directionToPlayer;
        }
        else
        {
            // Si no se encuentra el jugador, establecer una dirección aleatoria
            direction = Random.insideUnitCircle.normalized;
        }
    }
}
