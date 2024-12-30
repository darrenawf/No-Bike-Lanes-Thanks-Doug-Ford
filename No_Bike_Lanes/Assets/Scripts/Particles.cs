using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    // Variables
    private Rigidbody2D bikeBody;
    private Vector2 playerDirection;
    public float playerSpeed;
    public float acceleration;
    public float maxSpeed;
    public float deceleration;
    // Class References

    void Start()
    {
        bikeBody = GetComponent<Rigidbody2D>();
        // Prevent horizontal movement
        bikeBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        // Set direction to vertical
        float directionY = Input.GetAxisRaw("Vertical");

        // Detects input
        if (directionY != 0)
        {
            // Allow for vertical movement
            playerDirection = new Vector2(0, directionY).normalized;
            // Increase speed
            playerSpeed += acceleration * Time.deltaTime;
            // Determine Tilt Direction Up/Down
        }
        // If no input
        else
        {
            // Decrease speed
            playerSpeed -= deceleration * Time.deltaTime;
        }

        // Declare playerSpeed to be within the range of 0 and maxSpeed
        playerSpeed = Mathf.Clamp(playerSpeed, 0, maxSpeed);
    }

    void FixedUpdate()
    {
        // Move Bike Vertically Up/Down
        bikeBody.velocity = new Vector2(0, playerDirection.y * playerSpeed);
    }
}