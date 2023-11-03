using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameHUDController : MonoBehaviour
{
    public Text gameTimerText;
    public Button exitButton;

    private float timer;

    private void Start()
    {
        timer = 0f;
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        UpdateGameTimer();
    }

    // Updates the game timer text on the HUD
    private void UpdateGameTimer()
    {
        int minutes = (int)(timer / 60);
        int seconds = (int)(timer % 60);
        int milliseconds = (int)((timer * 100) % 100);

        gameTimerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    // Handles the click event of the exit button
    private void OnExitButtonClick()
    {
        SceneManager.LoadScene("StartScene"); // Replace "StartScene" with the name of your start scene
    }
}
