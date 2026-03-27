using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool canJump;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            canJump = false;
        }
    }
}
