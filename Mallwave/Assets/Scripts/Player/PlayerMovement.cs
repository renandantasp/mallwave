using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _moveDirection;
    private Vector2 _lastDirection;
    private bool _isRunning;
    
    [SerializeField] private float _speed;

    public Animator Animator { get; private set; }
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        _speed = 150;
    }
    

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
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
