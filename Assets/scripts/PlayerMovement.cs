using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movementInput;
    private Animator anim;
    private SpriteRenderer sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementInput = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movementInput.y = 1;  
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movementInput.y = -1; 
        }

        if (Input.GetKey(KeyCode.D))
        {
            movementInput.x = 1; 
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movementInput.x = -1;
        }
    }

    void FixedUpdate()
    {
        Vector2 isoMovement = ConvertToIsometric(movementInput);
        rb.linearVelocity = isoMovement.normalized * moveSpeed;
    }

    Vector2 ConvertToIsometric(Vector2 standardInput)
    {
        float isoX = standardInput.x - standardInput.y;
        float isoY = (standardInput.x + standardInput.y) * 0.5f;

        return new Vector2(isoX, isoY);
    }
    
}


