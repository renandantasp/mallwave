using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _moveDirection;
    private Vector2 _lastDirection;
    private bool isRunning, isWalking;
    private float horizontal, vertical;
    private PlayerManager manager;

    [HideInInspector]
    public bool canWalk;

    [HideInInspector]
    public bool isTalking;
    [HideInInspector]
    public bool isPaused;

    [SerializeField]
    private float _speed;
    
    void Start()
    {
        this._rb = GetComponentInParent<Rigidbody2D>();
        this.manager = GetComponentInParent<PlayerManager>();
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
        this.canWalk = !(manager.inventoryUIController.isInventoryOpen || isTalking || isPaused);
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        isRunning = Input.GetKey(KeyCode.LeftShift);
        _moveDirection = new Vector2(moveX, moveY).normalized;

        manager.AnimVariables.isWalking = true;


        if (moveX != 0 || moveY != 0) {
            _lastDirection = _moveDirection;
        }
        else
        {
            manager.AnimVariables.isWalking = false;
        }
        manager.AnimVariables.horizontal = _lastDirection.x;
        manager.AnimVariables.vertical = _lastDirection.y;

    }



    void Move()
    {
        float final_speed = isRunning ? _speed * 2f : _speed;
        _rb.velocity = _moveDirection * final_speed * Time.deltaTime;
    }

    
}
