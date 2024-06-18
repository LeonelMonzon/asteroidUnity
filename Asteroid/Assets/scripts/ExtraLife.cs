using UnityEngine;

public class ExtraLife : MonoBehaviour
{
    public float lifeSpan = 200f;

    void Start()
    {
        Destroy(gameObject, lifeSpan);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController playerLives = other.GetComponent<PlayerController>();
            if (playerLives != null)
            {
                playerLives.lives++;
                playerLives.UpdateLivesUI();
            }

            Destroy(gameObject);
        }
    }
}
