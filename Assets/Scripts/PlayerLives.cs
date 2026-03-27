using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;

    public GameObject live3;
    public GameObject live2;
    public GameObject live1;

    private Animator anim;
    private Collider2D col;
    private Rigidbody2D rB;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        rB = GetComponent<Rigidbody2D>();
    }

    public void KillPlayer()
    {
        lives--;

        if(lives == 2)
        {
            live3.SetActive(false);
        }
        else if(lives == 1)
        {
            live2.SetActive(false);
        }
        if(lives <= 0)
        {
            live1.SetActive(false);
            GameManager.instance.c.Disable();

            col.enabled = false;

            rB.gravityScale = 0f;

            rB.linearVelocity = Vector2.zero;

            anim.SetTrigger("Death");
        }
    }

    //Esta función se lanza desde la animación.
    public void ActivateGameOver()
    {
        GameManager.instance.GameOver();
    }
}