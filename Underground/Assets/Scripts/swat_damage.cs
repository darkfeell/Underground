using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swat_damage : MonoBehaviour
{
    public int damage;
    public player health;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            health.damage(damage);
        }
    }
}
