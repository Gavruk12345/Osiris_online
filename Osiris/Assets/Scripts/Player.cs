using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isRunning = false;
    private bool isGrounded = false;
    private bool isJumping = false; 

    public float distanceToMove = 5f; 
    public float moveSpeed = 2f;        

    private bool isMoving = false;     



    public Transform CheckGraund;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        HandleMovementInput();
        HandleAnimation();
        HandleJump();

    }

    public void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        bool runInput = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        if(runInput && IsGrounded())
        {
            MoveCharacter(horizontalInput, runSpeed);   
        }
        else
        {
            MoveCharacter(horizontalInput, walkSpeed);
        }
        FlipCharacter(horizontalInput);

        
    
       
    }

    public void MoveCharacter(float horizontalInput, float speed)
    {
        Vector2 movement = new Vector2(horizontalInput, 0f);
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);

        

    }
    IEnumerator MoveObject(Vector3 targetPosition)
        {
            isMoving = true;

            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

                yield return null;
            }

            isMoving = false;
        }
     


    public void FlipCharacter(float horizontalInput)
    {
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false; //вправо
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true; //вліво
        }
    }

    public void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                Jump();
                // Встановлюємо флаг стрибка в true
                isJumping = true;
                // Debug.Log("Jumping!");
            }
            else
            {
                // Debug.Log("Can't jump, not grounded!");
            }
        }
    }

    public void Jump()
    {
        float currentJumpForce = isRunning ? jumpForce * 1.5f : jumpForce;
        rb.velocity = new Vector2(rb.velocity.x, currentJumpForce);
    }


    public bool IsGrounded()
    {
        Collider2D coll = Physics2D.OverlapCircle(CheckGraund.position, 0.05f);

        isGrounded = coll != null && !isJumping;

        return coll != null;
    }   

    public void HandleAnimation()
    {
        bool isWalking = Mathf.Abs(rb.velocity.x) > 0;
        isRunning = isWalking && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));
        //Walk
        animator.SetBool("IsWalk", isWalking);
        animator.SetBool("IsRun", isRunning);
        //Jump
        float velocityThreshold = 3f;

        animator.SetBool("IsUp", !isGrounded && rb.velocity.y > velocityThreshold);
        animator.SetBool("IsDown", !isGrounded && rb.velocity.y < -velocityThreshold);


        //Roll
        animator.SetBool("IsRoll", isMoving); 

    }
    


}

