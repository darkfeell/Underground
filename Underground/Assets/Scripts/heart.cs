using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : MonoBehaviour
{
    public int healthValue;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<player>().increaseHealth(healthValue);
            Destroy(gameObject);
        }
    }
}
