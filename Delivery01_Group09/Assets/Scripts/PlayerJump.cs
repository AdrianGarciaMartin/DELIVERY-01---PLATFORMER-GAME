using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class PlayerJump : MonoBehaviour
{
    // Start is called before the first frame update

    public float _jumpHeight;
    public float _distanceToMaxHeight;
    public float _speedHorizontal;
    public float _pressTimeToMaxJump;
    public float _wallSlideSpeed = 1;
    public float _gravityMultiplier = 1.2f;
    private float _jumpStartedTime;
    private float _lastVelocityY;
    private CollisionDetection _collisionDetection;
    private bool _extraJump;
    private bool _canJump = true;
    public float WallSlideSpeed = 1;

    Rigidbody2D _rigidbody;

    public ContactFilter2D filter;

    bool WallSliding => _collisionDetection.IsTouchingFront;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collisionDetection = GetComponent<CollisionDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DistanceToGround() <= 0.5)
        {
            _canJump = true;
        }
            
            

        if (IsPeakReached() && _canJump == false)
        {
            //_extraJump = true;

            GravityMultiplier();
        }

        if (WallSliding) SetWallSlide();
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


            //if (_extraJump)
            //{
            //    Debug.Log("Double Jump");

            //    SetGravity();

            //    //playerVelocity = new Vector2(_rigidbody.velocity.x, GetJumpForce());
            //    //_rigidbody.velocity = playerVelocity;

            //    _extraJump = false;
            //}
        }
    }

    public void OnJumpFinished()
    {
        float timePressed = 1 / Mathf.Clamp01((Time.time - _jumpStartedTime) / _pressTimeToMaxJump);
        _rigidbody.gravityScale *= timePressed;

        //_canJump = true;
    }

    //public void OnDoubleJump()
    //{
    //    if (_extraJump)
    //    {
    //        SetGravity();

    //        var playerVelocity = new Vector2(_rigidbody.velocity.x, GetJumpForce());
    //        _rigidbody.velocity = playerVelocity;
    //        _jumpStartedTime = Time.time;

    //        _doubleJumpDone = true;
    //        _extraJump = false;
    //    }
    //}

    //public void OnDoubleJumpFinished()
    //{
    //    if (_doubleJumpDone)
    //    {
    //        float timePressed = 1 / Mathf.Clamp01((Time.time - _jumpStartedTime) / _pressTimeToMaxJump);
    //        _rigidbody.gravityScale *= timePressed;

    //        _doubleJumpDone = false;
    //    }
    //}

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

    private void SetWallSlide()
    {
        //_rigidbody.gravityScale = 0.8f;
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x,
            Mathf.Max(_rigidbody.velocity.y, -WallSlideSpeed));
    }
}
