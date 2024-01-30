using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _moveDirection;
    private Vector2 _lastDirection;
    private bool _isRunning;
    private PlayerManager _manager;

    [HideInInspector]
    public bool canWalk;

    [HideInInspector]
    public bool isTalking;
    [HideInInspector]
    public bool isPaused;

    [SerializeField]
    private float _speed;

    public Animator Animator { get; private set; }

    void Start()
    {
        this._rb = GetComponentInParent<Rigidbody2D>();
        this._manager = GetComponentInParent<PlayerManager>();
        this.Animator = GetComponentInParent<Animator>();
        this._speed = 150;
        this.canWalk = true;
    }


    void Update()
    {
        CheckWalk();
        if (this.canWalk)
        {
            ProcessInput();
        }
        else
        {
            _moveDirection = Vector2.zero;
        }
    }

    private void CheckWalk()
    {
        this.canWalk = !(_manager.inventoryUIController.isInventoryOpen || isTalking || isPaused);
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
        

    }

    void Move()
    {
        float final_speed = _isRunning ? _speed * 2f : _speed;
        _rb.velocity = _moveDirection * final_speed * Time.deltaTime;
    }

    
}
