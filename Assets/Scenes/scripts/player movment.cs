using System.IO;
using UnityEngine;

public class playermovment : MonoBehaviour
{
    private Animator animator;
    public float speed = 3f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = true;
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = false;
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

    }
}
