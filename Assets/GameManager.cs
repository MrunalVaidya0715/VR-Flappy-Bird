using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TimerDisplay timerDisplay; // Reference to the TimerDisplay component
    public MoleSpawner moleSpawner; // Reference to the MoleSpawner component
    public float totalTime = 60f; // Total time for the timer

    private float currentTime; // Current time for the timer
    private bool isTimerRunning = false; // Flag to track if the timer is running

    private void Update()
    {
        // Start timer and mole spawning when Enter key is pressed
        if (Input.GetKeyDown(KeyCode.Return) && !isTimerRunning)
        {
            StartGame();
        }

        // Check if the timer is running
        if (isTimerRunning)
        {
            // Update timer
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = 0;
                // Handle timer end
                Debug.Log("Time's up!");
                StopGame();
            }

            // Update timer display
            timerDisplay.UpdateTimerText(currentTime);
        }
    }

    // Method to start the game (timer and mole spawning)
    private void StartGame()
    {
        currentTime = totalTime;
        isTimerRunning = true;
        // Start the timer
        // timerDisplay.StartTimer();
        // Start spawning moles
        moleSpawner.StartSpawning();
    }

    // Method to stop the game (timer and mole spawning)
    private void StopGame()
    {
        isTimerRunning = false;
        // Stop the timer
        // timerDisplay.StopTimer();
        // Stop spawning moles
        moleSpawner.StopSpawning();
    }
}
