using System;
using UnityEngine;


public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    [Range(1,10)][SerializeField]private float jumpForce;
    private float move;
    private Animator animator;
    public ContactFilter2D contactFilter;
    [SerializeField]
    private SubGameStarter starterpanel;

    private PlayerManager playerManager;
    
    
    
    private bool IsGrounded => rb.IsTouching(contactFilter);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        rb= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        contactFilter.useNormalAngle = true;
        contactFilter.minNormalAngle = 80f;
        contactFilter.maxNormalAngle = 100f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Movement();
        Jump();
        AnimatorParams();
        Rotation();
        AltitudeCheck();
        







    }
    
    private void Movement()
    {
        move = Input.GetAxis("Horizontal"); //update'e çek if move!=0 movement();
        rb.linearVelocity = new Vector2(move * speed * Time.deltaTime, rb.linearVelocityY);
        

    }

    private void Jump()
    {
        if (Input.GetButton("Jump") && IsGrounded)
        {
            rb.linearVelocityY = jumpForce;

            SoundManager.Instance.jumpFX();
        }

    }


    private void Rotation()
    {
        if (move < 0) { this.transform.rotation=new Quaternion(0,180,0,0);return; }
        if (move > 0) { this.transform.rotation = new Quaternion(0, 0, 0, 0); }

    }

    private void AnimatorParams()
    {
        animator.SetBool("isgrounded", IsGrounded);
        animator.SetFloat("speed", Mathf.Abs(rb.linearVelocityX));
    }


    private void AltitudeCheck()
    {
        
        if (this.transform.position.y < -6.3f)
        {
            playerManager.Die();
            starterpanel.pause();

        }
    }

}
