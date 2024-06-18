using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public static CameraBounds instance;

    public float minX, maxX, minY, maxY;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        CalculateCameraBounds();
        CreateBounds();
    }

    void CalculateCameraBounds()
    {
        Camera mainCamera = Camera.main;

        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.transform.position.z));
        Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.transform.position.z));

        minX = bottomLeft.x;
        maxX = topRight.x;
        minY = bottomLeft.y;
        maxY = topRight.y;
    }
    void CreateBounds()
    {

        GameObject topBound = new GameObject("TopBound");
        topBound.transform.parent = transform;
        BoxCollider2D topCollider = topBound.AddComponent<BoxCollider2D>();
        topCollider.size = new Vector2(maxX - minX, 1f);
        topBound.transform.position = new Vector2((minX + maxX) / 2, maxY + 0.5f);

        GameObject bottomBound = new GameObject("BottomBound");
        bottomBound.transform.parent = transform;
        BoxCollider2D bottomCollider = bottomBound.AddComponent<BoxCollider2D>();
        bottomCollider.size = new Vector2(maxX - minX, 1f);
        bottomBound.transform.position = new Vector2((minX + maxX) / 2, minY - 0.5f);

        GameObject leftBound = new GameObject("LeftBound");
        leftBound.transform.parent = transform;
        BoxCollider2D leftCollider = leftBound.AddComponent<BoxCollider2D>();
        leftCollider.size = new Vector2(1f, maxY - minY);
        leftBound.transform.position = new Vector2(minX - 0.5f, (minY + maxY) / 2);

        GameObject rightBound = new GameObject("RightBound");
        rightBound.transform.parent = transform;
        BoxCollider2D rightCollider = rightBound.AddComponent<BoxCollider2D>();
        rightCollider.size = new Vector2(1f, maxY - minY);
        rightBound.transform.position = new Vector2(maxX + 0.5f, (minY + maxY) / 2);
    }
    public Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }
}
