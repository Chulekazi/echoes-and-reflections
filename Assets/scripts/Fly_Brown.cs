using UnityEngine;

public class Fly_Brown : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;       // How fast the object moves

    // We removed startX and targetX completely!

    // This is our switch to check if the camera has seen the object yet.
    private bool hasBeenSeen = false;

    void Awake()
    {
        // We removed the position snapping code!
        // The owl will now stay exactly where you manually dragged it in the Scene tab.
    }

    void Update()
    {
        // If the object hasn't been seen by the camera yet, wait patiently.
        if (hasBeenSeen == false)
        {
            return;
        }

        // Moves the object to the right at a constant speed
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    // Unity calls this automatically when the object enters the camera's view
    void OnBecameVisible()
    {
        // The camera sees it! Flip the switch so it starts moving.
        hasBeenSeen = true;
    }

    // NEW: Unity calls this automatically when the object completely LEAVES the camera's view!
    void OnBecameInvisible()
    {
        // We check if it hasBeenSeen first. This prevents the owl from instantly 
        // destroying itself at the start of the game while it waits off-screen!
        if (hasBeenSeen == true)
        {
            // It flew off the screen, so safely remove it from the game
            Destroy(gameObject);
        }
    }
}