using UnityEngine;
using TMPro; // For TextMeshProUGUI

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI scoreText; // Link this to the UI Text (TextMeshPro)

    void Update()
    {
        // Always show the current score
        scoreText.text = "Score: " + score;

        // ✅ TEMP: Add 10 points when Spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddPoints(10);
        }
    }

    public static void AddPoints(int points)
    {
        score += points;
    }
}
