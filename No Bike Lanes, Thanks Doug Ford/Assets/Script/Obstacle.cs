using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with: " + collision.name); // Log the object it collided with

        if (collision.CompareTag("Border")) // Use CompareTag for better performance
        {
            Destroy(this.gameObject);
        }
    }
}