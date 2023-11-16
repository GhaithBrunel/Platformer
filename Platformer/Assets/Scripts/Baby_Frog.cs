using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby_Frog : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f; 
    [SerializeField] private float jumpDelay = 1f;  
    private Rigidbody2D rb;
    private bool canJump = false;
    [SerializeField] private LayerMask groundLayer;  
    [SerializeField] private GameObject triggerPoint;  
    [SerializeField] private GameObject player;  

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    
        StartCoroutine(AutomaticJumping());
    }

    IEnumerator AutomaticJumping()
    {
        while (true)
        {
            
            yield return new WaitUntil(() => DetectPlayerHitTriggerPoint());

          
            Jump();

            canJump = false;
            yield return new WaitForSeconds(jumpDelay);
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    bool DetectPlayerHitTriggerPoint()
    {
        if (triggerPoint.GetComponent<Collider2D>().IsTouching(player.GetComponent<Collider2D>()))
        {
            canJump = true;
            return true;
        }

        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            canJump = true;


        }
    }
}




