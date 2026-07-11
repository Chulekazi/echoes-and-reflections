using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        bool iswalking = Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.W);
        anim.SetBool("isMoving",iswalking);
    }
}
