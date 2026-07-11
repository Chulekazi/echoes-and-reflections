using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [Header("Target Destination")]
    [Tooltip("The exact name of the scene to load")]
    public string sceneToLoad;

    [Tooltip("The exact name of the object in the NEXT scene where the player should appear")]
    public string spawnPointName;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Send the message to our global variable
            PlayerSpawner.targetSpawnPointName = spawnPointName;

            // Load the scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}