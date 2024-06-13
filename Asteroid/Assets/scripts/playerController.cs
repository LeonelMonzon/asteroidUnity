using System;
using UnityEngine;

public class PlayerControlller : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 200f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10.0f;
    public Transform firePoint;

    void Update()
    {
        Move();
        ConstrainToCameraBounds();
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
            Destroy(gameObject);
            GameController.instance.GameOver();
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
