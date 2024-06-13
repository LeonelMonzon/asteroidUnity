using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public int points = 10;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("asteroide"))
        {
            Destroy(other.gameObject); 
            Destroy(gameObject);       
            GameManager.instance.AddScore(points);
        }
    }
}
