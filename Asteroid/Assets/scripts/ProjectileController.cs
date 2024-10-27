using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public int points = 10;
    public GameObject fragmento;
    public float destructionDelay = 1f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("asteroide"))
        {
            Vector2 positionDestroy = transform.position;
            Destroy(other.gameObject); 
            Destroy(gameObject);       
            GameManager.instance.AddScore(points);
            InstantiateFragment(positionDestroy);
            InstantiateFragment(positionDestroy);
        }
    }
    void InstantiateFragment(Vector2 offset)
    {
        GameObject fragment = Instantiate(fragmento, offset, Quaternion.identity);
        Rigidbody2D rb = fragment.GetComponent<Rigidbody2D>();
        
        if (rb != null) {
            rb.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 15f;
        }
        Destroy(fragment,destructionDelay);
    }
}
