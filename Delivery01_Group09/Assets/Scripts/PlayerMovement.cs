using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour //creative commons (al crear assets)

    //mit o mid license para las licencias de codigo

    //creative common también para la musica

    //mirar lo del github del profe para licencia y el readme 

    //si hay dudas como muy tarde mandarle mail el sabado (el domingo no responderá)
{
    public bool IsMoving => _isMoving;

    [SerializeField]
    private float Speed = 5;
    public float JumpHeight;
    public float DistanceToMaxHeight;
    public float SpeedHorizontal;
    public float PressTimeToMaxJump;
    public float WallSlideSpeed = 1;
    private bool _isMoving;
    PlayerInput _input;
    Rigidbody2D _rigidbody;
    public ContactFilter2D filter;
    private float _jumpStartedTime;
    private float _lastVelocityY;

    public float _jumpForce = 200;

    void Start()
    {
        //_input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && _rigidbody != null /*&& _rigidbody.velocity.magnitude == 0*/)
        //{
        //    Jump();
        //}

        Move();
    }

    public void OnJumpStarted() //no hace el jump???? AAAAAA
    {
        Debug.Log("jump");

        SetGravity();

        var playerVelocity = new Vector2(_rigidbody.velocity.x, GetJumpForce());
        _rigidbody.velocity = playerVelocity;
        _jumpStartedTime = Time.time;
    }

    public void OnJumpFinished()
    {
        float timePressed = 1 / Mathf.Clamp01((Time.time - _jumpStartedTime) / PressTimeToMaxJump);
        _rigidbody.gravityScale *= timePressed;
    }

    private void SetGravity()
    {
        var gravity = 2 * JumpHeight * (SpeedHorizontal * SpeedHorizontal) / (DistanceToMaxHeight * DistanceToMaxHeight);
        _rigidbody.gravityScale = gravity / 9.81f;
    }

    private bool IsPeakReached()
    {
        bool reached = ((_lastVelocityY * _rigidbody.velocity.y) < 0);
        _lastVelocityY = _rigidbody.velocity.y;

        return reached;
    }

    private void GravityMultiplier()
    {
        _rigidbody.gravityScale *= 1.2f; //vigila hardcodeo
    }

    private float GetJumpForce()
    {
        return 2 * JumpHeight * SpeedHorizontal / DistanceToMaxHeight;
    }

    private float DistanceToGround()
    {
        RaycastHit2D[] hit = new RaycastHit2D[3];

        Physics2D.Raycast(transform.position, Vector2.down, filter, hit, 10);

        return hit[0].distance;
    }

    private void Move()
    {
        Vector2 direction = new Vector2(_input.MovementHorizontal * Speed, _rigidbody.velocity.y);

        _rigidbody.velocity = direction;
        _isMoving = direction.magnitude > 0.01f;
    }

    //private void Jump()
    //{
    //    _rigidbody.AddForce(Vector3.up * _jumpForce); 
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "HighJumpPowerUp")
        {
            _jumpForce *= 2;
        }
    }
}
