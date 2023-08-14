using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    

    public float runSpeed = 40f;
    private float knockbackStartTime;
    private bool knockback;

    AudioSource audioSrc;
    [SerializeField]
    private float knockbackDuration;

    [SerializeField]
    private Vector2 knockbackSpeed;

    private Rigidbody2D rb;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

        // Update is called once per frame
        void Update()
    {
      horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
       
      animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        CheckKnockback();
        

        if (Input.GetButtonDown("Jump"))
      {
        jump = true;
        animator.SetBool("Jumping", true);
      } 

      if (Input.GetButtonDown("Crouch"))
      {
        crouch = true;
      } else if (Input.GetButtonUp("Crouch"))
      {
        crouch = false;
      }
    }

    public void Knockback(int direction)
    {
        knockback = true;
        knockbackStartTime = Time.time;
        rb.velocity = new Vector2(knockbackSpeed.x * direction, knockbackSpeed.y);
    }

    private void CheckKnockback()
    {
        if(Time.time >= knockbackStartTime + knockbackDuration && knockback)
        {
            knockback = false;
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }
    }
    


    public void OnLanding()
    {
      animator.SetBool("Jumping", false);
    }

    public void OnCrouching (bool Crouching)
    {
      animator.SetBool("Crouching", Crouching);
    }
    
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
