using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    public float MovementSpeed = 1;
    public float Jumpforce = 1;
    private float movement;
    private bool facingRight = true;
    private bool isGrounded; 
    public float checkRadius;
    

    // Component References
    public LayerMask whatIsGround;
    private Rigidbody2D _rigidbody;
    public Transform groundCheck;
    public Animator animator;


    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        // Checking if player is attacking or not
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("player_attack"))
        {
            _rigidbody.velocity = Vector2.zero;
            return;
        }

        // Getting Player input
        movement = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.velocity = Vector2.up * Jumpforce;
        }

        // Animating
        animator.SetFloat("horizontal_speed", Mathf.Abs(_rigidbody.velocity.x));
        animator.SetFloat("vertical_speed", _rigidbody.velocity.y);

    }

    private void FixedUpdate() 
    {
        
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("player_attack"))
        {
            _rigidbody.velocity = Vector2.zero;
            return;
        }

        // Ground Check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        
        // Moving the player using Velocity
        _rigidbody.velocity = new Vector2(movement * MovementSpeed, _rigidbody.velocity.y);

        // Flip the character logic
        if(facingRight == false && movement > 0)
        {
            Flip();
        } else if (facingRight == true && movement < 0)
        {
            Flip();
        }
        
    }

    void Flip(){
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    
}
