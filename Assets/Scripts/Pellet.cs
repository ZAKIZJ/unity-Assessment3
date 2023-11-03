using UnityEngine;
using UnityEngine.SceneManagement;

public class Pellet : MonoBehaviour
{
    public int scoreValue = 10; // The score value for this pellet

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PacStudent"))
        {
            // Add score to the player's score
            ScoreManager.instance.AddScore(scoreValue);
            // Destroy the pellet
            Destroy(gameObject);
        }
    }
}