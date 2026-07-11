using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    // A global string that remembers which door we are supposed to appear at
    public static string targetSpawnPointName = "";

    void Start()
    {
        // Only try to teleport if the door actually gave us a destination
        if (targetSpawnPointName != "")
        {
            // Search the entire scene for an object with that exact name
            GameObject spawnPoint = GameObject.Find(targetSpawnPointName);

            if (spawnPoint != null)
            {
                // Teleport the player to that object's position!
                transform.position = spawnPoint.transform.position;
            }
            else
            {
                Debug.LogWarning("Could not find a spawn point named: " + targetSpawnPointName);
            }
        }
    }
}