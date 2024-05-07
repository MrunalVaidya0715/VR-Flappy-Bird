using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        // Ensure that the score text component is linked in the Inspector
        if (scoreText == null)
        {
            Debug.LogError("Score text component is not assigned in the Inspector.");
            return;
        }
        UpdateScoreText(0);

    }

    public void UpdateScoreText(int score)
    {
        // Update the text component with the current score value
        scoreText.text = "Score " + score.ToString();
        
    }
}
