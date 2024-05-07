using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mole : MonoBehaviour
{
    private Vector3 originalPosition;
    private bool isPopped = false;

    public AudioSource popUpAudioSource;
    public AudioClip popUpClip;

    private static int score = 0;
    private static int missed = 0;  


    private void Start()
    {
        // Store the original position of the mole
        originalPosition = transform.localPosition;
        originalPosition.y -= 0.15f;


    }

    // Method to handle mole destruction
    public void DestroyMole()
    {
        Destroy(gameObject); // Destroy the mole GameObject
    }

    // Method to pop the mole out of the mole hole
    public void PopUp()
    {
        if (!isPopped)
        {
            // Move the mole upward slightly
            transform.Translate(Vector3.up * 0.001f, Space.Self);
            isPopped = true;
            // Play the pop-up sound
            popUpAudioSource.PlayOneShot(popUpClip);

            // Schedule pop down after 3 seconds if not hit
            Invoke("PopDownAndDestroy", 3f);
        }
    }

    // Method to pop the mole down into the mole hole and destroy it
    public void PopDownAndDestroy()
    {
        if (isPopped)
        {
            IncrementMissedScore(1);
            // Move the mole back to its original position
            transform.localPosition = originalPosition;
            isPopped = false;

            // Destroy the mole after returning to original position
            DestroyMole();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hammer")
        {
           
            DestroyMole();
            // Play the hit sound
            IncrementScore(10);

        }
    }
    // Method to increment the score
    private void IncrementScore(int value)
    {
        score += value;
        Debug.Log("Score: " + score);

        // Find the ScoreDisplay component in the scene
        ScoreDisplay scoreDisplay = FindObjectOfType<ScoreDisplay>();
        if (scoreDisplay != null)
        {
            // Update the score text with the new score value
            scoreDisplay.UpdateScoreText(score);
        }
        else
        {
            Debug.LogError("ScoreDisplay component not found in the scene.");
        }
    }
    private void IncrementMissedScore(int value)
    {
        missed += value;
        Debug.Log("Missed: " + missed);

        // Find the ScoreDisplay component in the scene
        MissedDisplay missedDisplay = FindObjectOfType<MissedDisplay>();
        if (missedDisplay != null)
        {
            // Update the score text with the new score value
            missedDisplay.UpdateMissedText(missed);
        }
        else
        {
            Debug.LogError("MissedDisplay component not found in the scene.");
        }
    }
}