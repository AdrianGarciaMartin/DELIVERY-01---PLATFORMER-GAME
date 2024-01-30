using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool IsMoving => _isMoving;

    [SerializeField]
    private float Speed = 5; 

    private bool _isMoving;
    PlayerInput _input;
    Rigidbody2D _rigidbody;

    public float _jumpForce = 200;

    void Start()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _rigidbody != null /*&& _rigidbody.velocity.magnitude == 0*/)
        {
            Jump();
        }

        Move();
    }

    private void Move()
    {
        Vector2 direction = new Vector2(_input.MovementHorizontal * Speed, _rigidbody.velocity.y);

        _rigidbody.velocity = direction;
        _isMoving = direction.magnitude > 0.01f;
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "HighJumpPowerUp")
        {
            _jumpForce *= 2;
        }
    }
}
