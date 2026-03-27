using UnityEngine;

public class AttackDetector : MonoBehaviour
{
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(enemy.isAttacking == false)
            {
                enemy.Attack();
            }
        }
    }
}
