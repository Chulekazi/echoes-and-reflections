using UnityEngine;

public class SnailPhases : MonoBehaviour
{
    [Header("Speed Settings")]
    public float normalSpeed = 3f;  // Speed for Phase 1 (Diagonal) and Phase 3 (Right)
    public float dropSpeed = 5f;    // NEW: Dedicated speed just for Phase 2 (Drop)

    [Header("Rotation Settings")]
    public float startRotationZ = -48f;
    public float targetRotationZ = 0f;

    [Header("Movement Distances")]
    [Tooltip("Which way is diagonal? (1, 1) is Up-Right. (1, -1) is Down-Right.")]
    public Vector2 diagonalDirection = new Vector2(1f, 1f);
    public float distanceD = 5f;   // How far to travel diagonally
    public float distanceV = 3f;   // How far to drop straight down
    public float distanceR = 10f;  // How far to travel right before destroying

    private Vector3 target1_Diagonal;
    private Vector3 target2_Drop;
    private Vector3 target3_Right;

    private int currentPhase = 0;

    void Awake()
    {
        Vector3 startPos = transform.position;

        target1_Diagonal = startPos + (Vector3)(diagonalDirection.normalized * distanceD);
        target2_Drop = target1_Diagonal + new Vector3(0f, -distanceV, 0f);
        target3_Right = target2_Drop + new Vector3(distanceR, 0f, 0f);

        // Snap the snail to its starting rotation the moment the game boots
        transform.rotation = Quaternion.Euler(0f, 0f, startRotationZ);
    }

    void Update()
    {
        if (currentPhase == 0) return;

        // PHASE 1: Diagonal
        if (currentPhase == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, target1_Diagonal, normalSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, target1_Diagonal) < 0.01f)
            {
                currentPhase = 2;
            }
        }
        // PHASE 2: Vertical Drop
        else if (currentPhase == 2)
        {
            // 1. Move downwards using the new dropSpeed
            transform.position = Vector3.MoveTowards(transform.position, target2_Drop, dropSpeed * Time.deltaTime);

            // 2. DYNAMIC ROTATION MATH
            // Figure out exactly how far we've fallen from the start of the drop
            float distanceFallen = Vector3.Distance(target1_Diagonal, transform.position);

            // Calculate what 3/4 (75%) of the total drop distance is
            float rotationFinishDistance = distanceV * 0.75f;

            // Divide them to get a percentage (0.0 to 1.0) of how close we are to that 3/4 mark
            float rotationProgress = distanceFallen / rotationFinishDistance;

            // Clamp01 forces the percentage to stop at exactly 1.0. 
            // Without this, the snail would keep rotating past 0 degrees for the last 1/4 of the fall!
            rotationProgress = Mathf.Clamp01(rotationProgress);

            // Calculate the exact angle based on our percentage, and apply it
            float currentAngle = Mathf.Lerp(startRotationZ, targetRotationZ, rotationProgress);
            transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);

            // Check if we arrived at the bottom
            if (Vector3.Distance(transform.position, target2_Drop) < 0.01f)
            {
                currentPhase = 3;
            }
        }
        // PHASE 3: Horizontal Right
        else if (currentPhase == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, target3_Right, normalSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, target3_Right) < 0.01f)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnBecameVisible()
    {
        if (currentPhase == 0)
        {
            currentPhase = 1;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Vector3 startPos = transform.position;
        Vector3 t1 = startPos + (Vector3)(diagonalDirection.normalized * distanceD);
        Vector3 t2 = t1 + new Vector3(0f, -distanceV, 0f);
        Vector3 t3 = t2 + new Vector3(distanceR, 0f, 0f);

        Gizmos.DrawLine(startPos, t1);
        Gizmos.DrawLine(t1, t2);
        Gizmos.DrawLine(t2, t3);

        Gizmos.DrawWireSphere(t1, 0.2f);
        Gizmos.DrawWireSphere(t2, 0.2f);
        Gizmos.DrawWireSphere(t3, 0.2f);
    }
}