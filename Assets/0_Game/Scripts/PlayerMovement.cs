using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 5f;
    [HideInInspector] public Vector3 moveDir;
    public Vector3 lastMovedVector;

    [Header("Visual")]
    [SerializeField] Transform visual; 

    // Animator
    static readonly int RunHash = Animator.StringToHash("Run");

    Rigidbody rb;
    Animator anim;
    InputSystem_Actions inputActions;

    Vector2 moveInput;
    bool isFacingRight = true;
    bool isRunning;

    Transform cam;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        inputActions = new InputSystem_Actions();
    }

    void Start()
    {
        cam = Camera.main.transform;
        lastMovedVector = Vector3.forward;
    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        ReadInput();
        UpdateAnimation();
    }

    void FixedUpdate()
    {
        Move();
        HandleFlip();
    }

    void ReadInput()
    {
        moveInput = inputActions.Player.Move.ReadValue<Vector2>();
    }

    void Move()
    {
        Vector3 velocity = rb.linearVelocity;

        if (moveInput.sqrMagnitude < 0.01f)
        {
            velocity.x = 0;
            velocity.z = 0;
            rb.linearVelocity = velocity;
            return;
        }

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        moveDir = camRight * moveInput.x + camForward * moveInput.y;
        lastMovedVector = moveDir;
        rb.linearVelocity = moveDir * moveSpeed;
    }


    void UpdateAnimation()
    {
        bool runningNow = moveInput.sqrMagnitude > 0.01f;
        if (isRunning != runningNow)
        {
            isRunning = runningNow;
            anim.SetBool(RunHash, isRunning);
        }
    }

    void HandleFlip()
    {
        float xVel = rb.linearVelocity.x;

        if (xVel > 0.1f && !isFacingRight)
            Flip();
        else if (xVel < -0.1f && isFacingRight)
            Flip();
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 scale = visual.localScale;
        scale.x *= -1;
        visual.localScale = scale;
    }
}
