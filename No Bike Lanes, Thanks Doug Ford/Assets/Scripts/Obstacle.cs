using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collided with: " + collision.name); //LOG
        if (collision.CompareTag("Border"))
        {
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            Destroy(player.gameObject);
        }
    }
}