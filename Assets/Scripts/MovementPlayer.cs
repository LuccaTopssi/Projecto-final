using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float runSpeed = 2f;
    public float jumpForce = 4f;
    Transform tramoAgarrado;
    bool agarrado = false;
    public Vector3 offset;
    public float movX;
    public float jumpForceChain = 8;
    Animator animator;


    SpriteRenderer sR;
    Rigidbody2D rb2D;
    public CheckGroundFInal IsGrounded;
    public float multiplicadorChoque = 10f;
    public float swingForce = 50f;

    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        movX = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");
        if (agarrado)
        {
            //posicionar y rotar igual al tramo
            transform.position = tramoAgarrado.transform.position + offset;
            transform.rotation = tramoAgarrado.transform.rotation;

            if (Input.GetButtonDown("Jump"))
            {
                if (movY < 0)
                {
                    seSuelta();
                }
                else
                {
                    seSuelta();
                    transform.rotation = Quaternion.Euler(0,0,0);
                    saltarCuerda();
                }
            }
            tramoAgarrado.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(movX * swingForce, 0);
        }
        else
        {
            rb2D.velocity = new Vector2(movX * runSpeed, rb2D.velocity.y);
            if (Input.GetKey("space") && IsGrounded.isGrounded)
            {
                saltar();
            }
            GirarSprite();
            Animations();

        }

    }


    void Animations()
    {
        if (movX != 0 && IsGrounded.isGrounded == true)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
        if (IsGrounded.isGrounded == false)
        {
            animator.SetBool("Jumping", true);
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Jumping", false);
        }
    }
    void GirarSprite()
    {
        if (movX > 0)
        {
            sR.flipX = false;
        }
        if (movX < 0)
        {
            sR.flipX = true;
        }
    }
    void seSuelta()
    {
        agarrado = false;
        rb2D.isKinematic = false;
    }
    void saltar()
    {

        rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
    }
    void saltarCuerda()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForceChain);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Chains") && Input.GetKey(KeyCode.E))
        {

                //se agarra
                agarrado = true;
                //1. que se mueva y rote con la cuerda
                tramoAgarrado = other.transform;
                //2. dar un impulso
                //other.GetComponent<Rigidbody2D>().AddForce(rb2D.velocity * multiplicadorChoque);
                //3. suspender la gravedad
                rb2D.isKinematic = true;
        }
    }
}