using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour
{
    [SerializeField]
    private Transform player;  
    private float speed = 5.0f;  
    [SerializeField]
    private LayerMask groundLayer;  
    [SerializeField]
    private Transform triggerPoint;  
    private bool isFollowing = false;
    private Rigidbody2D rb;
    private Transform aiTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aiTransform = transform;
    }

    void Update()
    {
        if (player != null)
        {
           

            if (!isFollowing && triggerPoint != null && triggerPoint.GetComponent<Collider2D>().IsTouching(player.GetComponent<Collider2D>()))
            {
                isFollowing = true;
            }

            if (isFollowing)
            {
   
                Vector2 direction = player.position - aiTransform.position;
                direction.Normalize();

             
                if (direction.x < 0)
                {
                    aiTransform.localScale = new Vector3(Mathf.Abs(aiTransform.localScale.x), aiTransform.localScale.y, aiTransform.localScale.z); // Face right
                }
                else if (direction.x > 0)
                {
                    aiTransform.localScale = new Vector3(-Mathf.Abs(aiTransform.localScale.x), aiTransform.localScale.y, aiTransform.localScale.z); // Face left
                }

            
                RaycastHit2D hit = Physics2D.Raycast(aiTransform.position, direction, 1.0f, groundLayer);

                if (hit.collider != null)  //doesnt work, needs a fix
                {
                   
                    rb.velocity = Vector2.zero;
                }
                else
                {
                   
                    rb.velocity = direction * speed;
                }
            }
            else
            {
               
                rb.velocity = Vector2.zero;
            }
        }
    }
}













