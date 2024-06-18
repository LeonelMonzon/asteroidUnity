using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 200f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10.0f;
    public Transform firePoint;
    public int lives = 3;
    public Image[] lifeImages;

    void Start()
    {
        UpdateLivesUI();
        ConstrainToCameraBounds();
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        transform.Translate(0, translation, 0);
        transform.Rotate(0, 0, -rotation);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }
    void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * projectileSpeed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("asteroide"))
        {
            Destroy(other.gameObject);
            LoseLife();
        }
    }
    void LoseLife()
    {
        if (lives > 0)
        {
            lives--;
            UpdateLivesUI();

            if (lives <= 0)
            {
            Destroy(gameObject);
            GameController.instance.GameOver();
            }
        }
    }
    public void UpdateLivesUI()
    {
        for (int i = 0; i < lifeImages.Length; i++)
        {
            lifeImages[i].enabled = i < lives;
        }
    }
    void ConstrainToCameraBounds()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, CameraBounds.instance.minX, CameraBounds.instance.maxX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, CameraBounds.instance.minY, CameraBounds.instance.maxY);
        transform.position = clampedPosition;
    }
}
