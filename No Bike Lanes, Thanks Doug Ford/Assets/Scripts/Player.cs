using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables
    private Rigidbody2D bikeBody;
    private Vector2 playerDirection;
    public float playerSpeed;
    public float acceleration;
    public float maxSpeed;
    public float deceleration;
    public float tiltAngle;
    public float tiltSpeed;
    public AudioSource bellRing;

    void Start()
    {
        bikeBody = GetComponent<Rigidbody2D>();
        // Prevent horizontal movement
        bikeBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        //Set direction to vertical
        float directionY = Input.GetAxisRaw("Vertical");

        // Detects input
        if (directionY != 0)
        {
            // Allow for veritcal movement
            playerDirection = new Vector2(0, directionY).normalized;
            // Increase speed
            playerSpeed += acceleration * Time.deltaTime;
            //Determine Tilt Direction Up/Down
            float targetTilt = directionY > 0 ? tiltAngle : -tiltAngle; 
            // Smooth rotation towards input direction up/down
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, targetTilt), tiltSpeed * Time.deltaTime);
        }
        // If no input
        else
        {
            // Decrease speed
            playerSpeed -= deceleration * Time.deltaTime; 
            // Smooth rotation towards nuetral posistion
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), tiltSpeed * Time.deltaTime);
        }

        // Declare playerspeed to be within the range of 0 and maxSpeed
        playerSpeed = Mathf.Clamp(playerSpeed, 0, maxSpeed);

        // Play bike ring sfx when 'R' is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayBellRing();
        }
    }

    void FixedUpdate()
    {
        //Move Bike Vertically Up/Down)
        bikeBody.velocity = new Vector2(0, playerDirection.y * playerSpeed);
    }

    // Play Bell Ring
    void PlayBellRing()
    {
        if (bellRing != null)
        {
            // Prevent Overlapping Sound
            if (!bellRing.isPlaying) 
            {
                //Play sound
                bellRing.Play();
            }
        }
    }
}