using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables
    public float playerSpeed;
    public float acceleration;
    public float maxSpeed;
    public float deceleration;
    private Rigidbody2D bikeBody;
    private Vector2 playerDirection;
    public float tiltAngle = 5f;
    public float tiltSpeed = 5f; // Speed of tilting transition

    // Start is called before the first frame update
    void Start()
    {
        bikeBody = GetComponent<Rigidbody2D>();

        // Lock horizontal movement completely
        bikeBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");

        // Set direction based on input
        if (directionY != 0)
        {
            playerDirection = new Vector2(0, directionY).normalized;
            playerSpeed += acceleration * Time.deltaTime; // Increase speed

            // Calculate the tilt angle based on direction
            float targetTilt = directionY > 0 ? tiltAngle : -tiltAngle;
            // Smoothly rotate the player to the target tilt
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, targetTilt), tiltSpeed * Time.deltaTime);
        }
        else
        {
            playerSpeed -= deceleration * Time.deltaTime; // Decrease speed

            // Smoothly reset rotation to neutral
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), tiltSpeed * Time.deltaTime);
        }

        // Clamp current speed to maxSpeed and 0 (no negative speed)
        playerSpeed = Mathf.Clamp(playerSpeed, 0, maxSpeed);
    }

    void FixedUpdate()
    {
        // Apply vertical movement only
        bikeBody.velocity = new Vector2(0, playerDirection.y * playerSpeed);
    }
}