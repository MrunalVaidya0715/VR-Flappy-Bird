using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleHole : MonoBehaviour
{
    private bool hasMole = false; // Indicates if the mole hole currently has a mole

    // Method to spawn a mole inside the mole hole
    public void SpawnMole(GameObject molePrefab)
    {
        if (!hasMole) // Check if the mole hole doesn't already have a mole
        {
            // Spawn the mole prefab inside the mole hole
            GameObject newMole = Instantiate(molePrefab, transform.position, Quaternion.identity, transform);
            hasMole = true; // Set hasMole to true to indicate that the mole hole now has a mole
        }
    }

    // Method to destroy the mole inside the mole hole
    public void DestroyMole()
    {
        if (hasMole) // Check if the mole hole has a mole
        {
            // Get the mole component from the mole GameObject
            Mole moleComponent = GetComponentInChildren<Mole>();
            if (moleComponent != null)
            {
                moleComponent.PopDownAndDestroy();
            }
            hasMole = false; // Set hasMole to false to indicate that the mole hole no longer has a mole
        }
    }
}
