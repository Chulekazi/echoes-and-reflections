using UnityEngine;

public class SnailRight : MonoBehaviour
{
    [Header("Speed Settings")]
    public float speed = 0.1f;

    [Header("Positions")]
    // Vector3 lets us set X (left/right), Y (up/down), and Z (forward/back) all at once!
    public Vector3 startPosition = new Vector3(-1f, 1f, 0f);   // Starts high up and on the left
    public Vector3 swoopTarget = new Vector3(0.5f, 0f, 0f);      // Where the diagonal swoop ends
    public float disappearX = 24f;                             // Where it vanishes off the right side of the screen

    // This is our switch for the movement phases.
    private bool isDiagMove = true;

    // NEW: This is our switch to check if the camera has seen the snail yet.
    private bool hasBeenSeen = false;

    void Start()
    {
        // Snap to the exact starting coordinates right when the game plays
        transform.position = startPosition;
    }

    void Update()
    {
        // NEW: If the snail hasn't been seen by the camera yet, we "return".
        // "return" forces the script to exit the Update loop immediately, preventing any movement.
        if (hasBeenSeen == false)
        {
            return;
        }

        // PHASE 1: The Diagonal Swoop
        if (isDiagMove == true)
        {
            // MoveTowards automatically calculates the diagonal path and prevents overshooting
            transform.position = Vector3.MoveTowards(transform.position, swoopTarget, speed * Time.deltaTime);

            // Check how far we are from the target. If it's practically zero, we made it!
            if (Vector3.Distance(transform.position, swoopTarget) < 0.01f)
            {
                isDiagMove = false; // Flip the switch to trigger Phase 2!
            }
        }

        // PHASE 2: Flying Straight Right
        else
        {
            // Fly continuously to the right
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            // Destroy the snail once it flies past our disappear point
            if (transform.position.x >= disappearX)
            {
                Destroy(gameObject);
            }
        }
    }

    // NEW: Unity calls this automatically when the object's Renderer enters a camera's view!
    void OnBecameVisible()
    {
        // The camera sees it! Flip the switch so the Update loop can start moving it.
        hasBeenSeen = true;
    }
}