using UnityEngine;

public class AsteroidFragment : MonoBehaviour
{
    public float lifetime = 2f; 

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
