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
    private float _speed = 5;
    
    private bool _isMoving;
    PlayerInput _input;
    Rigidbody2D _rigidbody;
    public ContactFilter2D filter; //maybe no hace falta tenerlo aqui
    

    //public float _jumpForce = 200;

    void Start()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && _rigidbody != null /*&& _rigidbody.velocity.magnitude == 0*/)
        //{
        //    Jump();
        //}

        Move();

        if (_rigidbody.velocity.x < 0f)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.localScale = Vector2.one;
        }

        if (_rigidbody.velocity.y < 0f)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.localScale = Vector2.one;
        }
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
}
