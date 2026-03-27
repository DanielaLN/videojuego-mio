using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    public float rightLimit;

    public float leftLimit;

    private Vector2 dir;

    public int lives;

    public bool isAttacking;

    private Animator anim;

    private Rigidbody2D rB;

    private SpriteRenderer sR;

    public GameObject playerDetector; 

    public GameObject damageEnemy;

    private Collider2D col;

    public bool unlockCat;

    public Cat cat;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rB = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        dir = Vector2.right;
    }

    private void Update()
    {
        CheckLimits();
    }

    private void FixedUpdate()
    {
        if (isAttacking == false)
        {
            rB.linearVelocity = dir * speed;
        }
        else
        {
            rB.linearVelocity = Vector2.zero;
        }
    }

    private void CheckLimits()
    {
        if(transform.position.x < leftLimit)
        {
            dir = Vector2.right;
        }

        if (transform.position.x > rightLimit)
        {
            dir = Vector2.left;
        }

        if(dir.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if(dir.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void GetDamage()
    {
        lives--;

        Debug.Log("Recibiendo daño");

        if(lives <= 0)
        {
            speed = 0;
            playerDetector.SetActive(false);
            damageEnemy.SetActive(false);
            col.enabled = false;
            anim.SetTrigger("Death");
        }
    }

    public void Attack()
    {
        isAttacking = true;
        anim.SetTrigger("Attack");
    }

    public void EndAttack()
    {
        isAttacking = false;
    }

    public void EndDeathAnimation()
    {
        if (unlockCat)
        {
            if(cat != null)
            {
                cat.unlocked = true;
            }
        }

        Destroy(gameObject);
    }
}