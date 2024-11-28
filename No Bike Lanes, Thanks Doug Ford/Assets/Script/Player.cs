using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
    public float playerSpeed;
    public float acceleration;
    public float maxSpeed;
    public float deceleration;
    private Rigidbody2D bikeBody;
    private Vector2 playerDirection;
    // Start is called before the first frame update
    void Start()
    {
        bikeBody = GetComponent<Rigidbody2D>();
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
        }
        else
        {
            playerSpeed -= deceleration * Time.deltaTime; // Decrease speed if no input
        }

        // Clamp current speed to maxSpeed and 0 (no negative speed)
        playerSpeed = Mathf.Clamp(playerSpeed, 0, maxSpeed);
    }

    void FixedUpdate()
    {
        bikeBody.velocity = new Vector2(0, playerDirection.y * playerSpeed);
    }
}
