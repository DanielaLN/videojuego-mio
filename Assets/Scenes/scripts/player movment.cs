using UnityEngine;

public class playermovment : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            animator.SetBool("isWalking", false);
            GetComponent <SpriteRenderer>().flipY = false;
        }

    }
}
