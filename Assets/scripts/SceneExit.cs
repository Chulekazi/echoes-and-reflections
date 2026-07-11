using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
    [Header("Target Destination")]
    public string sceneToLoad;

    [Tooltip("The exact name of the object in the NEXT scene where the player should appear")]
    public string spawnPointName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 1. Write the destination on the global whiteboard
            PlayerSpawner.targetSpawnPointName = spawnPointName;

            // 2. Load the next scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}