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
    public bool attacking;
    public int health = 3;
    private AudioSource sound;
    public Vector3 respawnPoint;
    public static player play;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();
        respawnPoint = transform.position;
        GameController.Instance.updateLives(health);
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("enemy"))
        {
            damage(1);
            
        }
        if(collision.collider.CompareTag("Ground")){
            isJumping = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        meleeAttack();
    }

    void FixedUpdate(){
        Move();
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

        if(inputX == 0 && !isJumping && !attacking){
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
    void meleeAttack(){
        StartCoroutine("Attack");
    }
    IEnumerator Attack(){
        if(Input.GetKeyDown(KeyCode.K)){
            anim.SetInteger("transition", 3);
            attacking = true;
            yield return new WaitForSeconds(0.2f);
            anim.SetInteger("transition", 0);
            attacking = false;
            sound.Play();
        }
    }
    public void damage(int dmg){
        health -= dmg;
        anim.SetTrigger("hit");
        GameController.Instance.updateLives(health);
        Debug.Log("l");

        if(transform.rotation.y == 0){
            transform.position += new Vector3(-0.5f,0,0);

        }
        if(transform.rotation.y == 180){
            transform.position += new Vector3(0.5f,0,0);
            
        }

        if(health <= 0){
            GameController.Instance.GameOver();
         
        }
    }

    public void increaseHealth(int value)
    {
        health += value;
        GameController.Instance.updateLives(health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pit"))
        {
            GameController.Instance.GameOver();
            transform.position = respawnPoint;
        }
        else if (collision.CompareTag("checkpoint"))
        {
            respawnPoint = transform.position;
        }
    }

}
