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
    public float tiltAngle;
    public float tiltSpeed;
    public AudioSource bellRing;

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

            float targetTilt = directionY > 0 ? tiltAngle : -tiltAngle; //Determine Tilt Direction (Up/Down)
            // Smoothly rotate the player to the target tilt
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, targetTilt), tiltSpeed * Time.deltaTime);
        }
        else
        {
            playerSpeed -= deceleration * Time.deltaTime; // Decrease speed

            // Smoothly rotate the player to neutral
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), tiltSpeed * Time.deltaTime);
        }

        // Clamp current speed to maxSpeed and 0 (no negative speed)
        playerSpeed = Mathf.Clamp(playerSpeed, 0, maxSpeed);

        // Play sound effect when 'R' key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayBellRing();
        }
    }

    void FixedUpdate()
    {
        // Apply vertical movement only
        bikeBody.velocity = new Vector2(0, playerDirection.y * playerSpeed);
    }

    // Method to play sound effect
    void PlayBellRing()
    {
        if (bellRing != null)
        {
            if (!bellRing.isPlaying) // Prevent overlapping sound
            {
                bellRing.Play();
            }
        }
        else
        {
            Debug.LogWarning("BellRing AudioSource is not assigned!");
        }
    }
}