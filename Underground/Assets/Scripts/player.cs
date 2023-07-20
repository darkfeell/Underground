using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public Rigidbody2D rig;
    public int speed;
    public bool isJumping;
    public int jumpForce;
    public Animator anim;
    public SpriteRenderer sprt;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground")){
            isJumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move(){
        float inputX = Input.GetAxisRaw("Horizontal");

        rig.velocity = new Vector2(inputX * speed, rig.velocity.y);

        if(inputX > 0){
            sprt.flipX = false;
            if(!isJumping){
                anim.SetInteger("transition", 1);
            }
            
        } 
        else if(inputX < 0){
            if(!isJumping){
               anim.SetInteger("transition", 1); 
            }
            sprt.flipX = true;
        }

        if(inputX == 0 && !isJumping){
            anim.SetInteger("transition", 0);
        }
    }
    void Jump(){
       if(Input.GetKey(KeyCode.Space)){
        if (!isJumping)
        {
            anim.SetInteger("transition", 2);
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
       } 
    }
    
}
