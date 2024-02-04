using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour //creative commons (al crear assets)

    //mit license para las licencias de codigo

    //creative common también para la musica

    //mirar lo del github del profe para licencia y el readme 

    //si hay dudas como muy tarde mandarle mail el sabado (el domingo no responderá)
{
    public bool IsMoving => _isMoving;
    //public CollisionDetection _collisionDetection;

    [SerializeField]
    private float _speed = 5;
    /*[SerializeField] private GameObject[] _IsGrounded;
    [SerializeField] private GameObject[] _IsTouchingRoof;
    [SerializeField] private GameObject[] _IsPlatformGround;*/


    private bool _isMoving;
    /*private bool _isGrounded;
    private bool _isTouchingRoof;
    private bool _isPlatformGround;*/
    PlayerInput _input;
    Rigidbody2D _rigidbody;

    void Start()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();

        //if (_rigidbody.velocity.x < 0f) // José Luis Mayhua-Charalla Espinoza, transform scale to player movement but cannot be adjusted backwards.
        //{ transform.localScale = new Vector2(-1, 1); }
        //else
        //{ transform.localScale = Vector2.one; }

        //if (_rigidbody.velocity.y < 0f)
        //{ transform.localScale = new Vector2(-1, 1); }
        //else
        //{ transform.localScale = Vector2.one; }

        /*if (_isGrounded) {
            ActivatecollisionDetection(true);
            if (_rigidbody.velocity.x < 0f)
            { transform.localScale = new Vector2(-1, 1); }
            else
            { transform.localScale = Vector2.one; }

            if (_rigidbody.velocity.y < 0f)
            { transform.localScale = new Vector2(-1, 1); }
            else
            { transform.localScale = Vector2.one; }
        }

        if (_isTouchingRoof)
        {
            ActivatecollisionDetection(true);
            if (_rigidbody.velocity.x < 0f)
            { transform.localScale = new Vector2(-1, 1); }
            else
            { transform.localScale = Vector2.one; }

            if (_rigidbody.velocity.y < 0f)
            { transform.localScale = new Vector2(-1, 1); }
            else
            { transform.localScale = Vector2.one; }
        }

        if (_isPlatformGround)
        {
            ActivatecollisionDetection(true);
            if (_rigidbody.velocity.x < 0f)
            { transform.localScale = new Vector2(-1, 1); }
            else
            { transform.localScale = Vector2.one; }

            if (_rigidbody.velocity.y < 0f)
            { transform.localScale = new Vector2(-1, 1); }
            else
            { transform.localScale = Vector2.one; }
        }*/
    }

    private void Move()
    {
        Vector2 direction = new Vector2(_input.MovementHorizontal * _speed, _rigidbody.velocity.y);

        _rigidbody.velocity = direction;
        _isMoving = direction.magnitude > 0.01f;
    }

    //private void Jump()
    //{
    //    _rigidbody.AddForce(Vector3.up * _jumpForce); 
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    /*void ActivatecollisionDetection(bool active) // José Luis Mayhua-Charalla Espinoza, searching activates the collision of the object.
    {
        foreach (GameObject g in _IsGrounded)
        {
            if (_collisionDetection.IsGrounded == true)
            {
                g.SetActive(active);
            }
        }

        foreach (GameObject r in _IsTouchingRoof)
        {
            if (_collisionDetection.IsTouchingRoof == true)
            {
                r.SetActive(active);
            }
        }

        foreach (GameObject p in _IsPlatformGround)
        {
            if (_collisionDetection.IsPlatForm == true)
            {
                p.SetActive(active);
            }
        }*/
}