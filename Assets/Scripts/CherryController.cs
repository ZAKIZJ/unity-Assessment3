using UnityEngine;
using System.Collections;

public class CherryController : MonoBehaviour
{
    public GameObject cherryPrefab; // Reference to the cherry prefab
    private Camera mainCamera;
    private float spawnInterval = 10.0f; // Time interval to spawn cherries
    public int scoreValue = 100;

    private void Start()
    {
        mainCamera = Camera.main; // Get the main camera
        StartCoroutine(SpawnCherryRoutine());
    }

    private IEnumerator SpawnCherryRoutine()
    {
        while (true)
        {
            SpawnCherry();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnCherry()
    {
        Vector2 spawnPosition = GetRandomPositionOutsideCamera();
        GameObject cherry = Instantiate(cherryPrefab, spawnPosition, Quaternion.identity);
        StartCoroutine(MoveCherry(cherry));
    }

    private Vector2 GetRandomPositionOutsideCamera()
    {
        Vector2 randomPosition = mainCamera.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
        // Ensuring the position is outside the camera view
        randomPosition += new Vector2(mainCamera.orthographicSize * mainCamera.aspect, mainCamera.orthographicSize);
        return randomPosition;
    }

    private IEnumerator MoveCherry(GameObject cherry)
    {
        Vector2 startPosition = cherry.transform.position;
        Vector2 endPosition = GetOppositePosition(startPosition);
        float lerpTime = 0f;
        while (lerpTime < 1f)
        {
            lerpTime += Time.deltaTime / 5.0f; // 5 seconds to cross the screen
            cherry.transform.position = Vector2.Lerp(startPosition, endPosition, lerpTime);
            yield return null;
        }
        Destroy(cherry);
    }

    private Vector2 GetOppositePosition(Vector2 start)
    {
        // Get the opposite position on the screen
        return new Vector2(-start.x, -start.y);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PacStudent"))
        {
            // Add score to the player's score
            ScoreManager.instance.AddScore(scoreValue);
            // Destroy the cherry
            Destroy(gameObject);
        }
    }
}
