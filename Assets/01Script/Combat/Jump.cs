using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 10f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float maxFallDistance = 5f;
    public float fallDamage = 20f;
    public GameObject particleEffect;

    public Animator anim;
    [SerializeField] CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
       // anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Jamping();
    }

    private void Jamping()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Player1_Jump") && isGrounded)
        {
            anim.SetTrigger("Jump");
            //velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            velocity.y = jumpForce;
            GameObject particle = Instantiate(particleEffect, transform.position, Quaternion.identity);
            Destroy(particle, 2f);
        }

        if (isGrounded)
        {
            anim.SetBool("IsJumping", true);
        }
        else
        {
            anim.SetBool("IsJumping", false);
        }

        /*if (!isGrounded)
        {
            anim.SetBool("IsJumping", true);
        }
        else
        {
            anim.SetBool("IsJumping", false);
        }*/

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (transform.position.y < -10f)
        {
            transform.position = new Vector3(0f, 5f, 0f);
        }

        if (transform.position.y < -maxFallDistance)
        {
            anim.SetTrigger("FallDamage");
            // Do something to reduce the player's health here
        }
    }
}
