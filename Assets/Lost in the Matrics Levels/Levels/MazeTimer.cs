using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MazeTimer : MonoBehaviour
{
    public float timeRemaining = 150f; // 2.5 minutes
    public TMP_Text timerText;
    public GameObject winText;
    public GameObject loseText;
    public GameObject RestartButton;
    public AudioSource gameOverAudio; // Game over voice clip

    private bool gameEnded = false;

    void Start()
    {
        winText.SetActive(false);
        loseText.SetActive(false);
        RestartButton.SetActive(false);
        Time.timeScale = 1f; // Game runs normally
    }

    void Update()
    {
        if (gameEnded) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            EndGame(false); // Time ran out = you lose
        }

        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = $"Time: {minutes:00}:{seconds:00}";
    }

    void EndGame(bool won)
    {
        gameEnded = true;
        Time.timeScale = 0f; // Freeze the game

        if (won)
        {
            winText.SetActive(true);
        }
        else
        {
            loseText.SetActive(true);

            // ✅ Play game over voice-over
            if (gameOverAudio != null && !gameOverAudio.isPlaying)
            {
                gameOverAudio.Play();
            }
        }

        RestartButton.SetActive(true);
    }

    public void PlayerReachedExit()
    {
        if (!gameEnded)
        {
            EndGame(true); // Player wins
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume time before restarting
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
