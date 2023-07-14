using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public Rigidbody2D rig;
    public int speed;
    public bool isGrounded;
    public int jumpForce;
    public Animator anim;
    public SpriteRenderer sprt;
    //public GameObject attackPoint;
    //public float rad;
    //public LayerMask enemies;
    //public float inputX;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
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
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector3 inputTeclado = new Vector3(inputX, 0, 0);
        transform.position += inputTeclado * speed * Time.deltaTime;

        

        //Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

        //movement *= Time.deltaTime;
        
        //transform.Translate((movement));

        //rig.velocity = new Vector2(speed * inputX, rig.velocity.y);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetInteger("transition", 2);
        }
        if(Input.GetKeyDown(KeyCode.D)){
            anim.SetInteger("transition", 1);
            sprt.flipX = false;
        }
        if(Input.GetKeyDown(KeyCode.A)){
            anim.SetInteger("transition", 1);
            sprt.flipX = true;
        }
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.Space) && isGrounded == true){
            anim.SetInteger("transition", 0);
        }
        
        
    
    }
    //public void attack(){
            //Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, rad, enemies);

            //foreach(Collider2D enemyGameobject in enemies){

            //}
        //}
    //private void OnDrawGizmos(){
        //Gizmos.DrawWireSphere
    //}
}
