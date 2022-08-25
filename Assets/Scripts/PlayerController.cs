using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    public float jumpForce;
    public float jumpForce2 = 5;
    private bool Grounded;
    bool puedeSaltar = true;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    const int ANIMATION_QUIETO = 0;
    const int ANIMATION_CORRER = 1;
    const int ANIMATION_SALTAR = 2;

    void Start()
    {
        Debug.Log("Iniciando script de Player");

        rb = GetComponent<Rigidbody2D>();

        sr = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        ChangeAnimation(ANIMATION_QUIETO);

        //puedeSaltar = true;
        if(Input.GetKey(KeyCode.RightArrow)){
            rb.velocity = new Vector2(velocity, rb.velocity.y); //(x, y)
            sr.flipX = false;
            ChangeAnimation(ANIMATION_CORRER);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            rb.velocity = new Vector2(-velocity, rb.velocity.y); //(x, y)
            sr.flipX = true;
            ChangeAnimation(ANIMATION_CORRER);
        }
        if(Input.GetKeyUp(KeyCode.Space) && puedeSaltar){
           rb.AddForce(new Vector2(0, jumpForce2), ForceMode2D.Impulse);
           puedeSaltar = false;
           ChangeAnimation(ANIMATION_SALTAR);
        }
        // else {
        //     rb.velocity = new Vector2(0, rb.velocity.y);
        //     ChangeAnimation(ANIMATION_QUIETO);
        // }
        // if(Physics2D.Raycast(transform.position, Vector3.down, 0.25f))
        // {
        //     Grounded = true;
        // }
        // else Grounded = false;

        // if(Input.GetKeyDown(KeyCode.UpArrow) && Grounded){
        //    Jump();
        //    ChangeAnimation(ANIMATION_SALTAR);
        // }
    }
    // private void Jump()
    // {
    //     rb.AddForce(Vector2.up * jumpForce);
    // }
    void OnCollisionEnter2D(Collision2D other){

        puedeSaltar = true;

        if(other.gameObject.tag == "Enemy"){
            Debug.Log("Estas Muerto");
        }
    }
    // void OnCollisionStay2D(Collision2D other)
    // {
    //     puedeSaltar = true;
    // }
    void ChangeAnimation(int animation){

        animator.SetInteger("Estado", animation);
    }
}
