using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    private float attackTime;
    public float startAttackTime;
    public LayerMask enem;
    public Transform attackPosition;
    public float attackRange;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(attackTime == 0){
            if(Input.GetKey(KeyCode.K)){
                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, enem);
                for(int i = 0; i < enemies.Length; i++){
                    enemies[i].GetComponent<Enemy1>().health -= damage;
                } 

            }
            attackTime = startAttackTime;
        }
        else{
            attackTime -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);

    }
}
