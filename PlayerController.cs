using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInputs InputActions;

    public float speed = 2.7f;
    public float jumpForce = 5f;

    public GameObject shotPrefab;
    public float shotForce = 10f;

    bool canJump = true;
    bool canAttack = true;

    SpriteRenderer sprite;
    Animator animator;
    Rigidbody2D body;

    void Awake()
    {
        InputActions = new PlayerInputs();
    }

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        InputActions.Enable();
    }

    private void OnDisable()
    {
        InputActions.Disable();
    }

    void Update()
    {
        var MoveInputs = InputActions.PlayerMap.Movement.ReadValue<Vector2>();

        transform.position += speed * Time.deltaTime * new Vector3(MoveInputs.x, 0, 0);

        animator.SetBool("b_isWalking", MoveInputs.x != 0);

        if (MoveInputs.x != 0)
        {
            sprite.flipX = MoveInputs.x < 0;
        }

        canJump = Mathf.Abs(body.velocity.y) <= 0.001f;

        HandlerJumpAction();

        HandleAttack();
    }

    void HandlerJumpAction()
    {
        var jumpPressed = InputActions.PlayerMap.Jump.IsPressed();

        if (canJump && jumpPressed)
        {
             body.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
        }
    }  
    void HandleAttack()
    {
            var attackPressed = InputActions.PlayerMap.Attack.IsPressed();

            if (canAttack && attackPressed)
            {
                canAttack = false;

                animator.SetTrigger("t_attack");
            }
    }

    public void ShotNewEgg()
    {
        var newShot = GameObject.Instantiate(shotPrefab);
                newShot.transform.position = transform.position;

                var isLookRight = !sprite.flipX;
                Vector2 shotDirection = shotForce * new Vector2(isLookRight ? -1 : 1, 0);
                newShot.GetComponent<Rigidbody2D>().AddForce(shotDirection, ForceMode2D.Impulse);
                newShot.GetComponent<SpriteRenderer>().flipY = !isLookRight;
    }
    public void SetCanAttack()
    {
        canAttack = true;
    }
}
