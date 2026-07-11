using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    // This is the permanent whiteboard. It survives scene loads!
    public static string targetSpawnPointName = "";

    void Start()
    {
        // When the scene starts, check if there is a message on the whiteboard
        if (targetSpawnPointName != "")
        {
            // Search the new scene for an object with that exact name
            GameObject spawnPoint = GameObject.Find(targetSpawnPointName);

            if (spawnPoint != null)
            {
                // Teleport the player to that object
                transform.position = spawnPoint.transform.position;
            }
            else
            {
                Debug.LogWarning("Could not find spawn point: " + targetSpawnPointName);
            }

            // Wipe the whiteboard clean so we don't accidentally teleport again later
            targetSpawnPointName = "";
        }
    }
}