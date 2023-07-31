using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ticket : MonoBehaviour
{
    public static ticket ins;
    public int ticketQuantity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameController.Instance.updateTicket(ticketQuantity);
        }
    }
}
