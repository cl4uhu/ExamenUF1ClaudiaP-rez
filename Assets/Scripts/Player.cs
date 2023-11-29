using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _movement;
    public float _jumpforce = 5;
    public float _velocity = 5; 
    Rigidbody2D _rbody;
    Animator _animator;

    void Awake()
    {
       _rbody = GetComponent<Rigidbody2D>();
       _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
        if(Input.GetButtonDown("Jump") && GroundSensor._isGrounded)
        {
            Jump(); 
        }

        _animator.SetBool("IsJumping", !GroundSensor._isGrounded);
    }

    void FixedUpdate()
    {
        _rbody.velocity = new Vector2 (_movement * _velocity, _rbody.velocity.y); 
    }

    void Movement()
    {
        _movement = Input.GetAxis("Horizontal");
        
        if (_movement < 0)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
            _animator.SetBool("IsRunnig", true);
        }

        else if (_movement > 0)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
            _animator.SetBool("IsRunnig", true);
        }

        else;
        {
            _animator.SetBool("IsRunnig", false);
        }
    }

    void Jump()
    {
        _rbody.AddForce (Vector2.up * _jumpforce, ForceMode2D.Impulse); 
    }
}
