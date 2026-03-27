using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerLives pL = collision.GetComponent<PlayerLives>();

            pL.KillPlayer();

            GameManager.instance.c.Disable();
        }
    }
}