using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce;

    private Rigidbody2D rB;

    private GroundChecker gC;

    private void Awake()
    {
        rB = GetComponent<Rigidbody2D>();
        gC = GetComponentInChildren<GroundChecker>();
    }

    private void Start()
    {
        GameManager.instance.c.World.Jump.performed += Jump;
    }

    private void Jump(InputAction.CallbackContext x)
    {
        if(gC.canJump == true)
        {
            gC.canJump = false;
            rB.AddForce(Vector2.up * jumpForce);
        }
    }
}