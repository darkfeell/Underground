using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2mov : MonoBehaviour
{
    public Transform[] patrolPoint;
    public float moveSpeed;
    public int patrolDest;

    //public Transform playerTransform;
    //public bool isChasing;
    //public float chaseDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
        //{
        //isChasing = true;
        //}
        //if (isChasing == true)
        //{
        //if(transform.position.x > playerTransform.position.x)
        // {
        // transform.eulerAngles = new Vector3(0, -180, 0);
        //  transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        // }
        // if (transform.position.x < playerTransform.position.x)
        // {
        //   transform.eulerAngles = new Vector3(0, 0, 0);
        //   transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        // }
        //  }
        //else
        //{
        //isChasing = false;




        //}

        if (patrolDest == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoint[0].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoint[0].position) < 0.2f)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                patrolDest = 1;
            }
        }
        if (patrolDest == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoint[1].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoint[1].position) < 0.2f)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                patrolDest = 0;
            }
        }

    }
}
