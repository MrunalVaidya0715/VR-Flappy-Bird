using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSpawner : MonoBehaviour
{
    public GameObject molePrefab;
    public Transform[] moleHoles;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 3f;

    private bool spawningEnabled = false; // Initialize spawning as disabled
    private Coroutine spawningCoroutine; // Reference to the coroutine

    // Method to start spawning moles
    public void StartSpawning()
    {
        spawningEnabled = true;
        spawningCoroutine = StartCoroutine(SpawnMolesCoroutine());
    }

    // Method to stop spawning moles
    public void StopSpawning()
    {
        spawningEnabled = false;
        if (spawningCoroutine != null)
        {
            StopCoroutine(spawningCoroutine);
        }
    }

    // Coroutine to spawn moles
    private IEnumerator SpawnMolesCoroutine()
    {
        while (spawningEnabled)
        {
            // Wait for a random delay between minSpawnDelay and maxSpawnDelay
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            // Spawn a mole if spawning is enabled
            if (spawningEnabled)
            {
                SpawnMole();
            }
        }
    }

    // Method to spawn a mole
    private void SpawnMole()
    {
        Transform hole = moleHoles[Random.Range(0, moleHoles.Length)];
        GameObject newMole = Instantiate(molePrefab, hole.position, Quaternion.identity, hole);
        Mole moleComponent = newMole.GetComponent<Mole>();
        if (moleComponent != null)
        {
            moleComponent.PopUp();
        }
    }
}
