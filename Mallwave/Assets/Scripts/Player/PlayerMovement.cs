using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _moveDirection;
    private Vector2 _lastDirection;
    private bool _isRunning;

    [HideInInspector]
    public bool canWalk;
    
    [SerializeField] 
    private float _speed;

    public Animator Animator { get; private set; }
    
    void Start()
    {
        this._rb = GetComponent<Rigidbody2D>();
        this.Animator = GetComponent<Animator>();
        this._speed = 150;
        this.canWalk = true;
    }
    

    void Update()
    {
        if (this.canWalk)
        {
            ProcessInput();
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        _isRunning = Input.GetKey(KeyCode.LeftShift);
        _moveDirection = new Vector2(moveX, moveY).normalized;
        
        Animator.SetBool("isWalking", true);

        if (moveX != 0 || moveY != 0) {
            _lastDirection = _moveDirection;
        }
        else
        {
            Animator.SetBool("isWalking", false);
        }
        Animator.SetFloat("Horizontal", _lastDirection.x);
        Animator.SetFloat("Vertical", _lastDirection.y);
        //Animator.SetFloat("speed", _moveDirection.sqrMagnitude);
        

    }

    void Move()
    {
        float final_speed = _isRunning ? _speed * 2f : _speed;
        _rb.velocity = _moveDirection * final_speed * Time.deltaTime;
    }
}
