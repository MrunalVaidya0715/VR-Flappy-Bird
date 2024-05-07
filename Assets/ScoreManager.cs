using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int toBeFilled = 15; // Total number of sockets to be filled
    private int filledCount = 0; // Number of sockets filled
    private float startTime; // Start time when filling begins
    public TMP_Text timerText; // Reference to the TextMeshPro component for displaying the timer
    private bool timerStarted = false; // Flag to track if the timer has started
    private bool timerStopped = false; // Flag to track if the timer has stopped

    void Start()
    {
        // Record the start time when the scene starts
        startTime = Time.time;
    }

    void Update()
    {
       
        timerStarted = true;
        StartCoroutine(UpdateTimer());

    }

    IEnumerator UpdateTimer()
    {
        while (!timerStopped)
        {
            // Calculate the elapsed time
            float elapsedTime = Time.time - startTime;

            // Update the timer display
            UpdateTimerDisplay(elapsedTime);

            yield return null;
        }
    }

    void UpdateTimerDisplay(float elapsedTime)
    {
        // Calculate minutes and seconds from elapsed time
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        // Update the timer text with the new time
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Public method to increment the count by +1
    public void IncrementCount()
    {
        filledCount++;
        Debug.Log(filledCount);

        // Check if all sockets are filled
        if (filledCount == toBeFilled)
        {
            // Calculate and log the time taken to fill all sockets
            float timeTaken = Time.time - startTime;
            Debug.Log("Time taken to fill all sockets: " + timeTaken + " seconds");

            // Stop the time
            timerStopped = true;
        }
    }
}
