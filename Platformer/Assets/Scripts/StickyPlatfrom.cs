using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatfrom : MonoBehaviour
{
    
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
        // Sticks the player 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
    
        if (collision.gameObject.name == "Player")
        // unsticks the player
        {
        
            collision.gameObject.transform.SetParent(null);
        }
    }
}
