using UnityEngine;

public class ButterflyWander : MonoBehaviour
{
    [Header("Wander Settings")]
    public float speed = 3f;             // Top speed of the butterfly
    public float wanderRadius = 3f;      // How big the circular area is
    public float turnSpeed = 3f;         // How fast it steers (Higher = sharper turns, Lower = lazy wide curves)
    public float directionChangeTime = 0.5f; // How often (in seconds) it randomly changes direction

    private Vector3 centerPosition;
    private Vector3 currentVelocity;
    private Vector3 targetDirection;
    private SpriteRenderer spriteRenderer;
    private float timer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        centerPosition = transform.position;
        PickNewDirection();
    }

    void Update()
    {
        // 1. ORGANIC STEERING
        // We smoothly blend the butterfly's current momentum towards the new target direction.
        // This is the magic line that creates curves instead of straight lines!
        currentVelocity = Vector3.Lerp(currentVelocity, targetDirection * speed, turnSpeed * Time.deltaTime);

        // 2. MOVE THE BUTTERFLY
        transform.position += currentVelocity * Time.deltaTime;

        // 3. FLIP THE SPRITE
        // We use a tiny threshold (0.05f) so it doesn't flicker wildly if flying perfectly straight up/down
        if (currentVelocity.x > 0.05f)
        {
            spriteRenderer.flipX = true;  // Look right
        }
        else if (currentVelocity.x < -0.05f)
        {
            spriteRenderer.flipX = false; // Look left
        }

        // 4. THE ERRATIC FLUTTER TIMER
        // Every fraction of a second, the butterfly randomly changes its mind about where it's going.
        timer += Time.deltaTime;
        if (timer >= directionChangeTime)
        {
            PickNewDirection();
            timer = 0f; // Reset the timer
        }

        // 5. THE BOUNDARY CHECK
        // If it accidentally flies outside the yellow circle, we override its direction
        // and tell it to steer back toward the center anchor point.
        if (Vector3.Distance(centerPosition, transform.position) > wanderRadius)
        {
            Vector3 directionToCenter = (centerPosition - transform.position).normalized;
            targetDirection = directionToCenter;
        }
    }

    void PickNewDirection()
    {
        // Pick a completely random direction on a 360-degree wheel
        Vector2 randomDir = Random.insideUnitCircle.normalized;

        // Tell the butterfly this is the new way it wants to go
        targetDirection = new Vector3(randomDir.x, randomDir.y, 0f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 drawCenter = Application.isPlaying ? centerPosition : transform.position;
        Gizmos.DrawWireSphere(drawCenter, wanderRadius);
    }
}