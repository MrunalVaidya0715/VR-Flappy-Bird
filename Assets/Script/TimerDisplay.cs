using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
public class TimerDisplay : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to the TextMeshPro Text component

    // Method to update the timer text with the given time value
    public void UpdateTimerText(float time)
    {
        // Update the TextMeshPro Text component with the current time value
        timerText.text = "Time: " + FormatTime(time);
    }

    // Method to format time as minutes and seconds
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
