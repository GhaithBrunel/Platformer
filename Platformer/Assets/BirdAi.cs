using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour
{
    [SerializeField]
    private Transform player;  // Reference to the player object
    [SerializeField]
    private float speed = 5.0f;  // Speed at which the AI follows the player
    [SerializeField]
    private LayerMask groundLayer;  // Specify the ground layer
    [SerializeField]
    private Transform triggerPoint;  // Reference to the empty GameObject where the player triggers the bird to follow

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
            // If the player hits the trigger point, start following
            if (!isFollowing && triggerPoint != null && triggerPoint.GetComponent<Collider2D>().IsTouching(player.GetComponent<Collider2D>()))
            {
                isFollowing = true;
            }

            if (isFollowing)
            {
                // Calculate the direction to the player
                Vector2 direction = player.position - aiTransform.position;
                direction.Normalize();

                // Flip the AI's sprite to face the player
                if (direction.x < 0)
                {
                    aiTransform.localScale = new Vector3(Mathf.Abs(aiTransform.localScale.x), aiTransform.localScale.y, aiTransform.localScale.z); // Face right
                }
                else if (direction.x > 0)
                {
                    aiTransform.localScale = new Vector3(-Mathf.Abs(aiTransform.localScale.x), aiTransform.localScale.y, aiTransform.localScale.z); // Face left
                }

                // Perform a raycast to check for obstacles (using the specified layer)
                RaycastHit2D hit = Physics2D.Raycast(aiTransform.position, direction, 1.0f, groundLayer);

                if (hit.collider != null)
                {
                    // An obstacle on the specified layer is detected, stop moving
                    rb.velocity = Vector2.zero;
                }
                else
                {
                    // No obstacle detected, move the AI toward the player
                    rb.velocity = direction * speed;
                }
            }
            else
            {
                // The AI is not following, so it should remain stationary
                rb.velocity = Vector2.zero;
            }
        }
    }
}













