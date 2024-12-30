/*
Attached: ???
*/
/*
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private float speed;

    public void Initialize(float carSpeed)
    {
        speed = carSpeed;
    }

    void Update()
    {
        // Move the car to the right
        transform.Translate(speed * Time.deltaTime, 0, 0);

        // Deactivate the car if it goes off-screen
        if (transform.position.x > Camera.main.transform.position.x + 20)
        {
            gameObject.SetActive(false);
        }
    }
}
*/