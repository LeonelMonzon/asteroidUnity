using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public int points = 10;
    public GameObject fragmento;
    public float destructionDelay = 2f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("asteroide"))
        {
            Destroy(other.gameObject); 
            Destroy(gameObject);       
            GameManager.instance.AddScore(points);
            InstantiateFragment(new Vector2(0.5f, 0.5f));
            InstantiateFragment(new Vector2(-0.5f, -0.5f));
        }
    }
    void InstantiateFragment(Vector2 offset)
    {
        Debug.Log(fragmento);
        GameObject fragment = Instantiate(fragmento, offset, Quaternion.identity);
        Destroy(fragment,destructionDelay);
    }
}
