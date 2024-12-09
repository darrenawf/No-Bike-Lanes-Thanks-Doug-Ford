/*
Attached: All Car/Bus/People Prefabs
*/
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy obstacle if it collides with border
        if (collision.CompareTag("Border"))
        {
            Destroy(this.gameObject);
        }
        // Destory player if it collides with obstacle
        if (collision.CompareTag("Player"))
        {
            Destroy(player.gameObject);
        }
    }
}