using UnityEngine;
using UnityEngine.InputSystem;

public class movementtest : MonoBehaviour
{
   [SerializeField] public float speed = 3f;
   public Animator anim;
   public SpriteRenderer sprite; 
    

    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        Vector3 movement = Vector3.zero;
        var keyboard = Keyboard.current;

        if (keyboard != null)
        {
            
            if (keyboard.dKey.isPressed) movement.x += 1;
            if (keyboard.aKey.isPressed) movement.x -= 1;
            if (keyboard.wKey.isPressed) movement.y += 1;
            if (keyboard.sKey.isPressed) movement.y -= 1;

           
            transform.position += movement.normalized * speed * Time.deltaTime;

            
            
            // Animator Parameters
            if (anim != null)
            {
                bool isMoving = movement.magnitude > 0;
               
               
                anim.SetBool("isMoving", isMoving);

                
                anim.SetFloat("X", movement.x);
                anim.SetFloat("Y", movement.y);
            
                if (keyboard.dKey.isPressed) anim.Play("Walking Side");
                else if (keyboard.wKey.isPressed) anim.Play("Walking up");
                else if (keyboard.sKey.isPressed) anim.Play("walking");
                else if (keyboard.aKey.isPressed) anim.Play("Walking left");
                else if (keyboard.aKey.isPressed) transform.localScale = new Vector3(-1, 1, 1); 
                else anim.Play("idle");    

                
            }
            
        }
    }
}