using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class PlayerJump : MonoBehaviour
{

    public float _jumpHeight;
    public float _distanceToMaxHeight;
    public float _speedHorizontal;
    public float _pressTimeToMaxJump;
    public float _gravityMultiplier = 1.2f;
    private float _jumpStartedTime;
    private float _lastVelocityY;
    private CollisionDetection _collisionDetection;
    private bool _extraJump;
    private bool _canJump = true;

    Rigidbody2D _rigidbody;

    public ContactFilter2D filter;

    bool WallSliding => _collisionDetection.IsTouchingFront;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collisionDetection = GetComponent<CollisionDetection>();
    }

    void Update()
    {
        if (DistanceToGround() <= 0.5)
        {
            _canJump = true;
        }
            
            

        if (IsPeakReached() && _canJump == false)
        {
            GravityMultiplier();
        }
    }

    public void OnJumpStart()
    {
        if (_canJump)
        {
            _canJump = false;

            SetGravity();

            var playerVelocity = new Vector2(_rigidbody.velocity.x, GetJumpForce());
            _rigidbody.velocity = playerVelocity;
            _jumpStartedTime = Time.time;
        }
    }

    public void OnJumpFinished()
    {
        float timePressed = 1 / Mathf.Clamp01((Time.time - _jumpStartedTime) / _pressTimeToMaxJump);
        _rigidbody.gravityScale *= timePressed;
    }

    private void SetGravity()
    {
        var gravity = 2 * _jumpHeight * (_speedHorizontal * _speedHorizontal) / (_distanceToMaxHeight * _distanceToMaxHeight);
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
        _rigidbody.gravityScale *= _gravityMultiplier;
    }

    private float GetJumpForce()
    {
        return 2 * _jumpHeight * _speedHorizontal / _distanceToMaxHeight;
    }

    private float DistanceToGround()
    {
        RaycastHit2D[] hit = new RaycastHit2D[2];
        
        Physics2D.Raycast(transform.position, Vector2.down, filter, hit, 10);

        return hit[0].distance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "HighJumpPowerUp")
        {
            _jumpHeight *= 1.75f;
        }
    }
}
