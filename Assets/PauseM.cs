using UnityEngine;

public class PauseM : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject resumeButton;

    private bool isPaused = false;

    public void PauseGame()
    {
        Time.timeScale = 0f; // Pause time
        isPaused = true;
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume time
        isPaused = false;
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
    }
}
