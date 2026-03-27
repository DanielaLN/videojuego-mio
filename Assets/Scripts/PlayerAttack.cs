using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public GameObject rightBullet;

    public GameObject leftBullet;

    public Transform shootingPoint;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        GameManager.instance.c.World.Attack.performed += Attack;
    }

    private void Attack(InputAction.CallbackContext x)
    {
        anim.SetTrigger("Attack");
        Shoot();
    }

    public void Shoot()
    {
        if(GameManager.instance.fireAbility == true)
        {
            if(transform.rotation.eulerAngles == Vector3.zero)
            {
                Instantiate(rightBullet, shootingPoint.position, rightBullet.transform.rotation);
            }
            else
            {
                Instantiate(leftBullet, shootingPoint.position, leftBullet.transform.rotation);
            }

        }
    }

    private void OnDestroy()
    {
        GameManager.instance.c.World.Attack.performed -= Attack;
    }
}