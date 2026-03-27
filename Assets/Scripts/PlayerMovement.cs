using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    public float leftLimit = -8;

    public float rightLimit = 8;

    private Rigidbody2D rB;

    private SpriteRenderer sR;

    private Animator anim;

    private Vector2 dir;

    private void Awake()
    {
        rB = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
        anim  = GetComponent<Animator>();
    }

    void Update()
    {
        dir = GameManager.instance.c.World.Dir.ReadValue<Vector2>();
        CheckDir();
        AnimatorController();
        CheckLimits();
    }

    private void FixedUpdate()
    {
        rB.linearVelocity = new Vector2(dir.x * speed, rB.linearVelocity.y);
    }

    private void CheckDir()
    {
        if(dir.x > 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }

        if(dir.x < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
        }
    }

    private void AnimatorController()
    {
        if(dir.x != 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }

    private void CheckLimits()
    {
        if(transform.position.x <= leftLimit)
        {
            transform.position = new Vector3(leftLimit, transform.position.y, transform.position.z);
        }

        if(transform.position.x >= rightLimit)
        {
            transform.position = new Vector3(rightLimit, transform.position.y, transform.position.z);
        }
    }
}
