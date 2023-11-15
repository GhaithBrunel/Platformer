using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby_Frog : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;  // Adjust this value to control the jump height
    [SerializeField] private float jumpDelay = 1f;  // Adjust this value to control the time between jumps
    private Rigidbody2D rb;
    private bool canJump = false;
    [SerializeField] private LayerMask groundLayer;  // Assign the ground layer in the Unity Editor
    [SerializeField] private GameObject triggerPoint;  // Assign the trigger point object in the Unity Editor
    [SerializeField] private GameObject player;  // Assign the player object in the Unity Editor

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Start the automatic jumping process
        StartCoroutine(AutomaticJumping());
    }

    IEnumerator AutomaticJumping()
    {
        while (true)
        {
            // Wait for the frog to be able to jump (detect the player hitting the trigger point)
            yield return new WaitUntil(() => DetectPlayerHitTriggerPoint());

            // Call the Jump method
            Jump();

            // Reset canJump flag
            canJump = false;

            // Wait for the specified delay before the next jump
            yield return new WaitForSeconds(jumpDelay);
        }
    }

    void Jump()
    {
        // Apply a force to the Rigidbody2D to make the character jump
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    bool DetectPlayerHitTriggerPoint()
    {
        // Check if the trigger point is touching the player
        if (triggerPoint.GetComponent<Collider2D>().IsTouching(player.GetComponent<Collider2D>()))
        {
            canJump = true;
            return true;
        }

        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the ground layer
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            canJump = true;
        }
    }
}




